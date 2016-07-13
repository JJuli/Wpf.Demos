namespace XamlDeveloper.Domain.Data {
    using System.Collections.Generic;
    using XamlDeveloper.Domain.Model;

    public interface IBusinessService {

        IList<SearchResult> AllSearchResults { get; }

        IList<Brand> Brands { get; }

        IList<Category> Categories { get; }

        FinancialDataCollection FinancialDataCollection { get; }

        IList<Product> Products { get; }

        IList<Season> Seasons { get; }

        void LoadData();

    }
}
