namespace Wpf.Navigation.Navigation {
    using System;
    using System.Reflection;
    using System.Windows.Controls;
    using Microsoft.Practices.Unity;
    using Wpf.Common.Infrastructure;

    public partial class NavigationApiDemoView : UserControl {

        [Dependency]
        public NavigationApiDemoViewModel NavigationApiDemoViewModel {
            get { return this.DataContext as NavigationApiDemoViewModel; }
            set { this.DataContext = value; }
        }

        public NavigationApiDemoView() {
            InitializeComponent();
            var loader = new AvalonEditorTextLoader();
            this.textEditor.Text = loader.GetText(Assembly.GetExecutingAssembly().GetName().Name, "Navigation", String.Empty, this.GetType().Name);

        }

    }
}
