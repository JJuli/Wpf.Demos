namespace AsyncDataAccess.Presentation.View {
    using System.Windows.Controls;
    using Prism.Regions;
    using Wpf.Common.Unity;

    [RegionMemberLifetime(KeepAlive = false)]
    [ViewContainerInitializer(typeof(AsyncDataDemoViewModel))]
    public partial class AsyncDataDemoView : UserControl {

        public AsyncDataDemoView() {
            InitializeComponent();
        }

    }
}
