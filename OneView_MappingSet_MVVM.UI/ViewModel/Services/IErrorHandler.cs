using System;
using System.Collections;
using System.Collections.Generic;

namespace OneView_MappingSet_MVVM.UI.ViewModel.Services
{
    using Event;

    public interface IErrorHandler
    {
        public event NewErrorEventHandler NewError;
        ICollection<string> ErrorList { get; }

        void HandleError(Exception ex);
    }
}
