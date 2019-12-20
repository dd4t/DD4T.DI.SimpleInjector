using System;
using System.Linq;
using DD4T.Core.Contracts.DependencyInjection;
using DD4T.DI.SimpleInjector.Extensions;
using SimpleInjector;

namespace DD4T.DI.SimpleInjector
{
	public static class Bootstrap
    {
        public static void UseDD4T(this Container builder)
        {
			var mappers = AppDomain.CurrentDomain.GetAssemblies()
								   .Where(ass => ass.FullName.StartsWith("DD4T."))
								   .SelectMany(s => s.GetTypes())
								   .Where(p => typeof(IDependencyMapper).IsAssignableFrom(p) && !p.IsInterface)
								   .Select(o => Activator.CreateInstance(o) as IDependencyMapper).Distinct();

	        foreach (var mapper in mappers)
	        {
		        if (mapper.SingleInstanceMappings != null)
		        {
			        foreach (var mapping in mapper.SingleInstanceMappings)
			        {
				        builder.RegisterPreserveExistingDefaults(mapping.Key, mapping.Value, Lifestyle.Singleton);
			        }
		        }
		        if (mapper.PerDependencyMappings != null)
		        {
			        foreach (var mapping in mapper.PerDependencyMappings)
			        {
				        builder.RegisterPreserveExistingDefaults(mapping.Key, mapping.Value, Lifestyle.Transient); //Transient
			        }
		        }
		        if (mapper.PerHttpRequestMappings != null)
		        {
			        foreach (var mapping in mapper.PerHttpRequestMappings)
			        {
				        builder.RegisterPreserveExistingDefaults(mapping.Key, mapping.Value, Lifestyle.Scoped); //Scoped
			        }
		        }
		        if (mapper.PerLifeTimeMappings != null)
		        {
			        foreach (var mapping in mapper.PerLifeTimeMappings)
			        {
				        builder.RegisterPreserveExistingDefaults(mapping.Key, mapping.Value, Lifestyle.Singleton);
			        }
		        }
	        }
		}
	}
}
