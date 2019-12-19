using System;

namespace DD4T.DI.SimpleInjector.Exceptions
{
    public class ProviderNotFoundException : Exception
    {
        public ProviderNotFoundException() : base("DD4T provider not found. install one of the available Tridion Providers")
        {

        }
    }
}
