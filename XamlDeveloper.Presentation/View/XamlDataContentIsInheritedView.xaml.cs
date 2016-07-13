namespace XamlDeveloper.Presentation.View {
    using System.Windows.Controls;
    using Prism.Regions;
    using Wpf.Common.Unity;

    [RegionMemberLifetime(KeepAlive = false)]
    [ViewContainerInitializer]
    public partial class XamlDataContentIsInheritedView : UserControl {

        public XamlDataContentIsInheritedView() {
            InitializeComponent();
        }

    }
}
