using System.Xml;
using System.Xml.Linq;

namespace abw.Common
{
	public static class XDocumentExtenstions
	{
		public static void SaveWithTags(this XDocument xDocument, string filePath)
		{
			XmlWriterSettings settings = new XmlWriterSettings
			{
				Indent = true,
				IndentChars = "	"
			};

			using (XmlWriter writer = XmlWriter.Create(filePath, settings))
			{
				xDocument.Save(writer);
			}
		}
	}
}
