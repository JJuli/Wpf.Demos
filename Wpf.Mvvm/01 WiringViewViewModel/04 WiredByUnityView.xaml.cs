namespace Wpf.Mvvm.WiringViewViewModel {
    using System.Reflection;
    using System.Windows.Controls;
    using Prism.Regions;
    using Wpf.Common.Infrastructure;
    using Wpf.Common.Unity;

    [RegionMemberLifetime(KeepAlive = false)]
    [ViewContainerInitializer(typeof(ViewModel))]
    public partial class WiredByUnityView : UserControl {

        public WiredByUnityView() {
            InitializeComponent();
            var loader = new AvalonEditorTextLoader();
            this.textEditor.Text = loader.GetText(Assembly.GetExecutingAssembly().GetName().Name, "01 WiringViewViewModel", "04 ", this.GetType().Name);

        }

    }
}
