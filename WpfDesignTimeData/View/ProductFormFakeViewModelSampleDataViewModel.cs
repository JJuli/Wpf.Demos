namespace WpfDesignTimeData.View {
    using System.Collections.Generic;
    using WpfDesignTimeData.Model;

    public class ProductFormFakeViewModelSampleDataViewModel : BindableBase {

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

        public ProductFormFakeViewModelSampleDataViewModel() {
        }

    }
}
