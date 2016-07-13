namespace Wpf.DataBinding.Introduction {
    using System;
    using System.Reflection;
    using System.Windows.Controls;
    using Prism.Regions;
    using Wpf.Common.Infrastructure;
    using Wpf.DataBinding.Data;

    public partial class DataContextSetFromAnotherControlSourceInCode : UserControl, IRegionMemberLifetime {

        Boolean IRegionMemberLifetime.KeepAlive => false;

        public DataContextSetFromAnotherControlSourceInCode() {
            InitializeComponent();
            var loader = new AvalonEditorTextLoader();
            this.textEditor.Text = loader.GetText(Assembly.GetExecutingAssembly().GetName().Name, "01 Introduction", "06 ", this.GetType().Name);

            this.Loaded += (s, e) => {
                this.DataContext = PeopleService.People;
            };
        }

    }
}
