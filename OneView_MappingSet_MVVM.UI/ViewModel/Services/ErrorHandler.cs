using System;
using System.Collections.Generic;
using System.Text;

namespace OneView_MappingSet_MVVM.UI.ViewModel.Services
{
    using Event;

    public class ErrorHandler : IErrorHandler
    {
        public event NewErrorEventHandler NewError;

        public ICollection<string> ErrorList { get => _errorList; }
        private List<string> _errorList;

        public ErrorHandler()
        {
            _errorList = new List<string>();
        }

        protected virtual void OnNewError(NewErrorEventArgs ea)
        {
            NewErrorEventHandler handler = NewError;
            handler?.Invoke(this, ea);
        }

        public void HandleError(Exception ex)
        {
            // Rising evenet with proper args
            NewErrorEventArgs args = new NewErrorEventArgs();
            args.errorMessage = ex.Message;
            OnNewError(args);

            // Adding messages to list
            _errorList.Add(ex.Message);
        }
    }
}
