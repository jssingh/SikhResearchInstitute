using System;
using StructureMap;
using Tarantino.Core;
using Tarantino.Core.Commons.Services.Logging;
using Tarantino.Infrastructure;

namespace SikhResearchInstitute.DependencyResolution
{
	public class DependencyRegistrar
	{
		private static bool _dependenciesRegistered;
		private static readonly object sync = new object();

		public void RegisterDependencies()
		{
			Logger.Debug(this, "Registering types with StructureMap");

			ObjectFactory.Initialize(x =>
			                         	{
			                         		x.Scan(y =>
			                         		       	{
			                         		       		y.AssemblyContainingType<CoreDependencyRegistry>();
			                         		       		y.AssemblyContainingType<InfrastructureDependencyRegistry>();
			                         		       		y.AssemblyContainingType<DependencyRegistry>();
			                         		       	});
			                         		x.AddRegistry<CastleValidatorRegistry>();
			                         	});
		}

		public static T Resolve<T>()
		{
			return ObjectFactory.GetInstance<T>();
		}

		public static object Resolve(Type modelType)
		{
			return ObjectFactory.GetInstance(modelType);
		}

		public static bool Registered<T>()
		{
			EnsureDependenciesRegistered();
			return ObjectFactory.GetInstance<T>() != null;
		}

		public static bool Registered(Type type)
		{
			EnsureDependenciesRegistered();
			return ObjectFactory.GetInstance(type) != null;
		}

		public static void EnsureDependenciesRegistered()
		{
			if (!_dependenciesRegistered)
			{
				lock (sync)
				{
					if (!_dependenciesRegistered)
					{
						_dependenciesRegistered = true;
						new DependencyRegistrar().RegisterDependencies();
					}
				}
			}
		}
	}
}