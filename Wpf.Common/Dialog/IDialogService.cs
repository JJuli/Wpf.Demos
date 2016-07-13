namespace Wpf.Common.Dialog {
    using System;

    public interface IDialogService {

        DialogResult ConfirmDialog(String caption, String message);

        void ShowExceptionDialog(String caption, String message);

    }
}