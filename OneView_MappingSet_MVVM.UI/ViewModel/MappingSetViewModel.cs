using System.Windows.Input;
using OneView_MappingSet_MVVM.DataAccess;

namespace OneView_MappingSet_MVVM.UI.ViewModel
{
    using View.Service;
    

    public class MappingSetViewModel : ViewModelBase
    {
        private IFileDialog _fileDialog;
        private string _filePath;

        public MappingSetViewModel(IFileDialog fileDialog)
        {
            this._fileDialog = fileDialog;
        }

        private ICommand _openExcelFileCommand;
        public ICommand OpenExcelFileCommand
        {
            get
            {
                return _openExcelFileCommand ?? (_openExcelFileCommand = new RelayCommand(
                           x =>
                           {
                               var filePath = _fileDialog.OpenExcelFile();
                               if (!string.IsNullOrEmpty(filePath))
                               {
                                   _filePath = filePath;
                               }
                               var acc = new StandardMappingSetExcelAccess();
                               acc.GetSheetData(filePath, "SCI Standard Mappingset");
                           }, x => true));
            }
        }
    }
}
