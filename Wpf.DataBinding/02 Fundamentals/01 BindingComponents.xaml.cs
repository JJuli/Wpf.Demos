namespace Wpf.DataBinding.Fundamentals {
    using System;
    using System.Windows.Controls;
    using Prism.Regions;

    public partial class BindingComponents : UserControl, IRegionMemberLifetime {

        Boolean IRegionMemberLifetime.KeepAlive => false;

        public BindingComponents() {
            InitializeComponent();
        }

    }
}
