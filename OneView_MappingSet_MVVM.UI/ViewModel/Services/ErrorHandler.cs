using System;
using System.Collections.Generic;
using System.Text;

namespace OneView_MappingSet_MVVM.UI.ViewModel.Services
{
    public class ErrorHandler : IErrorHandler
    {
        public ICollection<string> ErrorList { get => _errorList; }
        private List<string> _errorList;

        public ErrorHandler()
        {
            _errorList = new List<string>();
        }

        public void HandleError(Exception ex)
        {
            var time = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss");
            _errorList.Add($"{time}|{ex.Message}");
        }
    }
}
