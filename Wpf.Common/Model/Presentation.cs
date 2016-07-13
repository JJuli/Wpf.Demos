namespace Wpf.Common.Model {
    using System;

    public class Presentation {

        public String Name { get; }

        public String View { get; }

        public Presentation(String name, String view) {
            if (String.IsNullOrWhiteSpace(view)) {
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(view));
            }
            if (String.IsNullOrWhiteSpace(name)) {
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(name));
            }
            this.Name = name;
            this.View = view;
        }

    }
}
