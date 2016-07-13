namespace Wpf.Presentation {
    using System;
    using Microsoft.Practices.Unity;
    using Prism.Modularity;
    using Prism.Regions;
    using Wpf.Common.Data;
    using Wpf.Common.Infrastructure;
    using Wpf.Common.Model;
    using Wpf.Presentation.Views;

    public class PresentationModule : IModule {

        readonly IUnityContainer _container;
        readonly Lessons _lessons;
        readonly IRegionManager _regionManager;

        public PresentationModule(Lessons lessons, IUnityContainer container, IRegionManager regionManager) {
            if (lessons == null) {
                throw new ArgumentNullException(nameof(lessons));
            }
            if (container == null) {
                throw new ArgumentNullException(nameof(container));
            }
            if (regionManager == null) {
                throw new ArgumentNullException(nameof(regionManager));
            }
            _lessons = lessons;
            _container = container;
            _regionManager = regionManager;
        }

        void IModule.Initialize() {
            // application views
            _container.RegisterType(typeof(Object), typeof(NavigationView), typeof(NavigationView).FullName);
            _container.RegisterType(typeof(Object), typeof(HomeView), typeof(HomeView).FullName);

            _lessons.Insert(0, new Lesson {Section = "Welcome", Title = "Home", View = typeof(HomeView).FullName});

            // load navigation region using Prism View Discovery
            _regionManager.RegisterViewWithRegion(Constants.NavigationRegionName, () => _container.Resolve<NavigationView>());
        }

    }
}
