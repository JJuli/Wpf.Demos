namespace Wpf.DataBinding.Fundamentals {
    using System;
    using System.Windows.Controls;
    using Prism.Regions;

    public partial class BindingModes : UserControl, IRegionMemberLifetime {

        Boolean IRegionMemberLifetime.KeepAlive => false;

        public BindingModes() {
            InitializeComponent();
        }

    }
}
