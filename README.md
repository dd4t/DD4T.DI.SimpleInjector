[![AppVeyor](https://ci.appveyor.com/api/projects/status/github/dd4t/DD4T.DI.SimpleInjector?branch=master&svg=true&passingText=master)](https://ci.appveyor.com/project/DD4T/dd4t-di-simpleinjector)

[![AppVeyor](https://ci.appveyor.com/api/projects/status/github/dd4t/DD4T.DI.SimpleInjector?branch=develop&svg=true&passingText=develop)](https://ci.appveyor.com/project/DD4T/dd4t-di-simpleinjector)

# DD4T.DI.SimpleInjector
Dependency Injection for DD4T using SimpleInjector

## Release 2.5

- Upgraded reference to DD4T.Core


## How to 

1. Install Nuget package: `Install-Package DD4T.DI.SimpleInjector` [http://www.nuget.org/packages/DD4T.DI.SimpleInjector](http://www.nuget.org/packages/DD4T.DI.SimpleInjector "DD4T.DI.SimpleInjector")
2. Add `DD4T.DI.SimpleInjector` namespace to your usings
3. Call the `UseDD4T` method on your SimpleInjector `SimpleInjector.Container` interface. Normally, this is done in the Global.asax.

>     var container = new SimpleInjector.Container();
>     // set all your custom bindings here.
>     container.UseDD4T();
>     container.Verify();


UseDD4T will register all default classes provided by the DD4T framework.

If you need to override the default classes: (i.e. the DefaultPublicationResolver) Register your class before the method call `UseDD4T`

>     var container = new SimpleInjector.Container();
>     // set all your custom bindings here.
>     container.Register<ILogger, FileLogger>(Lifestyle.Singleton);
>     container.UseDD4T();
>     container.Verify();

