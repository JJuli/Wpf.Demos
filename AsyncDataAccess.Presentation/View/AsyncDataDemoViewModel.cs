namespace AsyncDataAccess.Presentation.View {
    using System;
    using System.Collections.Generic;
    using System.Windows.Input;
    using AsyncDataAccess.Presentation.Infrastructure;
    using AsyncDataAccess.Presentation.Services;
    using Prism.Regions;
    using Wpf.Common.Dialog;
    using Wpf.Common.Infrastructure;
    using XamlDeveloper.Domain.Model;

    public class AsyncDataDemoViewModel : ViewModelBase, INavigationAware {

        readonly IAsyncDataService _asyncDataService;
        IEnumerable<Brand> _brands;
        Boolean _isDataLoading;
        ICommand _loadProductsAsyncCommand;
        IList<Product> _products;
        public IEnumerable<Brand> Brands {
            get { return _brands; }
            set {
                _brands = value;
                RaisePropertyChanged();
            }
        }

        public ICommand LoadProductsAsyncCommand => _loadProductsAsyncCommand ?? (_loadProductsAsyncCommand = new RelayCommand(LoadProductsAsyncCommandExecute, CanLoadProductsAsyncCommandExecute));

        public IList<Product> Products {
            get { return _products; }
            set {
                _products = value;
                RaisePropertyChanged();
            }
        }

        public ICommand SimulateServiceExceptionCommand => new RelayCommand(SimulateServiceExceptionCommandExecute);

        public AsyncDataDemoViewModel(IAsyncDataService asyncDataService, IDialogService dialogService) : base(dialogService) {
            if (asyncDataService == null) {
                throw new ArgumentNullException(nameof(asyncDataService));
            }
            _asyncDataService = asyncDataService;
        }

        public Boolean IsNavigationTarget(NavigationContext navigationContext) {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext) {
        }

        public void OnNavigatedTo(NavigationContext navigationContext) {
            LoadBrands();
        }

        Boolean CanLoadProductsAsyncCommandExecute() {
            return !_isDataLoading;
        }

        void LoadBrands() {
            base.ExecuteMethodAsync(
                () => _asyncDataService.GetBrands(),
                results => this.Brands = results);
        }

        void LoadProducts() {
            _isDataLoading = true;
            base.ExecuteMethodAsync(
                () => _asyncDataService.GetProducts(),
                results => {
                    this.Products = results;
                    _isDataLoading = false;
                });
        }

        void LoadProductsAsyncCommandExecute() {
            if (!CanLoadProductsAsyncCommandExecute()) {
                return;
            }
            LoadProducts();
        }

        void SimulateServiceExceptionCommandExecute() {
            base.ExecuteMethodAsync(
                () => _asyncDataService.ThrowExceptionDuringGetProducts(),
                results => {
                    this.Products = results;
                    _isDataLoading = false;
                });
        }

    }
}
