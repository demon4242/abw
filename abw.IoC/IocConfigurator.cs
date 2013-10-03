using abw.BusinessLogic;
using abw.BusinessLogic.Interfaces;
using StructureMap;

namespace abw.IoC
{
	/// <summary>
	/// Class to store configuration of <c>Ioc</c> container.
	/// </summary>
	public static class IocConfigurator
	{
		/// <summary>
		/// Return instance of IoC container
		/// </summary>
		public static IContainer Initialize()
		{
			ObjectFactory.Initialize(m =>
			{
				m.For<ICarService>().Use<CarService>();
				m.For<IMyCarService>().Use<MyCarService>();
			});
			return ObjectFactory.Container;
		}
	}
}
