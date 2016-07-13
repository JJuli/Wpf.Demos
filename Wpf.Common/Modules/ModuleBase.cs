namespace Wpf.Common.Modules {
    using System;
    using System.Reflection;
    using Microsoft.Practices.Unity;
    using Prism.Modularity;
    using Wpf.Common.Unity;

    /// <summary>
    /// Represents the ModuleBase class.  Provides automatic container loading for view - view model wiring
    /// </summary>
    public abstract class ModuleBase : IModule {

        readonly IUnityContainer _container;

        protected IUnityContainer Container => _container;

        /// <summary>
        /// Provides automatic container loading for view - view model wiring.
        /// </summary>
        public virtual void Initialize() {
            var asy = Assembly.GetCallingAssembly();
            ContainerLoader.InitializeLoadViews(_container, asy);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleBase"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        protected ModuleBase(IUnityContainer container) {
            if (container == null) {
                throw new ArgumentNullException(nameof(container));
            }
            _container = container;
        }

    }
}
