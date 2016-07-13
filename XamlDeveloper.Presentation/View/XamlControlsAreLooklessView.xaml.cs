namespace XamlDeveloper.Presentation.View {
    using System.Windows;
    using System.Windows.Controls;
    using Prism.Regions;
    using Wpf.Common.Unity;

    [RegionMemberLifetime(KeepAlive = false)]
    [ViewContainerInitializer]
    public partial class XamlControlsAreLooklessView : UserControl {

        public XamlControlsAreLooklessView() {
            InitializeComponent();
        }

        void ChkUseHardwareLightFixtures_OnClick(object sender, RoutedEventArgs e) {
            if (this.chkUseHardwareLightFixtures.IsChecked.HasValue && this.chkUseHardwareLightFixtures.IsChecked.Value) {
                var style = this.FindResource("hardwareStopLightStyle") as Style;
                if (style != null) {
                    this.NorthLight.Style = style;
                    this.SouthLight.Style = style;
                    this.EastLight.Style = style;
                    this.WestLight.Style = style;
                }
            } else {
                this.NorthLight.Style = null;
                this.SouthLight.Style = null;
                this.EastLight.Style = null;
                this.WestLight.Style = null;
            }
        }

    }
}
