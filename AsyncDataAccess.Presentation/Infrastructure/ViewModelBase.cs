namespace AsyncDataAccess.Presentation.Infrastructure {
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Threading;
    using Wpf.Common.Dialog;
    using Wpf.Common.Infrastructure;

    //==========================================================================================
    //
    //  THIS IS PROTOTYPE CODE - DO NOT USE THIS IN PRODUCTION
    //
    //  MANY MORE CONSIDERATIONS NEED TO BE ACCOUNTED FOR
    //
    //==========================================================================================

    public abstract class ViewModelBase : ObservableObject {

        protected IDialogService DialogService { get; }

        protected Dispatcher Dispatcher => Application.Current != null ? Application.Current.MainWindow.Dispatcher : Dispatcher.CurrentDispatcher;

        protected ViewModelBase(IDialogService dialogService) {
            if (dialogService == null) {
                throw new ArgumentNullException(nameof(dialogService));
            }
            this.DialogService = dialogService;
        }

        /// <summary>
        /// Executes method synchronously.
        /// </summary>
        /// <typeparam name="T">T: type of object the method returns.</typeparam>
        /// <param name="method">The method to execute asynchronously.</param>
        /// <param name="resultCallback">The result callback which contains the return value of the repository method.</param>
        /// <param name="errorCallback">The error callback which contains the exception that occurred in the repository.</param>
        /// <exception cref="ArgumentNullException">The repository method is null.</exception>
        /// <exception cref="ArgumentNullException">The result callback is null.</exception>
        /// <remarks>This method signature is used in the Save methods of views to allow executing synchronously if the view or application is closing.</remarks>
        protected void ExecuteMethod<T>(Func<T> method, Action<T> resultCallback, Action<Exception> errorCallback = null) {
            if (method == null) {
                throw new ArgumentNullException(nameof(method));
            }
            if (resultCallback == null) {
                throw new ArgumentNullException(nameof(resultCallback));
            }

            //this.SetIsBusy(IsBusyOption.ShowImmediate);

            try {
                resultCallback(method());

                //this.SetIsBusy(IsBusyOption.Hide);
            } catch (Exception ex) {
                //this.SetIsBusy(IsBusyOption.Hide);
                var baseException = ex.GetBaseException();
                if (errorCallback != null) {
                    errorCallback(baseException);
                } else {
                    this.DialogService.ShowExceptionDialog("Exception", baseException.Message);
                }
            }
        }

        /// <summary>
        /// Executes method synchronously.
        /// </summary>
        /// <param name="method">The method to execute asynchronously.</param>
        /// <param name="resultCallback">The result callback which contains the return value of the repository method.</param>
        /// <param name="errorCallback">The error callback which contains the exception that occurred in the repository.</param>
        /// <exception cref="ArgumentNullException">The repository method is null.</exception>
        /// <exception cref="ArgumentNullException">The result callback is null.</exception>
        /// <remarks>This method signature is used in the Save methods of views to allow executing synchronously if the view or application is closing.</remarks>
        protected void ExecuteMethod(Action method, Action resultCallback, Action<Exception> errorCallback = null) {
            if (method == null) {
                throw new ArgumentNullException(nameof(method));
            }
            if (resultCallback == null) {
                throw new ArgumentNullException(nameof(resultCallback));
            }

            //this.SetIsBusy(IsBusyOption.ShowImmediate);

            try {
                method();
                resultCallback();

                //this.SetIsBusy(IsBusyOption.Hide);
            } catch (Exception ex) {
                //this.SetIsBusy(IsBusyOption.Hide);
                var baseException = ex.GetBaseException();
                if (errorCallback != null) {
                    errorCallback(baseException);
                } else {
                    this.DialogService.ShowExceptionDialog("Exception", baseException.Message);
                }
            }
        }

        /// <summary>
        /// Executes the method within the context of a Task. 
        /// </summary>
        /// <typeparam name="T">T: type of object the method returns.</typeparam>
        /// <param name="method">The method to execute asynchronously.</param>
        /// <param name="resultCallback">The result callback which contains the return value of the repository method.</param>
        /// <param name="errorCallback">The error callback which contains the exception that occurred in the repository.</param>
        /// <exception cref="ArgumentNullException">The repository method is null.</exception>
        /// <exception cref="ArgumentNullException">The result callback is null.</exception>
        protected void ExecuteMethodAsync<T>(Func<T> method, Action<T> resultCallback, Action<Exception> errorCallback = null) {
            if (method == null) {
                throw new ArgumentNullException(nameof(method));
            }
            if (resultCallback == null) {
                throw new ArgumentNullException(nameof(resultCallback));
            }

            //this.SetIsBusy(IsBusyOption.ShowImmediate);

            try {
                var task = Task.Factory.StartNew(method);
                task.ContinueWith(antecedent => {
                    //this.SetIsBusy(IsBusyOption.Hide);
                    if (antecedent.IsFaulted && antecedent.Exception != null) {
                        var baseException = antecedent.Exception.Flatten().GetBaseException();
                        if (errorCallback == null) {
                            this.DialogService.ShowExceptionDialog("Exception", baseException.Message);
                        } else {
                            errorCallback(baseException);
                        }
                    } else {
                        resultCallback(antecedent.Result);
                    }
                }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
            } catch (AggregateException ae) {
                //this.SetIsBusy(IsBusyOption.Hide);
                if (errorCallback == null) {
                    this.DialogService.ShowExceptionDialog("Exception", ae.Flatten().GetBaseException().Message);
                } else {
                    errorCallback(ae.Flatten().GetBaseException());
                }
            } catch (Exception ex) {
                //this.SetIsBusy(IsBusyOption.Hide);
                if (errorCallback == null) {
                    this.DialogService.ShowExceptionDialog("Exception", ex.GetBaseException().Message);
                } else {
                    errorCallback(ex);
                }
            }
        }

        /// <summary>
        /// Executes the method within the context of a Task.
        /// </summary>
        /// <param name="method">The method to execute asynchronously.</param>
        /// <param name="resultCallback">The result callback which contains the return value of the repository method.</param>
        /// <param name="errorCallback">The error callback which contains the exception that occurred in the repository.</param>
        /// <exception cref="ArgumentNullException">The repository method is null.</exception>
        /// <exception cref="ArgumentNullException">The result callback is null.</exception>
        /// <exception cref="ArgumentNullException">The error callback is null.</exception>
        protected void ExecuteMethodAsync(Action method, Action resultCallback, Action<Exception> errorCallback = null) {
            if (method == null) {
                throw new ArgumentNullException(nameof(method));
            }
            if (resultCallback == null) {
                throw new ArgumentNullException(nameof(resultCallback));
            }

            //this.SetIsBusy(IsBusyOption.ShowImmediate);

            try {
                var task = Task.Factory.StartNew(method);
                task.ContinueWith(antecedent => {
                    //this.SetIsBusy(IsBusyOption.Hide);
                    if (antecedent.IsFaulted && antecedent.Exception != null) {
                        var baseException = antecedent.Exception.Flatten().GetBaseException();
                        if (errorCallback == null) {
                            this.DialogService.ShowExceptionDialog("Exception", baseException.Message);
                        } else {
                            errorCallback(baseException);
                        }
                    } else {
                        resultCallback();
                    }
                }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
            } catch (AggregateException ae) {
                //this.SetIsBusy(IsBusyOption.Hide);
                if (errorCallback == null) {
                    this.DialogService.ShowExceptionDialog("Exception", ae.Flatten().GetBaseException().Message);
                } else {
                    errorCallback(ae.Flatten().GetBaseException());
                }
            } catch (Exception ex) {
                //this.SetIsBusy(IsBusyOption.Hide);
                if (errorCallback == null) {
                    this.DialogService.ShowExceptionDialog("Exception", ex.GetBaseException().Message);
                } else {
                    errorCallback(ex.GetBaseException());
                }
            }
        }

        protected void PostToDispatcher(Action action, DispatcherPriority priority = DispatcherPriority.Background) {
            this.Dispatcher.BeginInvoke(action, priority);
        }

    }
}
