namespace Wpf.DataBinding.Introduction {
    using System;
    using System.Reflection;
    using System.Windows.Controls;
    using Prism.Regions;
    using Wpf.Common.Infrastructure;
    using Wpf.DataBinding.Data;

    public partial class DataContextSetInCode : UserControl, IRegionMemberLifetime {

        Boolean IRegionMemberLifetime.KeepAlive => false;

        public DataContextSetInCode() {
            InitializeComponent();
            var loader = new AvalonEditorTextLoader();
            this.textEditor.Text = loader.GetText(Assembly.GetExecutingAssembly().GetName().Name, "01 Introduction", "04 ", this.GetType().Name);

            this.Loaded += (s, e) => {
                this.DataContext = PeopleService.Person;
            };
        }

    }
}
