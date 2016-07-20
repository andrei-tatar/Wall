using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Web.Http.Dependencies;

namespace Service
{
    public class MefDependencyResolver : IDependencyResolver
    {
        private readonly CompositionContainer _container;
        private readonly ComposablePartCatalog _catalog;
        private static readonly string CreationPolicyKey = typeof(CreationPolicy).FullName;

        public MefDependencyResolver()
        {
            _catalog = new ApplicationCatalog();
            _container = new CompositionContainer(_catalog);
        }

        private MefDependencyResolver(ExportProvider parent, ComposablePartCatalog parentCatalog)
        {
            _container = new CompositionContainer(new FilteredCatalog(parentCatalog, Filter), parent);
        }

        private static bool Filter(ComposablePartDefinition definition)
        {
            object creationPolicyObj;
            return definition.Metadata.TryGetValue(CreationPolicyKey, out creationPolicyObj) &&
                   (CreationPolicy)creationPolicyObj == CreationPolicy.NonShared;
        }

        public void Dispose()
        {
            _container.Dispose();
            _catalog?.Dispose();
        }

        public IDependencyScope BeginScope()
        {
            return new MefDependencyResolver(_container, _catalog);
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