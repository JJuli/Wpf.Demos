namespace Wpf.Common.Unity {
    using System;
    using System.Linq;
    using System.Reflection;
    using Microsoft.Practices.Unity;

    public class ContainerLoader {

        public static void InitializeLoadViews(IUnityContainer container, Assembly asy) {
            if (container == null) {
                throw new ArgumentNullException(nameof(container));
            }
            if (asy == null) {
                throw new ArgumentNullException(nameof(asy));
            }

            foreach (var type in asy.GetTypes().Where(type => type.IsClass && !type.IsAbstract)) {
                // load views 
                foreach (var atr in type.GetCustomAttributes(typeof(ViewContainerInitializerAttribute), false).OfType<ViewContainerInitializerAttribute>()) {
                    if (atr.ViewModel == null) {
                        RegisterWithoutSettingDataContext(container, type, atr.RegisterForRegionNavigation);
                    } else {
                        switch (atr.RegisterForRegionNavigation) {
                            case RegisterForRegionNavigation.Yes:
                                container.RegisterType(typeof(Object), type, type.FullName, new InjectionProperty(DataContext, atr.ViewModel));
                                break;
                            case RegisterForRegionNavigation.No:
                                container.RegisterType(type, new InjectionProperty(DataContext, atr.ViewModel));
                                break;
                        }
                    }
                }

                // load view models
                foreach (var atr in type.GetCustomAttributes(typeof(ViewModelContainerInitializerAttribute), false).OfType<ViewModelContainerInitializerAttribute>()) {
                    RegisterWithoutSettingDataContext(container, type, atr.RegisterForRegionNavigation);
                }
            }
        }

        const String DataContext = "DataContext";

        static void RegisterWithoutSettingDataContext(IUnityContainer container, Type type, RegisterForRegionNavigation registerForRegionNavigation) {
            switch (registerForRegionNavigation) {
                case RegisterForRegionNavigation.Yes:
                    container.RegisterType(typeof(Object), type, type.FullName);
                    break;
                case RegisterForRegionNavigation.No:
                    container.RegisterType(type);
                    break;
            }
        }

    }
}
