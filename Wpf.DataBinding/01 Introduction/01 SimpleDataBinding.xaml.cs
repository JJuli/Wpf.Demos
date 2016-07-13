namespace Wpf.DataBinding.Introduction {
    using System;
    using System.Reflection;
    using System.Windows.Controls;
    using Prism.Regions;
    using Wpf.Common.Infrastructure;

    public partial class SimpleDataBinding : UserControl, IRegionMemberLifetime {

        Boolean IRegionMemberLifetime.KeepAlive => false;

        public SimpleDataBinding() {
            InitializeComponent();
            var loader = new AvalonEditorTextLoader();
            this.textEditor.Text = loader.GetText(Assembly.GetExecutingAssembly().GetName().Name, "01 Introduction", "01 ", this.GetType().Name);
        }

    }
}
