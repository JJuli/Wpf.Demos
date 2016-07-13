namespace Wpf.DataBinding.Introduction {
    using System;
    using System.Windows.Controls;
    using Prism.Regions;

    public partial class DataBindingObjects : UserControl, IRegionMemberLifetime {

        Boolean IRegionMemberLifetime.KeepAlive => false;

        public DataBindingObjects() {
            InitializeComponent();
        }

    }
}
