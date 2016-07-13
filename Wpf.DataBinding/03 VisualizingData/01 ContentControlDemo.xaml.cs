namespace Wpf.DataBinding.VisualizingData {
    using System;
    using System.Reflection;
    using System.Windows.Controls;
    using Prism.Regions;
    using Wpf.Common.Infrastructure;

    public partial class ContentControlDemo : UserControl, IRegionMemberLifetime {

        Boolean IRegionMemberLifetime.KeepAlive => false;

        public ContentControlDemo() {
            InitializeComponent();
            var loader = new AvalonEditorTextLoader();
            this.textEditor.Text = loader.GetText(Assembly.GetExecutingAssembly().GetName().Name, "03 VisualizingData", "01 ", this.GetType().Name);

        }

    }
}
