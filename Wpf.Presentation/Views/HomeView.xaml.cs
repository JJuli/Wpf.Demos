namespace Wpf.Presentation.Views {
    using System;
    using System.Windows.Controls;
    using Prism.Regions;

    public partial class HomeView : UserControl, IRegionMemberLifetime {

        Boolean IRegionMemberLifetime.KeepAlive => false;

        public HomeView() {
            InitializeComponent();
        }

    }
}
