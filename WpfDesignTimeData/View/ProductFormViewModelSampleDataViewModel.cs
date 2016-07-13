namespace WpfDesignTimeData.View {
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using Wpf.Common.DataGeneration;
    using WpfDesignTimeData.Model;

    public class ProductFormViewModelSampleDataViewModel : ViewModelBase {

        IEnumerable<Brand> _brands;
        Product _product;

        public IEnumerable<Brand> Brands {
            get { return _brands; }
            set {
                _brands = value;
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
#if DEBUG
        public ProductFormViewModelSampleDataViewModel() {
            if (base.IsInDesignMode) {
                LoadDesignTimeData();
            } else {
                throw new InvalidOperationException();
            }
        }
#endif
        public ProductFormViewModelSampleDataViewModel(DataGenerator dg) {

        }

        [Conditional("DEBUG")]
        void LoadDesignTimeData() {
            var product = new Product();
            product.Name = "Lipton Black Tea  Pyramid Tea Bags Bavarian Wild Berry - 20 Ct";
            product.BrandId = 100;
            product.Cost = 2.99;
            product.DateCreated = new DateTime(2000, 1, 15);
            product.IsActive = true;
            product.ProductIdent = 19087;
            this.Product = product;

            var brands = new List<Brand>();
            brands.Add(new Brand {BrandIdent = 100, Name = "Lipton"});
            this.Brands = brands;
        }

    }
}
