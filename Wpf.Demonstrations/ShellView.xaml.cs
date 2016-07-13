namespace Wpf.Demonstrations {
    using System.Windows;
    using Microsoft.Practices.Unity;

    public partial class ShellView : Window {

        [Dependency]
        public ShellViewModel ShellViewModel {
            get { return this.DataContext as ShellViewModel; }
            set { this.DataContext = value; }
        }

        public ShellView() {
            InitializeComponent();
        }

    }
}
