namespace Wpf.DataBinding.Collections {
    using System;
    using System.Windows.Controls;
    using Prism.Regions;

    public partial class BindingToCollections : UserControl, IRegionMemberLifetime {

        Boolean IRegionMemberLifetime.KeepAlive => false;

        public BindingToCollections() {
            InitializeComponent();
        }

    }
}
