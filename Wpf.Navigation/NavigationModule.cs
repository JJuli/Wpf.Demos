namespace Wpf.Navigation {
    using System;
    using Microsoft.Practices.Unity;
    using Prism.Modularity;
    using Wpf.Common.Data;
    using Wpf.Common.Model;
    using Wpf.Navigation.Navigation;
    using Wpf.Navigation.Services;

    public class NavigationModule : IModule {

        readonly IUnityContainer _container;
        readonly Lessons _lessons;

        public NavigationModule(IUnityContainer container, Lessons lessons) {
            if (container == null) {
                throw new ArgumentNullException(nameof(container));
            }
            if (lessons == null) {
                throw new ArgumentNullException(nameof(lessons));
            }
            _container = container;
            _lessons = lessons;
        }

        void IModule.Initialize() {
            // dialog service
            _container.RegisterType(typeof(IDialogService), typeof(ModalDialogService));

            // navigation lessons
            _container.RegisterType(typeof(Object), typeof(NavigationApiDemoView), typeof(NavigationApiDemoView).FullName);
            _container.RegisterType(typeof(Object), typeof(DataFormView), typeof(DataFormView).FullName);

            _lessons.Add(new Lesson {Section = "Navigation", Title = "Navigation API Demo", View = typeof(NavigationApiDemoView).FullName});
        }

    }
}
