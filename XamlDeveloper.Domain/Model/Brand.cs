namespace XamlDeveloper.Domain.Model {
    using System;

    public class Brand : DomainBase {

        Int32 _brandIdent;
        String _name;

        public Int32 BrandIdent {
            get { return _brandIdent; }
            set {
                _brandIdent = value;
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

        public Brand() {
        }

    }
}
