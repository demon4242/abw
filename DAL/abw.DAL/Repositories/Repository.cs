using System;
using System.Collections.Generic;
using System.Data.Entity.Design.PluralizationServices;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Xml.Linq;
using abw.Common;
using abw.DAL.Contracts;

namespace abw.DAL.Repositories
{
	public abstract class Repository<T> : IRepository<T> where T : new()
	{
		protected readonly string EntityNameForXml = typeof(T).Name.LowerFirstLetter();

		protected string PluralEntityNameForXml => PluralizationService.CreateService(CultureInfo.GetCultureInfo("en-us")).Pluralize(EntityNameForXml);

		protected string FilePath => $"{HttpRuntime.AppDomainAppPath}{WebConfigManager.XmlFilesPath}{FileName}";

		protected abstract string FileName { get; }

		public List<T> GetAll()
		{
			XDocument xDocument = XDocument.Load(FilePath);
			IEnumerable<XElement> entitiesXml = xDocument.Descendants(EntityNameForXml);

			List<T> entities = new List<T>();

			foreach (XElement entityXml in entitiesXml)
			{
				T entity = new T();

				foreach (XElement entityProp in entityXml.Elements())
				{
					if (string.IsNullOrWhiteSpace(entityProp.Value))
					{
						continue;
					}
					string propName = entityProp.Name.ToString().UpperFirstLetter();
					PropertyInfo propertyInfo = entity.GetType().GetProperty(propName);

					Type type = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType;

					object safeValue = string.IsNullOrWhiteSpace(entityProp.Value)
						? null
						: Convert.ChangeType(entityProp.Value, type);

					propertyInfo.SetValue(entity, safeValue, null);
				}

				entities.Add(entity);
			}

			return entities;
		}

		public List<T> GetAll(int page)
		{
			List<T> entities = GetAll()
				.Skip((page - 1) * WebConfigManager.GridPageSize)
				.Take(WebConfigManager.GridPageSize)
				.ToList();
			return entities;
		}

		public void Create(T entity)
		{
			PropertyInfo[] properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
			List<XElement> xElements = new List<XElement>();
			foreach (PropertyInfo propertyInfo in properties)
			{
				object value = propertyInfo.GetValue(entity) ?? string.Empty;
				XElement xElement = new XElement(propertyInfo.Name.LowerFirstLetter(), value);
				xElements.Add(xElement);
			}

			XElement entityXml = new XElement(EntityNameForXml, xElements);
			XDocument xDocument = XDocument.Load(FilePath);
			xDocument.Elements(PluralEntityNameForXml).First().Add(entityXml);

			xDocument.SaveWithTags(FilePath);
		}

		public virtual void Update(T entity, T originalEntity)
		{
			XDocument xDocument = XDocument.Load(FilePath);
			XElement xElement = Get(xDocument, originalEntity);

			PropertyInfo[] properties = GetProperties(entity);
			foreach (PropertyInfo propertyInfo in properties)
			{
				string xmlName = GetXmlName(propertyInfo);
				string xmlValue = GetXmlValue(propertyInfo, entity);
				var element = xElement.Element(xmlName);
				if (element == null)
				{
					throw new NullReferenceException();
				}
				element.Value = xmlValue;
			}

			xDocument.SaveWithTags(FilePath);
		}

		public virtual void Delete(T entity)
		{
			XDocument xDocument = XDocument.Load(FilePath);
			XElement xElement = Get(xDocument, entity);
			xElement.Remove();
			xDocument.SaveWithTags(FilePath);
		}

		private XElement Get(XDocument xDocument, T entity)
		{
			PropertyInfo[] properties = GetProperties(entity);
			Func<XElement, bool> predicates = null;
			foreach (PropertyInfo propertyInfo in properties)
			{
				string xmlName = GetXmlName(propertyInfo);
				string xmlValue = GetXmlValue(propertyInfo, entity);
				Func<XElement, bool> predicate = m => m.Element(xmlName)?.Value.ToLower() == xmlValue;

				if (predicates == null)
				{
					predicates = predicate;
				}
				else
				{
					Func<XElement, bool> currentPredicates = predicates;
					predicates = m => currentPredicates(m) && predicate(m);
				}
			}

			if (predicates == null)
			{
				throw new NullReferenceException();
			}

			XElement xElement = xDocument.Elements(PluralEntityNameForXml).Elements(EntityNameForXml).SingleOrDefault(predicates);
			return xElement;
		}

		private PropertyInfo[] GetProperties(T entity)
		{
			PropertyInfo[] properties = entity.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
			return properties;
		}

		private string GetXmlName(PropertyInfo propertyInfo)
		{
			string xmlName = propertyInfo.Name.LowerFirstLetter();
			return xmlName;
		}

		private string GetXmlValue(PropertyInfo propertyInfo, T entity)
		{
			string xmlValue = propertyInfo.GetValue(entity)?.ToString().ToLower() ?? string.Empty;
			return xmlValue;
		}
	}
}
