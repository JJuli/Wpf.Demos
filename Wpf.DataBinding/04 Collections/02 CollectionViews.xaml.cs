namespace Wpf.DataBinding.Collections {
    using System;
    using System.Windows.Controls;
    using Prism.Regions;

    public partial class CollectionViews : UserControl, IRegionMemberLifetime {

        Boolean IRegionMemberLifetime.KeepAlive => false;

        public CollectionViews() {
            InitializeComponent();
        }

    }
}
