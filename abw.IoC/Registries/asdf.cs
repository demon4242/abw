using abw.DAL.Contracts;
using abw.DAL.Repositories;
using StructureMap.Configuration.DSL;

namespace abw.IoC.Registries
{
	/// <summary>
	/// Instructs <c>StructureMap</c> how to create services and all related objects.
	/// </summary>
	public class RepositoryRegistry : Registry
	{
		public RepositoryRegistry()
		{
			Scan(x =>
			{
				x.AssemblyContainingType<IUnitOfWork>();
				x.AssemblyContainingType<UnitOfWork>();
				x.WithDefaultConventions().OnAddedPluginTypes(t => t.HybridHttpOrThreadLocalScoped());
			});

			For<IUnitOfWork>().HybridHttpOrThreadLocalScoped().Use<UnitOfWork>();
		}
	}
}
