namespace XamlDeveloper.Presentation.View {
    using System.Windows.Controls;
    using Prism.Regions;
    using Wpf.Common.Unity;

    [RegionMemberLifetime(KeepAlive = false)]
    [ViewContainerInitializer(typeof(XamlMVVMDemoCodeViewModel))]
    public partial class XamlMVVMDemoCodeView : UserControl {

        public XamlMVVMDemoCodeView() {
            InitializeComponent();
        }

    }
}
