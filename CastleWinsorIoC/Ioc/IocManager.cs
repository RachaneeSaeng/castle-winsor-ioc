using Castle.DynamicProxy;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Proxy;
using System;
using System.Reflection;

namespace CastleWinsorIoC
{
    public class IocManager : IIocManager
    {
        /// <summary>
        /// The Singleton instance.
        /// </summary>
        public static IocManager Instance { get; private set; }

        /// <summary>
        /// Singletone instance for Castle ProxyGenerator.
        /// From Castle.Core documentation it is highly recomended to use single instance of ProxyGenerator to avoid memoryleaks and performance issues
        /// Follow next links for more details:
        /// <a href="https://github.com/castleproject/Core/blob/master/docs/dynamicproxy.md">Castle.Core documentation</a>,
        /// <a href="http://kozmic.net/2009/07/05/castle-dynamic-proxy-tutorial-part-xii-caching/">Article</a>
        /// </summary>
        private static readonly ProxyGenerator ProxyGeneratorInstance = new ProxyGenerator();

        /// <summary>
        /// Reference to the Castle Windsor Container.
        /// </summary>
        public IWindsorContainer IocContainer { get; private set; }

        static IocManager()
        {
            Instance = new IocManager();
        }

        /// <summary>
        /// Creates a new <see cref="IocManager"/> object.
        /// Normally, you don't directly instantiate an <see cref="IocManager"/>.
        /// This may be useful for test purposes.
        /// </summary>
        public IocManager()
        {
            IocContainer = CreateContainer();

            //Register self!
            //IocContainer.Register(
            //    Component
            //        .For<IocManager, IIocManager, IIocRegistrar, IIocResolver>()
            //        .Instance(this)
            //);
        }

        protected virtual IWindsorContainer CreateContainer()
        {
            return new WindsorContainer(new DefaultProxyFactory(ProxyGeneratorInstance));
        }

        public bool IsRegistered(Type type)
        {
            throw new NotImplementedException();
        }

        public bool IsRegistered<T>()
        {
            throw new NotImplementedException();
        }

        public void RegisterAssemblyByConvention(Assembly assembly)
        {
            throw new NotImplementedException();
        }

        public void Register<T>(DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton) where T : class
        {
            IocContainer.Register(ApplyLifestyle(Component.For<T>(), lifeStyle));
        }

        public void Register(Type type, DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
        {
            throw new NotImplementedException();
        }

        void IIocRegistrar.Register<TType, TImpl>(DependencyLifeStyle lifeStyle)
        {
            throw new NotImplementedException();
        }

        public void Register(Type type, Type impl, DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
        {
            throw new NotImplementedException();
        }

        public T Resolve<T>()
        {
            return IocContainer.Resolve<T>();
        }

        public T Resolve<T>(Type type)
        {
            throw new NotImplementedException();
        }

        public T Resolve<T>(object argumentsAsAnonymousType)
        {
            throw new NotImplementedException();
        }

        public object Resolve(Type type)
        {
            throw new NotImplementedException();
        }

        public object Resolve(Type type, object argumentsAsAnonymousType)
        {
            throw new NotImplementedException();
        }

        public T[] ResolveAll<T>()
        {
            throw new NotImplementedException();
        }

        public T[] ResolveAll<T>(object argumentsAsAnonymousType)
        {
            throw new NotImplementedException();
        }

        public object[] ResolveAll(Type type)
        {
            throw new NotImplementedException();
        }

        public object[] ResolveAll(Type type, object argumentsAsAnonymousType)
        {
            throw new NotImplementedException();
        }

        public void Release(object obj)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        private static ComponentRegistration<T> ApplyLifestyle<T>(ComponentRegistration<T> registration, DependencyLifeStyle lifeStyle)
            where T : class
        {
            switch (lifeStyle)
            {
                case DependencyLifeStyle.Transient:
                    return registration.LifestyleTransient();
                case DependencyLifeStyle.Singleton:
                    return registration.LifestyleSingleton();
                default:
                    return registration;
            }
        }
    }
}
