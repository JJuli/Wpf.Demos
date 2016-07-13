namespace Wpf.DataBinding.VisualizingData {
    using System;
    using System.Reflection;
    using System.Windows.Controls;
    using Prism.Regions;
    using Wpf.Common.Infrastructure;

    public partial class ItemsControlDemo : UserControl, IRegionMemberLifetime {

        Boolean IRegionMemberLifetime.KeepAlive => false;

        public ItemsControlDemo() {
            InitializeComponent();
            var loader = new AvalonEditorTextLoader();
            this.textEditor.Text = loader.GetText(Assembly.GetExecutingAssembly().GetName().Name, "03 VisualizingData", "02 ", this.GetType().Name);

        }

    }
}
