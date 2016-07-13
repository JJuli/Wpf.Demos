namespace XamlDeveloper.Presentation.View {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Input;
    using Prism.Regions;
    using Wpf.Common.Dialog;
    using Wpf.Common.Infrastructure;
    using XamlDeveloper.Domain.Data;
    using XamlDeveloper.Domain.Model;

    public class XamlMVVMDemoCodeViewModel : ObservableObject, IConfirmNavigationRequest {

        IEnumerable<Brand> _brands;
        readonly IBusinessService _businessService;
        IEnumerable<Category> _categories;
        readonly IDialogService _dialogService;
        ICommand _editProductCommand;
        Boolean _isNameFocused;
        Product _product;
        IList<SearchResult> _searchResults;
        String _searchText = String.Empty;
        Brand _selectedBrand;
        Category _selectedCategory;

        public IEnumerable<Brand> Brands {
            get { return _brands; }
            set {
                _brands = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<Category> Categories {
            get { return _categories; }
            set {
                _categories = value;
                RaisePropertyChanged();
            }
        }

        public ICommand EditProductCommand => _editProductCommand ?? (_editProductCommand = new RelayCommand<SearchResult>(EditProductCommandExecute));

        public Boolean IsNameFocused {
            get { return _isNameFocused; }
            set {
                _isNameFocused = value;
                RaisePropertyChanged();
            }
        }

        public Product Product {
            get { return _product; }
            set {
                _product = value;
                RaisePropertyChanged();
            }
        }

        public IList<SearchResult> SearchResults {
            get { return _searchResults; }
            set {
                _searchResults = value;
                RaisePropertyChanged();
            }
        }

        public String SearchText {
            get { return _searchText; }
            set {
                _searchText = value;
                RaisePropertyChanged();
                ExecuteSearch();
            }
        }

        public Brand SelectedBrand {
            get { return _selectedBrand; }
            set {
                _selectedBrand = value;
                RaisePropertyChanged();
                ExecuteSearch();
            }
        }

        public Category SelectedCategory {
            get { return _selectedCategory; }
            set {
                _selectedCategory = value;
                RaisePropertyChanged();
                ExecuteSearch();
            }
        }

        public XamlMVVMDemoCodeViewModel(IBusinessService businessService, 
            IDialogService dialogService) {
            if (businessService == null) {
                throw new ArgumentNullException(nameof(businessService));
            }
            if (dialogService == null) {
                throw new ArgumentNullException(nameof(dialogService));
            }
            _businessService = businessService;
            _dialogService = dialogService;
        }

        public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<Boolean> continuationCallback) {
            if (this.Product == null || !this.Product.IsDirty) {
                continuationCallback(true);
            } else {
                var result = _dialogService.ConfirmDialog("Unsaved Data", "Are you sure you want to navigate away, the form has unsaved data.");
                continuationCallback(result == DialogResult.Yes);
            }
        }

        public Boolean IsNavigationTarget(NavigationContext navigationContext) {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext) {
        }

        public void OnNavigatedTo(NavigationContext navigationContext) {
            LoadData();
        }

        void EditProductCommandExecute(SearchResult searchResult) {
            if (searchResult == null) {
                return;
            }
            var product = _businessService.Products.SingleOrDefault(p => p.ProductIdent == searchResult.ProductIdent);
            if (product != null) {
                product.IsDirty = false;
                this.Product = product;
                this.Product.IsDirty = false;
                if (this.IsNameFocused) {
                    this.IsNameFocused = false;
                }
                this.IsNameFocused = true;
            }
        }

        void ExecuteSearch() {
            if (String.IsNullOrWhiteSpace(this.SearchText)) {
                this.SearchResults = null;
                return;
            }
            this.SearchResults = _businessService.AllSearchResults.Where(
                p => p.Name.IndexOf(this.SearchText, StringComparison.OrdinalIgnoreCase) > -1 &&
                     (this.SelectedBrand.BrandIdent == 0 || p.BrandId == this.SelectedBrand.BrandIdent) &&
                     (this.SelectedCategory.CategoryIdent == 0 || p.CategoryId == this.SelectedCategory.CategoryIdent)).ToList();
        }

        void LoadData() {
            var brands = _businessService.Brands.ToList();
            brands.Insert(0, new Brand {Name = "All Brands"});
            this.Brands = brands;
            this.SelectedBrand = brands[0];

            var categories = _businessService.Categories.ToList();
            categories.Insert(0, new Category {Name = "All Categories"});
            this.Categories = categories;
            this.SelectedCategory = categories[0];
        }

    }
}
