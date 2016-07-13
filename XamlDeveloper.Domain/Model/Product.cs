namespace XamlDeveloper.Domain.Model {
    using System;

    public class Product : DomainBase {

        Int32 _brandId;
        Int32 _categoryId;
        Double _cost;
        Boolean _isActive = true;
        String _name = String.Empty;
        Int32 _productIdent;

        public Boolean IsDirty { get; set; }
        
        public Int32 BrandId {
            get { return _brandId; }
            set {
                _brandId = value;
                RaisePropertyChanged();
                this.IsDirty = true;
            }
        }

        public Int32 CategoryId {
            get { return _categoryId; }
            set {
                _categoryId = value;
                RaisePropertyChanged();
                this.IsDirty = true;
            }
        }

        public Double Cost {
            get { return _cost; }
            set {
                _cost = value;
                RaisePropertyChanged();
                this.IsDirty = true;
            }
        }

        public Boolean IsActive {
            get { return _isActive; }
            set {
                _isActive = value;
                RaisePropertyChanged();
                this.IsDirty = true;
            }
        }

        public String Name {
            get { return _name; }
            set {
                _name = value;
                RaisePropertyChanged();
                this.IsDirty = true;
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
