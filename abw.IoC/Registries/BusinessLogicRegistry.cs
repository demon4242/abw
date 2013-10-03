using abw.BusinessLogic.Interfaces;
using StructureMap.Configuration.DSL;

namespace abw.IoC.Registries
{
	/// <summary>
	/// Instructs <c>StructureMap</c> how to create services and all related objects.
	/// </summary>
	public class BusinessLogicRegistry : Registry
	{
		public BusinessLogicRegistry()
		{
			Scan(x =>
			{
				x.AssemblyContainingType<ICarService>();
				x.AssemblyContainingType<ICarService>();
				x.AddAllTypesOf<IMyCarService>();
				x.WithDefaultConventions().OnAddedPluginTypes(t => t.HybridHttpOrThreadLocalScoped());
			});
		}
	}
}
