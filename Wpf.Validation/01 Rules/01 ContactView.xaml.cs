namespace Wpf.Validation.Rules {
    using System;
    using Prism.Regions;
    using Wpf.Validation.Infrastructure;

    public partial class ContactView : MaintenanceFormViewBase, IRegionMemberLifetime {

        Boolean IRegionMemberLifetime.KeepAlive => false;

        public ContactView() {
            InitializeComponent();
        }

    }
}
