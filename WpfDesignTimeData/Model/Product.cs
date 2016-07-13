namespace WpfDesignTimeData.Model {
    using System;

    public class Product : BindableBase {

        Int32 _brandId;
        Double _cost;
        DateTime _dateCreated;
        Boolean _isActive = true;
        String _name = String.Empty;
        Int32 _productIdent;

        public Int32 BrandId {
            get { return _brandId; }
            set {
                _brandId = value;
                RaisePropertyChanged();
            }
        }

        public Double Cost {
            get { return _cost; }
            set {
                _cost = value;
                RaisePropertyChanged();
            }
        }

        public DateTime DateCreated {
            get { return _dateCreated; }
            set {
                _dateCreated = value;
                RaisePropertyChanged();
            }
        }

        public Boolean IsActive {
            get { return _isActive; }
            set {
                _isActive = value;
                RaisePropertyChanged();
            }
        }

        public String Name {
            get { return _name; }
            set {
                _name = value;
                RaisePropertyChanged();
            }
        }

        public Int32 ProductIdent {
            get { return _productIdent; }
            set {
                _productIdent = value;
                RaisePropertyChanged();
            }
        }

        public Product() {
        }

    }
}
