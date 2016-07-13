namespace XamlDeveloper {
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Media;
    using Microsoft.Practices.Unity;
    using Prism.Modularity;

    public partial class ShellView : Window {

        [Dependency]
        public IModuleManager ModuleManager { get; set; }

        [Dependency]
        public ShellViewModel ShellViewModel {
            get { return this.DataContext as ShellViewModel; }
            set { this.DataContext = value; }
        }

        public ShellView() {
            InitializeComponent();
            this.Loaded += ShellView_Loaded;
        }

        void CreateContextMenu() {
            var contextMenu = new ContextMenu();

            foreach (var presentation in this.ShellViewModel.Presentations) {
                var item = new MenuItem();
                item.Header = presentation.Name;

                var b = new Binding("NavigateToPresentationCommand");
                b.Source = this.ShellViewModel;
                
                item.SetBinding(MenuItem.CommandProperty, b);
                item.CommandParameter = presentation;
                contextMenu.Items.Add(item);
            }

            this.RootContainer.ContextMenu = contextMenu;
        }

        void ModuleManager_LoadModuleCompleted(object sender, LoadModuleCompletedEventArgs e) {
            if (e.ModuleInfo.ModuleName == "PresentationModule") {
                this.ModuleManager.LoadModuleCompleted -= ModuleManager_LoadModuleCompleted;
                CreateContextMenu();
            }
        }

        void ShellView_Loaded(Object sender, RoutedEventArgs e) {
            this.ShellViewModel.PropertyChanged += Vm_PropertyChanged;
            this.NextButton.Focus();
            this.ModuleManager.LoadModuleCompleted += ModuleManager_LoadModuleCompleted;
        }

        void Vm_PropertyChanged(Object sender, System.ComponentModel.PropertyChangedEventArgs e) {
            if (e.PropertyName == "SelectedThemeItem") {
                if (this.ShellViewModel.SelectedThemeItem != null) {
                    this.RootContainer.Background = new SolidColorBrush(this.ShellViewModel.SelectedThemeItem.BackgroundColor);
                }
            }
        }

    }
}
