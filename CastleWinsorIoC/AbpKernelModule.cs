using Castle.MicroKernel.Registration;
using System.Reflection;

namespace CastleWinsorIoC
{
    public sealed class AbpKernelModule : AbpModule
    {
        public override void PreInitialize()
        {

        }

        public override void Initialize()
        {


        }

        public override void PostInitialize()
        {

        }

        public override void Shutdown()
        {

        }

        public void RegisterAssembly()
        {
            var x = Classes.FromAssembly(Assembly.GetExecutingAssembly())
                    .IncludeNonPublicTypes()
                    .BasedOn<ISingletonDependency>() // only class implementing this interface, if the class is abstract, the class is child class
                    .If(type =>
                    {
                        var y = type.GetTypeInfo();
                        return !type.GetTypeInfo().IsGenericTypeDefinition; // not a generic class
                    })
            //.WithService.Self() // register the component as implementation of inself
            .WithService.DefaultInterfaces() // register the component as implementation of its default interface (type name contains interface name removing I prefix)
            .LifestyleSingleton();
            

            IocManager.IocContainer.Register(x);
        }

    }
}
