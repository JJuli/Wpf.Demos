namespace XamlDeveloper.Presentation.View {
    using System;
    using System.Collections.Generic;
    using XamlDeveloper.Domain.Data;
    using XamlDeveloper.Domain.Model;

    public class XamlIsThemeableViewModel : BindableBase {

        readonly IBusinessService _businessService;

        public IEnumerable<String> Activities { get; }

        public Int32 ActivityRating { get; set; } = 90;

        public DateTime Birthday { get; set; } = new DateTime(1960, 11, 24);

        public IEnumerable<Brand> Brands => _businessService.Brands;

        public IEnumerable<Category> Categories => _businessService.Categories;

        public FinancialDataCollection FinancialDataCollection => _businessService.FinancialDataCollection;

        public String Name { get; set; } = "Tim Smith";

        public IList<Product> Products => _businessService.Products;

        public IEnumerable<Season> Seasons => _businessService.Seasons;

        public XamlIsThemeableViewModel(IBusinessService businessService) {
            if (businessService == null) {
                throw new ArgumentNullException(nameof(businessService));
            }
            _businessService = businessService;
            this.Activities = new List<String> {"Baseball", "Motorcycle Riding", "Mountain Climbing"};
        }

    }
}
