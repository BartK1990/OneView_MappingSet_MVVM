using System.Windows.Input;
using OneView_MappingSet_MVVM.DataAccess;

namespace OneView_MappingSet_MVVM.UI.ViewModel
{
    using View.Service;
    using Data.Repositories;

    public class MappingSetViewModel : ViewModelBase
    {
        private IStandardMappingSetRepository _standardMappingSetRepository;
        private IFileDialog _fileDialog;
        private string _filePath;

        private bool fileLoading;
        public bool FileLoading
        {
            get => this.fileLoading;
            set { this.SetAndNotify(ref this.fileLoading, value, () => this.FileLoading); }
        }

        public MappingSetViewModel(IFileDialog fileDialog, IStandardMappingSetRepository standardMappingSetRepository)
        {
            this._standardMappingSetRepository = standardMappingSetRepository;
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
                               OpenExcelFileHelperAsync(filePath);
                           }, x => true));
            }
        }

        private async void OpenExcelFileHelperAsync(string path)
        {
            FileLoading = true;
            await _standardMappingSetRepository.GetDataAsync(path);
            FileLoading = false;
        }
    }
}
