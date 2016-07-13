namespace WpfDesignTimeData.View {
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using WpfDesignTimeData.Model;

    public class ProductXamDataGridViewModelSampleDataViewModel : ViewModelBase {

        IEnumerable<Brand> _brands;
        IList<Product> _products;

        public IEnumerable<Brand> Brands {
            get { return _brands; }
            set {
                _brands = value;
                RaisePropertyChanged();
            }
        }

        public IList<Product> Products {
            get { return _products; }
            set {
                _products = value;
                RaisePropertyChanged();
            }
        }

        public ProductXamDataGridViewModelSampleDataViewModel() {
            if (base.IsInDesignMode) {
                LoadDesignTimeData();
            }
        }

        [Conditional("DEBUG")]
        void LoadDesignTimeData() {
            var products = new List<Product>();
            var product = new Product();
            product.Name = "Lipton Black Tea  Pyramid Tea Bags Bavarian Wild Berry - 20 Ct";
            product.BrandId = 100;
            product.Cost = 2.99;
            product.DateCreated = new DateTime(2000, 1, 15);
            product.IsActive = true;
            product.ProductIdent = 19087;
            products.Add(product);

            product = new Product();
            product.Name = "Lipton Green Tea Pyramid Tea Bags Bavarian Cherry - 20 Ct";
            product.BrandId = 100;
            product.Cost = 3.50;
            product.DateCreated = new DateTime(2002, 11, 1);
            product.IsActive = true;
            product.ProductIdent = 25439;
            products.Add(product);
            this.Products = products;

            var brands = new List<Brand>();
            brands.Add(new Brand {BrandIdent = 100, Name = "Lipton"});
            this.Brands = brands;
        }

    }
}
