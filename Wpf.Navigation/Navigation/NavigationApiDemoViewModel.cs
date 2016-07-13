namespace Wpf.Navigation.Navigation {
    using System;
    using System.Windows.Input;
    using Prism.Regions;
    using Wpf.Common.Infrastructure;

    public class NavigationApiDemoViewModel : ObservableObject, IRegionMemberLifetime {

        ICommand _navigateCommand;
        readonly IRegionManager _regionManager;

        Boolean IRegionMemberLifetime.KeepAlive => false;

        public ICommand NavigateCommand => _navigateCommand ?? (_navigateCommand = new RelayCommand<String>(NavigateExecute));

        public NavigationApiDemoViewModel(IRegionManager regionManager) {
            if (regionManager == null) {
                throw new ArgumentNullException(nameof(regionManager));
            }
            _regionManager = regionManager;
        }

        void NavigateExecute(String id) {
            this.NavigateRequest(
                Constants.NavigationModuleContentRegionName,
                typeof(DataFormView).FullName,
                new[,] {{"ID", id}});
        }

        void NavigateRequest(String regionName, String target, String[,] parms) {
            _regionManager.Regions[regionName].RequestNavigate(new Uri(QueryStringBuilder.Construct(target, parms), UriKind.Relative));
        }

    }
}
