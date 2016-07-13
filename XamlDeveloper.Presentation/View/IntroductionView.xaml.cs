namespace XamlDeveloper.Presentation.View {
    using System.Windows.Controls;
    using Prism.Regions;
    using Wpf.Common.Unity;

    [RegionMemberLifetime(KeepAlive = false)]
    [ViewContainerInitializer(typeof(IntroductionViewModel))]
    public partial class IntroductionView : UserControl {

        public IntroductionView() {
            InitializeComponent();
        }

    }
}
