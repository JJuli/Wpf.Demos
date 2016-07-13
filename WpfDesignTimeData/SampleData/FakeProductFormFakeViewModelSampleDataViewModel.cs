namespace WpfDesignTimeData.SampleData {
    using System;
    using System.Collections.Generic;
    using WpfDesignTimeData.Model;

    internal class FakeProductFormFakeViewModelSampleDataViewModel {

        public IEnumerable<Brand> Brands { get; }

        public Product Product { get; }

        public FakeProductFormFakeViewModelSampleDataViewModel() {
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
