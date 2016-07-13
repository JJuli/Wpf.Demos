namespace XamlDeveloper.Presentation {
    using System;
    using System.CodeDom;
    using Microsoft.Practices.Unity;
    using Wpf.Common.Data;
    using Wpf.Common.Dialog;
    using Wpf.Common.Model;
    using Wpf.Common.Modules;
    using XamlDeveloper.Domain.Data;
    using XamlDeveloper.Presentation.View;

    public class PresentationModule : ModuleBase {

        readonly Presentations _presentations;

        public PresentationModule(IUnityContainer container, Presentations presentations)
            : base(container) {
            if (presentations == null) {
                throw new ArgumentNullException(nameof(presentations));
            }

            _presentations = presentations;
        }

        public override void Initialize() {
            // all views in the assembly decorated with 
            //   ViewContainerInitializerAttribute or
            //   ViewModelContainerInitializerAttribute.cs 
            // are loaded into the container in base.Initialize
            base.Initialize();

            this.Container.RegisterType(typeof(IBusinessService), typeof(BusinessService), new ContainerControlledLifetimeManager());
            this.Container.RegisterType(typeof(IDialogService), typeof(DialogService));

            _presentations.Add(new Presentation("Introduction", typeof(IntroductionView).FullName));
            _presentations.Add(new Presentation("What Is XAML", typeof(WhatIsXamlView).FullName));
            _presentations.Add(new Presentation("Why Use XAML", typeof(WhyUseXamlView).FullName));
            _presentations.Add(new Presentation("XAML Is Concise",typeof(XamlIsConciseView).FullName));
            _presentations.Add(new Presentation("XAML Is Composable",typeof(XamlIsComposableView).FullName));
            _presentations.Add(new Presentation("XAML Is Styleable", typeof(XamlIsStyleableView).FullName));
            _presentations.Add(new Presentation("XAML Controls Are Lookless", typeof(XamlControlsAreLooklessView).FullName));
            _presentations.Add(new Presentation("XAML Is Themeable", typeof(XamlIsThemeableView).FullName));
            _presentations.Add(new Presentation("XAML Has Multimedia Capabilities",typeof(XamlHasMultiMediaCapabilitiesView).FullName));
            _presentations.Add(new Presentation("XAML Has Rich Data Binding API's", typeof(XamlHasRichDataBindingStackView).FullName));
            _presentations.Add(new Presentation("XAML DataContext Is Inheritable", typeof(XamlDataContentIsInheritedView).FullName));
            _presentations.Add(new Presentation("XAML Enables M-V-VM", typeof(XamlMVVMView).FullName));
            _presentations.Add(new Presentation("XAML M-V-VM Demo", typeof(XamlMVVMDemoCodeView).FullName));
        }

    }
}
