namespace XamlDeveloper.Presentation.View {
    using System;
    using System.Windows.Controls;
    using Infragistics.Controls.Charts;
    using Prism.Regions;
    using Wpf.Common.Unity;

    [RegionMemberLifetime(KeepAlive = false)]
    [ViewContainerInitializer(typeof(XamlIsThemeableViewModel))]
    public partial class XamlIsThemeableView : UserControl {

        public XamlIsThemeableView() {
            InitializeComponent();
        }

        void pieChart_SliceClick(Object sender, SliceClickEventArgs e) {
            e.IsExploded = !e.IsExploded; 
        }

    }
}
