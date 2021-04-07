using System.Windows.Input;
using System;

namespace OneView_MappingSet_MVVM.UI.ViewModel
{
    using View.Service;
    using Data.Repositories;
    using System.Threading.Tasks;

    public class MappingSetViewModel : ViewModelBase
    {
        private readonly IStandardTagListRepository _standardMappingSetRepository;
        private readonly IFileDialog _fileDialog;

        private bool standardTagListLoading;
        public bool StandardTagListLoading
        {
            get => this.standardTagListLoading;
            set { this.SetAndNotify(ref this.standardTagListLoading, value, () => this.StandardTagListLoading); }
        }
        private string logOutput;
        public string LogOutput
        {
            get => this.logOutput;
            set { this.SetAndNotify(ref this.logOutput, value, () => this.LogOutput); }
        }
       
        public MappingSetViewModel(IFileDialog fileDialog, IStandardTagListRepository standardMappingSetRepository)
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
                            OpenExcelFileHelperAsync(filePath);
                        }
                    }, x => true));
            }
        }

        private async void OpenExcelFileHelperAsync(string path)
        {
            StandardTagListLoading = true;
            try
            {
                await _standardMappingSetRepository.GetDataAsync(path);
            }
            catch (Exception e)
            {
                LogOutput = e.Message;
            }
            StandardTagListLoading = false;
        }
    }
}
