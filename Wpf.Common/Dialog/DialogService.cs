namespace Wpf.Common.Dialog {
    using System;
    using System.Windows;

    // DEMO ONLY - DO NOT IMPLEMENT DIALOGS LIKE THIS IN A PRODUCTION APPLICATION

    public class DialogService : IDialogService {

        public DialogResult ConfirmDialog(String caption, String message) {
            var result = MessageBox.Show(message, caption, MessageBoxButton.YesNoCancel, MessageBoxImage.Exclamation);
            switch (result) {
                case MessageBoxResult.Yes:
                    return DialogResult.Yes;
                case MessageBoxResult.No:
                    return DialogResult.No;
                default:
                    return DialogResult.Cancel;
            }
        }

        public void ShowExceptionDialog(String caption, String message) {
            MessageBox.Show(message, caption, MessageBoxButton.OK, MessageBoxImage.Error);
        }

    }

    // DEMO ONLY - DO NOT IMPLEMENT DIALOGS LIKE THIS IN A PRODUCTION APPLICATION
}
