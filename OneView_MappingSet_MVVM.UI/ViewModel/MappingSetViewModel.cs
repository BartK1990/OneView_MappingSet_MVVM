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
    using OneView_MappingSet_MVVM.Model;
    using OneView_MappingSet_MVVM.UI.Data.Services;

    public class MappingSetViewModel : ViewModelBase, IFileDragDropTarget
    {
        private readonly IExcelFileDialog _fileDialog;
        private readonly IErrorHandler _errorHandler;
        private readonly IMappingSetGeneratorService _mappingSetGeneratorService;
        private readonly IStandardTagListRepository _standardTagListRepository;
        private readonly IExcelSheetNameRepository _excelSheetNameRepository;

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

        private bool _sourceItemDictionaryLoading;
        public bool SourceItemDictionaryLoading
        {
            get => this._sourceItemDictionaryLoading;
            set { this.SetAndNotify(ref this._sourceItemDictionaryLoading, value, () => this.SourceItemDictionaryLoading); }
        }
        private string _sourceItemDictionaryPath;
        public string SourceItemDictionaryPath
        {
            get => this._sourceItemDictionaryPath;
            set { this.SetAndNotify(ref this._sourceItemDictionaryPath, value, () => this.SourceItemDictionaryPath); }
        }

        private bool _sourceItemListLoading;
        public bool SourceItemListLoading
        {
            get => this._sourceItemListLoading;
            set { this.SetAndNotify(ref this._sourceItemListLoading, value, () => this.SourceItemListLoading); }
        }
        private string _sourceItemListPath;
        public string SourceItemListPath
        {
            get => this._sourceItemListPath;
            set { this.SetAndNotify(ref this._sourceItemListPath, value, () => this.SourceItemListPath); }
        }

        private bool _processMappingSetLoading;
        public bool ProcessMappingSetLoading
        {
            get => this._processMappingSetLoading;
            set { this.SetAndNotify(ref this._processMappingSetLoading, value, () => this.ProcessMappingSetLoading); }
        }

        private bool _dragAndDropFilesLoading;
        public bool DragAndDropFilesLoading
        {
            get => this._dragAndDropFilesLoading;
            set { this.SetAndNotify(ref this._dragAndDropFilesLoading, value, () => this.DragAndDropFilesLoading); }
        }

        public MappingSetViewModel(IExcelFileDialog fileDialog, IErrorHandler errorHandler
            , IMappingSetGeneratorService mappingSetGeneratorService
            , IStandardTagListRepository standardMappingSetRepository
            , IExcelSheetNameRepository excelSheetNameRepository)
        {
            this._fileDialog = fileDialog;
            this._errorHandler = errorHandler;
            this._errorHandler.NewError += LogNewError;
            this._standardTagListRepository = standardMappingSetRepository;
            this._excelSheetNameRepository = excelSheetNameRepository;
            this._mappingSetGeneratorService = mappingSetGeneratorService;

            // Commands
            OpenStandardTagListCommand = new AsyncCommand(OnOpenStandardTagList, OnOpenStandardTagListCanExecute, this._errorHandler);
            GetStandardTagListCommand = new AsyncCommand<string>(execute: OnGetStandardTagList, errorHandler: this._errorHandler);
            OpenSourceItemDictionaryCommand = new AsyncCommand(OnOpenSourceItemDictionary, OnOpenSourceItemDictionaryCanExecute, this._errorHandler);
            OpenSourceItemListCommand = new AsyncCommand(OnOpenSourceItemList, OnOpenSourceItemListCanExecute, this._errorHandler);
            ProcessMappingSetCommand = new AsyncCommand(OnProcessMappingSet, OnProcessMappingSetCanExecute, this._errorHandler);
            DragAndDropFilesCommand = new AsyncCommand<string[]>(OnDragAndDropFiles, OnDragAndDropFilesCanExecute, this._errorHandler);
        }
        
        public IAsyncCommand OpenStandardTagListCommand { get; private set; }
        private async Task OnOpenStandardTagList()
        {
            var filePath = _fileDialog.OpenExcelFile();
            if (!string.IsNullOrEmpty(filePath))
            {
                await GetStandardTagListCommand.ExecuteAsync(filePath);
            }
        }
        private bool OnOpenStandardTagListCanExecute()
        {
            return true;
        }
        public IAsyncCommand<string> GetStandardTagListCommand { get; private set; }
        private async Task OnGetStandardTagList(string filePath)
        {
            try
            {
                StandardTagListLoading = true;
                StandardTagListPath = filePath;
                await _standardTagListRepository.GetDataAsync(filePath);
                Log("Standard mapping set Loaded");
            }
            finally
            {
                StandardTagListLoading = false;
            }
        }

        public IAsyncCommand OpenSourceItemDictionaryCommand { get; private set; }
        private async Task OnOpenSourceItemDictionary()
        {
            try
            {
                var filePath = _fileDialog.OpenExcelFile();
                if (!string.IsNullOrEmpty(filePath))
                {
                    SourceItemDictionaryLoading = true;
                    await Task.Delay(3000); // just for test
                    Log("Nothing interesting happend :-P");
                    //await _standardMappingSetRepository.GetDataAsync(filePath);
                    //Log("Source item dictionary Loaded");
                }
            }
            finally
            {
                SourceItemDictionaryLoading = false;
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
                    SourceItemListLoading = true;
                    await Task.Delay(3000); // just for test
                    Log("Nothing interesting happend :-)");
                    //await _standardMappingSetRepository.GetDataAsync(filePath);
                    //Log("Source item list Loaded");
                }
            }
            finally
            {
                SourceItemListLoading = false;
            }
        }
        private bool OnOpenSourceItemListCanExecute()
        {
            return true;
        }

        public async Task OnFileDropAsync(string[] filepaths)
        {
            await DragAndDropFilesCommand.ExecuteAsync(filepaths);
        }
        public IAsyncCommand<string[]> DragAndDropFilesCommand { get; private set; }
        private async Task OnDragAndDropFiles(string[] filepaths)
        {
            try
            {
                DragAndDropFilesLoading = true;
                foreach (var fp in filepaths)
                {
                    Log($"New file dropped: {fp}");
                    var esn = await _excelSheetNameRepository.GetDataAsync(fp);
                    var excelFileType = await _mappingSetGeneratorService.GetExcelFileTypeAsync(esn.SheetCollection);
                    Log($"Excel file type: {excelFileType}");
                    switch (excelFileType)
                    {
                        case ExcelFileType.StandardTagList:
                            await GetStandardTagListCommand.ExecuteAsync(fp);
                            break;

                        default:
                            break;
                    }
                }
                await Task.Delay(3000); // just for test
                Log("All dropped files processed");
                //await _standardMappingSetRepository.GetDataAsync(filePath);
                //Log("Source item list Loaded");
            }
            finally
            {
                DragAndDropFilesLoading = false;
            }
        }
        private bool OnDragAndDropFilesCanExecute()
        {
            // TODO: execution is possible only when all other files are correctly loaded
            return true;
        }

        public IAsyncCommand ProcessMappingSetCommand { get; private set; }
        private async Task OnProcessMappingSet()
        {
            try
            {
                ProcessMappingSetLoading = true;
                await Task.Delay(3000); // just for test
                Log("Nothing interesting happend :-D");
                //await _standardMappingSetRepository.GetDataAsync(filePath);
                //Log("Source item list Loaded");
            }
            finally
            {
                ProcessMappingSetLoading = false;
            }
        }
        private bool OnProcessMappingSetCanExecute()
        {
            // TODO: execution is possible only when all other files are correctly loaded
            return true;
        }

        private void Log(string log)
        {
            var time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var logStr = $"{time} | {log}";
            LoggerItems.Add(logStr);
            LoggerText += $"{logStr}{Environment.NewLine}";
        }

        private void LogNewError(object sender, NewErrorEventArgs e)
        {
            Log(e.errorMessage);
        }

    }
}
