namespace Wpf.Common.Infrastructure {
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Wpf.Common.Dialog;

    public class ParallelTaskInvoker {

        readonly IDialogService _dialogService;

        public ParallelTaskInvoker(IDialogService dialogService) {
            if (dialogService == null) {
                throw new ArgumentNullException(nameof(dialogService));
            }
            _dialogService = dialogService;
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
        public void ExecuteMethod<T>(Func<T> method, Action<T> resultCallback, Action<Exception> errorCallback = null) {
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
                    _dialogService.ShowExceptionDialog("Exception", baseException.Message);
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
        public void ExecuteMethod(Action method, Action resultCallback, Action<Exception> errorCallback = null) {
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
                    _dialogService.ShowExceptionDialog("Exception", baseException.Message);
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
        public void ExecuteMethodAsync<T>(Func<T> method, Action<T> resultCallback, Action<Exception> errorCallback = null) {
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
                            _dialogService.ShowExceptionDialog("Exception", baseException.Message);
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
                    _dialogService.ShowExceptionDialog("Exception", ae.Flatten().GetBaseException().Message);
                } else {
                    errorCallback(ae.Flatten().GetBaseException());
                }
            } catch (Exception ex) {
                //this.SetIsBusy(IsBusyOption.Hide);
                if (errorCallback == null) {
                    _dialogService.ShowExceptionDialog("Exception", ex.GetBaseException().Message);
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
        public void ExecuteMethodAsync(Action method, Action resultCallback, Action<Exception> errorCallback = null) {
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
                            _dialogService.ShowExceptionDialog("Exception", baseException.Message);
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
                    _dialogService.ShowExceptionDialog("Exception", ae.Flatten().GetBaseException().Message);
                } else {
                    errorCallback(ae.Flatten().GetBaseException());
                }
            } catch (Exception ex) {
                //this.SetIsBusy(IsBusyOption.Hide);
                if (errorCallback == null) {
                    _dialogService.ShowExceptionDialog("Exception", ex.GetBaseException().Message);
                } else {
                    errorCallback(ex.GetBaseException());
                }
            }
        }

    }
}
