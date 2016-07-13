namespace Wpf.Mvvm.WiringViewViewModel {
    using System.Reflection;
    using System.Windows.Controls;
    using Microsoft.Practices.Unity;
    using Prism.Regions;
    using Wpf.Common.Infrastructure;

    [RegionMemberLifetime(KeepAlive = false)]
    public partial class WiredUsingPropertyInjection : UserControl {

        [Dependency]
        public ViewModel ViewModel {
            get { return this.DataContext as ViewModel; }
            set { this.DataContext = value; }
        }

        public WiredUsingPropertyInjection() {
            InitializeComponent();
            var loader = new AvalonEditorTextLoader();
            this.textEditor.Text = loader.GetText(Assembly.GetExecutingAssembly().GetName().Name, "01 WiringViewViewModel", "03 ", this.GetType().Name);

        }

    }
}
