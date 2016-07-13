namespace AsyncDataAccess.Presentation.Services {
    using System.Collections.Generic;
    using XamlDeveloper.Domain.Model;

    public interface IAsyncDataService {

        IEnumerable<Brand> GetBrands();

        IList<Product> GetProducts();

        IList<Product> ThrowExceptionDuringGetProducts();

    }
}
