namespace XamlDeveloper.Presentation.View {
    using System;
    using System.Windows;
    using System.Windows.Threading;
    using Prism.Regions;
    using XamlDeveloper.Domain.Data;

    public class IntroductionViewModel : INavigationAware {

        readonly IBusinessService _businessService;
        Boolean _dataLoaded;

        Dispatcher Dispatcher => Application.Current != null ? Application.Current.MainWindow.Dispatcher : Dispatcher.CurrentDispatcher;

        public IntroductionViewModel(IBusinessService businessService) {
            if (businessService == null) {
                throw new ArgumentNullException(nameof(businessService));
            }
            _businessService = businessService;
        }

        public Boolean IsNavigationTarget(NavigationContext navigationContext) {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext) {
        }

        public void OnNavigatedTo(NavigationContext navigationContext) {
            if (!_dataLoaded) {
                LoadData();
            }
        }

        void LoadData() {
            _dataLoaded = true;
            this.Dispatcher.BeginInvoke(new Action(() => {
                _businessService.LoadData();
            }), DispatcherPriority.Loaded);
        }

    }
}
