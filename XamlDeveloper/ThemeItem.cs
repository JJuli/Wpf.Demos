namespace XamlDeveloper {
    using System;
    using System.Windows.Media;
    using Infragistics.Themes;

    public class ThemeItem {

        public Color BackgroundColor { get; }

        public String Name { get; }

        public ThemeBase Theme { get; }

        public ThemeItem(String name, ThemeBase theme, Color backgroundColor) {
            this.Name = name;
            this.Theme = theme;
            this.BackgroundColor = backgroundColor;
        }

    }
}
