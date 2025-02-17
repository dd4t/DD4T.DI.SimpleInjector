using System;
using System.Linq;
using System.Web.Mvc;
using SimpleInjector;
using SimpleInjector.Advanced;

namespace DD4T.DI.SimpleInjector.Extensions
{
    public static class RegisterTypeExtension
    {
		public static void RegisterType<T, TU>(this Container builder)
        {
            builder.RegisterType(typeof(T), typeof(TU), Lifestyle.Singleton, false);
        }

        public static void RegisterType<T>(this Container builder, Type implementationType)
        {
            builder.RegisterType(typeof(T), implementationType, Lifestyle.Singleton, false);
        }

        public static void RegisterType(this Container builder, Type serviceType, Type implementationType)
        {
            builder.RegisterType(serviceType, implementationType, Lifestyle.Singleton, false);
        }

	    public static void RegisterType(this Container builder, Type serviceType, Type implementationType, Lifestyle lifestyle)
	    {
		    builder.RegisterType(serviceType, implementationType, lifestyle, false);
	    }

		public static void RegisterPreserveExistingDefaults<T, TU>(this Container builder)
	    {
		    builder.RegisterType(typeof(T), typeof(TU), Lifestyle.Singleton, true);
	    }


		public static void RegisterPreserveExistingDefaults<T>(this Container builder, Type implementationType)
	    {
		    builder.RegisterType(typeof(T), implementationType, Lifestyle.Singleton, true);
	    }

	    public static void RegisterPreserveExistingDefaults(this Container builder, Type serviceType, Type implementationType)
	    {
		    builder.RegisterType(serviceType, implementationType, Lifestyle.Singleton, false);
	    }

		public static void RegisterPreserveExistingDefaults(this Container builder, Type serviceType, Type implementationType, Lifestyle lifestyle)
	    {
			builder.RegisterType(serviceType, implementationType, lifestyle, true);
		}

		public static void RegisterType(this Container builder, Type serviceType, Type implementationType, Lifestyle lifestyle, bool preserveExistingDefaults)
        {
            if (implementationType == null) return;

            try
            {
	            if ((builder.GetCurrentRegistrations() == null ||
	                 builder.GetCurrentRegistrations().All(x => x.ServiceType != serviceType)) &&
	                typeof(IModelBinderProvider) != serviceType)
	            {
		            builder.Register(serviceType, implementationType, lifestyle);
	            }
	            else if (!preserveExistingDefaults)
	            {
					builder.Collection.Append(serviceType, implementationType);
				}
            }
            catch (InvalidOperationException)
            {
				if (!preserveExistingDefaults)
				{
                    builder.Collection.Append(serviceType, implementationType);
				}
			}
            catch (ArgumentNullException)
            {

            }
            catch (ArgumentException)
            {
				
            }
        }
    }
}
