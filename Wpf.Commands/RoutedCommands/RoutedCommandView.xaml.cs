using System.Windows.Controls;

namespace Wpf.Commands.RoutedCommands {
    using System;
    using System.Reflection;
    using Wpf.Common.Infrastructure;

    public partial class RoutedCommandView : UserControl {
        public RoutedCommandView() {
            InitializeComponent();
            var loader = new AvalonEditorTextLoader();
            this.textEditor.Text = loader.GetText(Assembly.GetExecutingAssembly().GetName().Name, "RoutedCommands", String.Empty, this.GetType().Name);

        }
    }
}
