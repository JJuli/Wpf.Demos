namespace Wpf.Navigation.Navigation {
    using System;
    using Prism.Regions;
    using Wpf.Common.Infrastructure;
    using Wpf.Navigation.Services;

    public class DataFormViewModel : ObservableObject, IConfirmNavigationRequest, IRegionMemberLifetime {

        Boolean _confirmNavigation;
        readonly IDialogService _dialogService;
        String _id;
        Boolean _keepMeAlive;
        String _queryString;
        String _timeLoaded;

        public Boolean ConfirmNavigation {
            get { return _confirmNavigation; }
            set {
                _confirmNavigation = value;
                RaisePropertyChanged();
            }
        }

        public String Id {
            get { return _id; }
            private set {
                _id = value;
                RaisePropertyChanged();
            }
        }

        Boolean IRegionMemberLifetime.KeepAlive => _keepMeAlive;

        public Boolean KeepMeAlive {
            get { return _keepMeAlive; }
            set {
                _keepMeAlive = value;
                RaisePropertyChanged();
            }
        }

        public String QueryString {
            get { return _queryString; }
            set {
                _queryString = value;
                RaisePropertyChanged();
            }
        }

        public String TimeLoaded {
            get { return _timeLoaded; }
            set {
                _timeLoaded = value;
                RaisePropertyChanged();
            }
        }

        public DataFormViewModel(IDialogService dialogService) {
            if (dialogService == null) {
                throw new ArgumentNullException(nameof(dialogService));
            }
            _dialogService = dialogService;
            this.TimeLoaded = DateTime.Now.ToLongTimeString();
        }

        public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<Boolean> continuationCallback) {
            var allowNavigation = true;
            if (_confirmNavigation) {
                allowNavigation = _dialogService.ShowMessage("OK to navigate away", "", DialogButton.OKCancel, DialogImage.Question) == DialogResponse.OK;
            }
            continuationCallback(allowNavigation);
        }

        public Boolean IsNavigationTarget(NavigationContext navigationContext) {
            if (navigationContext.Parameters["ID"] != null) {
                return this.Id == navigationContext.Parameters["ID"].ToString();
            }
            return false;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext) {
        }

        public void OnNavigatedTo(NavigationContext navigationContext) {
            this.QueryString = navigationContext.Uri.ToString();
            if (navigationContext.Parameters["ID"] != null) {
                this.Id = navigationContext.Parameters["ID"].ToString();
            }
        }

    }
}
