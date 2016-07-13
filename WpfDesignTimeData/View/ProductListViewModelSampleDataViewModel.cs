namespace WpfDesignTimeData.View {
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using Wpf.Common.DataGeneration;
    using WpfDesignTimeData.Model;

    public class ProductListViewModelSampleDataViewModel : ViewModelBase {

        IList<Product> _products;

        public IList<Product> Products {
            get { return _products; }
            set {
                _products = value;
                RaisePropertyChanged();
            }
        }

        public ProductListViewModelSampleDataViewModel() {
            if (base.IsInDesignMode) {
                LoadDesignTimeData();
            }
        }

        [Conditional("DEBUG")]
        void LoadDesignTimeData() {
            var dg = new DataGenerator();
            dg.SeedSequentialInteger(1000, 1);
            var products = new List<Product>();

            for (int i = 0; i < 50; i++) {
                var p = new Product();
                p.Name = dg.GetString(50);
                p.BrandId = 100;
                p.Cost = dg.GetDouble(1, 50);
                p.DateCreated = dg.GetDate(new DateTime(2000, 1, 1), DateTime.Now);
                p.IsActive = dg.GetBoolean();
                p.ProductIdent = dg.GetSequentialInteger();
                products.Add(p);
            }



            //var product = new Product();
            //product.Name = "Lipton Black Tea  Pyramid Tea Bags Bavarian Wild Berry - 20 Ct";
            //product.BrandId = 100;
            //product.Cost = 2.99;
            //product.DateCreated = new DateTime(2000, 1, 15);
            //product.IsActive = true;
            //product.ProductIdent = 19087;
            //products.Add(product);

            //product = new Product();
            //product.Name = "Lipton Green Tea Pyramid Tea Bags Bavarian Cherry - 20 Ct";
            //product.BrandId = 100;
            //product.Cost = 3.50;
            //product.DateCreated = new DateTime(2002, 11, 1);
            //product.IsActive = true;
            //product.ProductIdent = 25439;
            //products.Add(product);
            this.Products = products;
        }

    }
}
