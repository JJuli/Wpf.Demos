namespace XamlDeveloper {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Input;
    using System.Windows.Media;
    using Infragistics.Themes;
    using Prism.Modularity;
    using Prism.Regions;
    using Wpf.Common.Data;
    using Wpf.Common.Infrastructure;

    public class ShellViewModel : ObservableObject {

        Int32 _currentIndex;
        readonly IModuleManager _moduleManager;
        ICommand _navigateToPresentationCommand;
        ICommand _nextCommand;
        ICommand _previousCommand;
        readonly IRegionManager _regionManager;
        ThemeItem _selectedThemeItem;

        public ICommand NavigateToPresentationCommand => _navigateToPresentationCommand ?? (_navigateToPresentationCommand = new RelayCommand<Wpf.Common.Model.Presentation>(NavigateToPresentationCommandExecute));

        public ICommand NextCommand => _nextCommand ?? (_nextCommand = new RelayCommand(NextCommandExecute, CanNextCommandExecute));

        public Presentations Presentations { get; }

        public ICommand PreviousCommand => _previousCommand ?? (_previousCommand = new RelayCommand(PreviousCommandExecute, CanPreviousCommandExecute));

        public ThemeItem SelectedThemeItem {
            get { return _selectedThemeItem; }
            set {
                _selectedThemeItem = value;
                if (_selectedThemeItem != null) {
                    SetTheme(_selectedThemeItem);
                }
                RaisePropertyChanged();
            }
        }

        public IEnumerable<ThemeItem> ThemeItems { get; set; }

        public ShellViewModel(IModuleManager moduleManager, IRegionManager regionManager, Presentations presentations) {
            if (moduleManager == null) {
                throw new ArgumentNullException(nameof(moduleManager));
            }
            if (regionManager == null) {
                throw new ArgumentNullException(nameof(regionManager));
            }
            if (presentations == null) {
                throw new ArgumentNullException(nameof(presentations));
            }
            _moduleManager = moduleManager;
            _regionManager = regionManager;
            this.Presentations = presentations;
            LoadThemeItems();
            this.SelectedThemeItem = this.ThemeItems.First(x => x.Name == "Office 2010");

            _moduleManager.LoadModuleCompleted += ModuleManager_LoadModuleCompleted;
        }

        void NavigateToPresentationCommandExecute(Wpf.Common.Model.Presentation presentation) {
            var index = this.Presentations.IndexOf(presentation);
            NavigateToPresentation(index);
        }


        Boolean CanNextCommandExecute() {
            return _currentIndex < this.Presentations.Count - 1;
        }

        Boolean CanPreviousCommandExecute() {
            return _currentIndex != 0;
        }

        void LoadThemeItems() {
            Color metroDarkBackground = Colors.Black;
            var metroDarkBackgroundColorObject = ColorConverter.ConvertFromString("#FF181818");
            if (metroDarkBackgroundColorObject != null) {
                metroDarkBackground = (Color)metroDarkBackgroundColorObject;
            }

            var list = new List<ThemeItem>();
            list.Add(new ThemeItem("IG", new IgTheme(), Colors.White));
            list.Add(new ThemeItem("Metro Dark", new MetroDarkTheme(), metroDarkBackground));
            list.Add(new ThemeItem("Metro", new MetroTheme(), Colors.White));
            list.Add(new ThemeItem("Office 2010", new Office2010BlueTheme(), Colors.White));
            list.Add(new ThemeItem("Office 2013", new Office2013Theme(), Colors.White));
            this.ThemeItems = list;
        }

        void ModuleManager_LoadModuleCompleted(Object sender, LoadModuleCompletedEventArgs e) {
            if (e.ModuleInfo.ModuleName == "PresentationModule") {
                _moduleManager.LoadModuleCompleted -= ModuleManager_LoadModuleCompleted;
                NavigateToPresentation(0);
            }
        }

        void NavigateToPresentation(Int32 newIndex) {
            _regionManager.RequestNavigate(
                Constants.ContentRegionName, 
                this.Presentations[newIndex].View,
                result => {
                    if (result.Result.HasValue && result.Result.Value) {
                        _currentIndex = newIndex;
                    }
                });
            CommandManager.InvalidateRequerySuggested();
        }

        void NextCommandExecute() {
            if (CanNextCommandExecute()) {
                NavigateToPresentation(_currentIndex + 1);
            }
        }

        void PreviousCommandExecute() {
            if (CanPreviousCommandExecute()) {
                NavigateToPresentation(_currentIndex - 1);
            }
        }

        void SetTheme(ThemeItem themeItem) {
            ThemeManager.ApplicationTheme = themeItem.Theme;
        }

    }
}
