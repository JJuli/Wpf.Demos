namespace AsyncDataAccess.Presentation {
    using System;
    using AsyncDataAccess.Presentation.Infrastructure;
    using AsyncDataAccess.Presentation.Services;
    using Microsoft.Practices.Unity;
    using Prism.Regions;
    using Wpf.Common.Dialog;
    using Wpf.Common.Modules;
    using XamlDeveloper.Domain.Data;
    using View;
    public class PresentationModule : ModuleBase {

        readonly IRegionManager _regionManager;

        public PresentationModule(IUnityContainer container, IRegionManager regionManager)
            : base(container) {
            if (regionManager == null) {
                throw new ArgumentNullException(nameof(regionManager));
            }
            _regionManager = regionManager;
        }

        public override void Initialize() {
            // all views in the assembly decorated with 
            //   ViewContainerInitializerAttribute or
            //   ViewModelContainerInitializerAttribute.cs 
            // are loaded into the container in base.Initialize
            base.Initialize();

            this.Container.RegisterType(typeof(IBusinessService), typeof(BusinessService));
            this.Container.RegisterType(typeof(IAsyncDataService), typeof(AsyncDataService));
            this.Container.RegisterType(typeof(IDialogService), typeof(DialogService));

            _regionManager.RequestNavigate(Constants.ContentRegionName, typeof(AsyncDataDemoView).FullName);
        }

    }
}
