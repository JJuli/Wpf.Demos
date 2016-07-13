namespace WpfDesignTimeData.SampleData {
    using System;
    using System.Collections.Generic;
    using Wpf.Common.DataGeneration;
    using WpfDesignTimeData.Model;

    internal class FakeProductGridFormFakeViewModelSampleDataViewModel {

        public IEnumerable<Brand> Brands { get; }

        public IList<Product> Products { get; }

        public FakeProductGridFormFakeViewModelSampleDataViewModel() {
            var dg = new DataGenerator();
            dg.SeedSequentialInteger(100, 1);

            var brands = new List<Brand>();
            for (var i = 0; i < 5; i++) {
                brands.Add(new Brand {BrandIdent = dg.GetSequentialInteger(), Name = dg.GetString(15)});
            }
            this.Brands = brands;

            var list = new List<Product>();
            dg.SeedSequentialInteger(1000, 1);

            for (var i = 0; i < 50; i++) {
                list.Add(new Product {
                    BrandId = dg.GetInteger(100, 105),
                    ProductIdent = dg.GetSequentialInteger(),
                    IsActive = dg.GetBoolean(),
                    DateCreated = dg.GetDate(new DateTime(2000, 1, 1), DateTime.Now),
                    Name = dg.GetString(60)
                });
            }

            this.Products = list;
        }

    }
}
