namespace Wpf.DataBinding.Introduction {
    using System;
    using System.Reflection;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using Prism.Regions;
    using Wpf.Common.Infrastructure;
    using Wpf.DataBinding.Data;

    public partial class BindingsSetInCode : UserControl, IRegionMemberLifetime {

        Boolean IRegionMemberLifetime.KeepAlive => false;

        public BindingsSetInCode() {
            InitializeComponent();
            var loader = new AvalonEditorTextLoader();
            this.textEditor.Text = loader.GetText(Assembly.GetExecutingAssembly().GetName().Name, "01 Introduction", "07 ", this.GetType().Name);


            this.Loaded += BindingsSetInCode_Loaded;
        }

        void BindingsSetInCode_Loaded(object sender, System.Windows.RoutedEventArgs e) {
            this.txtFirstName.SetBinding(TextBox.TextProperty, new Binding("FirstName"));

            var b = new Binding();
            b.Path = new PropertyPath("LastName");
            this.txtLastName.SetBinding(TextBox.TextProperty, b);

            b = new Binding();
            b.Path = new PropertyPath("Birthday");
            b.StringFormat = "d";
            b.TargetNullValue = String.Empty;
            this.txtBirthday.SetBinding(TextBox.TextProperty, b);

            this.DataContext = PeopleService.People;
        }

    }
}
