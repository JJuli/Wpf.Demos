namespace Wpf.Mvvm.WiringViewViewModel {
    using System.Reflection;
    using System.Windows.Controls;
    using Prism.Regions;
    using Wpf.Common.Infrastructure;

    [RegionMemberLifetime(KeepAlive = false)]
    public partial class WiredInViewCodeBehind : UserControl {

        public WiredInViewCodeBehind() {
            InitializeComponent();
            var loader = new AvalonEditorTextLoader();
            this.textEditor.Text = loader.GetText(Assembly.GetExecutingAssembly().GetName().Name, "01 WiringViewViewModel", "02 ", this.GetType().Name);

            this.Loaded += (s, e) => this.DataContext = new ViewModel();
        }

    }
}
