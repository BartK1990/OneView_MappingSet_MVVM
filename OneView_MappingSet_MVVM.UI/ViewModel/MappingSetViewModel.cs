using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace OneView_MappingSet_MVVM.UI.ViewModel
{
    using Commands;
    using Data.Repositories;
    using Event;
    using View.Services;
    using View.Helpers;
    using ViewModel.Services;

    public class MappingSetViewModel : ViewModelBase, IFileDragDropTarget
    {
        private readonly IStandardTagListRepository _standardMappingSetRepository;
        private readonly IFileDialog _fileDialog;
        private readonly IErrorHandler _errorHandler;

        public ObservableCollection<string> LoggerItems { get; private set; } = new ObservableCollection<string>();

        private string _loggerText;
        public string LoggerText
        {
            get => this._loggerText;
            set { this.SetAndNotify(ref this._loggerText, value, () => this.LoggerText); }
        }

        private bool _standardTagListLoading;
        public bool StandardTagListLoading
        {
            get => this._standardTagListLoading;
            set { this.SetAndNotify(ref this._standardTagListLoading, value, () => this.StandardTagListLoading); }
        }
        private string _standardTagListPath;
        public string StandardTagListPath
        {
            get => this._standardTagListPath;
            set { this.SetAndNotify(ref this._standardTagListPath, value, () => this.StandardTagListPath); }
        }
        
        public MappingSetViewModel(IFileDialog fileDialog, IStandardTagListRepository standardMappingSetRepository, IErrorHandler errorHandler)
        {
            this._standardMappingSetRepository = standardMappingSetRepository;
            this._fileDialog = fileDialog;
            this._errorHandler = errorHandler;
            this._errorHandler.NewError += LogNewError;

            // Commands
            OpenStandardTagListCommand = new AsyncCommand(OnOpenStandardTagList, OnOpenStandardTagListCanExecute, this._errorHandler);
            OpenSourceItemDictionaryCommand = new AsyncCommand(OnOpenSourceItemDictionary, OnOpenSourceItemDictionaryCanExecute, this._errorHandler);
            OpenSourceItemListCommand = new AsyncCommand(OnOpenSourceItemList, OnOpenSourceItemListCanExecute, this._errorHandler);
        }

        public IAsyncCommand OpenStandardTagListCommand { get; private set; }
        private async Task OnOpenStandardTagList()
        {
            try
            {
                var filePath = _fileDialog.OpenExcelFile();
                if (!string.IsNullOrEmpty(filePath))
                {
                    StandardTagListPath = filePath;
                    StandardTagListLoading = true;
                    await _standardMappingSetRepository.GetDataAsync(filePath);
                    Log("Standard mapping set Loaded");
                }
            }
            finally
            {
                StandardTagListLoading = false;
            }
        }
        private bool OnOpenStandardTagListCanExecute()
        {
            return true;
        }

        public IAsyncCommand OpenSourceItemDictionaryCommand { get; private set; }
        private async Task OnOpenSourceItemDictionary()
        {
            try
            {
                var filePath = _fileDialog.OpenExcelFile();
                if (!string.IsNullOrEmpty(filePath))
                {
                    StandardTagListLoading = true;
                    await _standardMappingSetRepository.GetDataAsync(filePath);
                    Log("Source item dictionary Loaded");
                }
            }
            finally
            {
                StandardTagListLoading = false;
            }
        }
        private bool OnOpenSourceItemDictionaryCanExecute()
        {
            return true;
        }

        public IAsyncCommand OpenSourceItemListCommand { get; private set; }
        private async Task OnOpenSourceItemList()
        {
            try
            {
                var filePath = _fileDialog.OpenExcelFile();
                if (!string.IsNullOrEmpty(filePath))
                {
                    StandardTagListLoading = true;
                    await _standardMappingSetRepository.GetDataAsync(filePath);
                    Log("Source item list Loaded");
                }
            }
            finally
            {
                StandardTagListLoading = false;
            }
        }
        private bool OnOpenSourceItemListCanExecute()
        {
            return true;
        }

        private void Log(string log)
        {
            var time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            LoggerItems.Add($"{time}|{log}");
            LoggerText += $"{time}|{log}{Environment.NewLine}";
        }

        private void LogNewError(object sender, NewErrorEventArgs e)
        {
            Log(e.errorMessage);
        }

        public void OnFileDrop(string[] filepaths)
        {
            foreach (var fp in filepaths)
            {
                Log(fp);
            }
        }
    }
}
