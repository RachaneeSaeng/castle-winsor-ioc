using System;

namespace CastleWinsorIoC
{
    class Program
    {
        static void Main(string[] args)
        {
            var kernel = new AbpKernelModule();
            kernel.IocManager = IocManager.Instance;

            kernel.RegisterAssembly();

            kernel.IocManager.Register<CacheConsumer>();
            var cc = kernel.IocManager.Resolve<CacheConsumer>();

            Console.WriteLine(cc.GetCache());

            Console.WriteLine("Hello World!");
        }



    }
}
