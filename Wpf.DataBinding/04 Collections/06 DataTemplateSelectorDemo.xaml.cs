namespace Wpf.DataBinding.Collections {
    using System;
    using System.Reflection;
    using System.Windows.Controls;
    using Prism.Regions;
    using Wpf.Common.Infrastructure;

    public partial class DataTemplateSelectorDemo : UserControl, IRegionMemberLifetime {

        Boolean IRegionMemberLifetime.KeepAlive => false;

        public DataTemplateSelectorDemo() {
            InitializeComponent();
            var loader = new AvalonEditorTextLoader();
            this.textEditor.Text = loader.GetText(Assembly.GetExecutingAssembly().GetName().Name, "04 Collections", "06 ", this.GetType().Name);

        }

    }
}
