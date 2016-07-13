namespace Wpf.DataBinding.Fundamentals {
    using System;
    using System.Reflection;
    using System.Windows.Controls;
    using Prism.Regions;
    using Wpf.Common.Infrastructure;
    using Wpf.DataBinding.Data;

    public partial class UpdateSourceTrigger : UserControl, IRegionMemberLifetime {

        Boolean IRegionMemberLifetime.KeepAlive => false;

        public UpdateSourceTrigger() {
            InitializeComponent();
            var loader = new AvalonEditorTextLoader();
            this.textEditor.Text = loader.GetText(Assembly.GetExecutingAssembly().GetName().Name, "02 Fundamentals", "05 ", this.GetType().Name);

            this.Loaded += (s, e) => {
                this.DataContext = PeopleService.Person;
            };
        }

    }
}
