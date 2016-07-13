namespace Wpf.Navigation.Navigation {
    using System.Windows.Controls;
    using Microsoft.Practices.Unity;

    public partial class DataFormView : UserControl {

        [Dependency]
        public DataFormViewModel DataFormViewModel {
            get { return this.DataContext as DataFormViewModel; }
            set { this.DataContext = value; }
        }

        public DataFormView() {
            InitializeComponent();
        }

    }
}
