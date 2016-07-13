namespace Wpf.Mvvm.WiringViewViewModel {
    using System.Reflection;
    using System.Windows.Controls;
    using Prism.Regions;
    using Wpf.Common.Infrastructure;

    [RegionMemberLifetime(KeepAlive = false)]
    public partial class WiredInXamlView : UserControl {

        public WiredInXamlView() {
            InitializeComponent();
            var loader = new AvalonEditorTextLoader();
            this.textEditor.Text = loader.GetText(Assembly.GetExecutingAssembly().GetName().Name, "01 WiringViewViewModel", "01 ", this.GetType().Name);

        }

    }
}
