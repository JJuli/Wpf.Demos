namespace Wpf.DataBinding.Fundamentals {
    using System;
    using System.Reflection;
    using System.Windows.Controls;
    using Prism.Regions;
    using Wpf.Common.Infrastructure;

    public partial class RelativeSource : UserControl, IRegionMemberLifetime {

        Boolean IRegionMemberLifetime.KeepAlive => false;

        public RelativeSource() {
            InitializeComponent();
            var loader = new AvalonEditorTextLoader();
            this.textEditor.Text = loader.GetText(Assembly.GetExecutingAssembly().GetName().Name, "02 Fundamentals", "02 ", this.GetType().Name);
        }

    }
}
