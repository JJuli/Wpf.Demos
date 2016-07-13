namespace AsyncDataAccess.Presentation.Services {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using XamlDeveloper.Domain.Data;
    using XamlDeveloper.Domain.Model;

    public class AsyncDataService : IAsyncDataService {

        readonly IBusinessService _businessService;

        public AsyncDataService(IBusinessService businessService) {
            if (businessService == null) {
                throw new ArgumentNullException(nameof(businessService));
            }
            _businessService = businessService;
        }

        public IEnumerable<Brand> GetBrands() {
            EnsureDataIsLoaded();
            return _businessService.Brands;
        }

        public IList<Product> GetProducts() {
            EnsureDataIsLoaded();
            return _businessService.Products;
        }

        public IList<Product> ThrowExceptionDuringGetProducts() {
            throw new InvalidOperationException("Simulated Exception - Invalid system configuration.");
        }

        void EnsureDataIsLoaded() {
            if (_businessService.Brands == null || !_businessService.Brands.Any()) {
                _businessService.LoadData();
            }
        }

    }
}
