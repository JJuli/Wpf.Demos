namespace Wpf.DataBinding.Fundamentals {
    using System;
    using System.Reflection;
    using System.Windows;
    using System.Windows.Controls;
    using Prism.Regions;
    using Wpf.Common.Infrastructure;
    using Wpf.DataBinding.Data;

    public partial class BindingToClrProperties : UserControl, IRegionMemberLifetime {

        Boolean IRegionMemberLifetime.KeepAlive => false;

        public BindingToClrProperties() {
            InitializeComponent();
            var loader = new AvalonEditorTextLoader();
            this.textEditor.Text = loader.GetText(Assembly.GetExecutingAssembly().GetName().Name, "02 Fundamentals", "03 ", this.GetType().Name);

            this.Loaded += (s, e) => {
                this.DataContext = PeopleService.Person;
            };
        }

        void btnChangeFirstName_Click(Object sender, RoutedEventArgs e) {
            PeopleService.Person.FirstName = "CHANGED";
        }

    }
}
