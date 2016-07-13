namespace Wpf.Common.Infrastructure {
    using System;
    using System.IO;
    using System.Reflection;

    public class AvalonEditorTextLoader {

        public AvalonEditorTextLoader() {
        }

        public String GetText(String executingAssemblyName, String targetFileFolder, String targetFilePrefix, String typeName) {
            var entryAssemblyPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            if (entryAssemblyPath != null) {
                var fileName = Path.Combine(entryAssemblyPath, "Source", executingAssemblyName, targetFileFolder, $"{targetFilePrefix}{typeName}.xaml");
                var fileText = File.ReadAllText(fileName);
                var endOfRootControl = fileText.IndexOf(">", StringComparison.Ordinal);
                return fileText.Substring(endOfRootControl + 1).Replace("</UserControl>", String.Empty);
            }
            return String.Empty;
        }

    }
}
