using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Web.Http.Dependencies;

namespace Service
{
    public class MefDependencyResolver : IDependencyResolver
    {
        private readonly CompositionContainer _container;

        public MefDependencyResolver()
        {
            _container = new CompositionContainer(new ApplicationCatalog());
        }

        public void Dispose()
        {
            _container.Dispose();
        }

        public IDependencyScope BeginScope()
        {
            return new MefDependencyResolver();
        }

        public object GetService(Type serviceType)
        {
            return _container.GetExports(serviceType, null, string.Empty).FirstOrDefault()?.Value;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _container.GetExports(serviceType, null, string.Empty).Select(e => e.Value).ToArray();
        }

        public IEnumerable<T> Resolve<T>()
        {
            return _container.GetExports<T>().Select(l => l.Value).ToArray();
        }
    }
}