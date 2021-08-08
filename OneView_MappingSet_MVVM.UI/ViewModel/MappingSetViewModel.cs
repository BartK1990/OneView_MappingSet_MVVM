using OneView_MappingSet_MVVM.Model;
using OneView_MappingSet_MVVM.UI.Data.Repositories;
using OneView_MappingSet_MVVM.UI.Data.Services;
using OneView_MappingSet_MVVM.UI.Event;
using OneView_MappingSet_MVVM.UI.View.Helpers;
using OneView_MappingSet_MVVM.UI.View.Services;
using OneView_MappingSet_MVVM.UI.ViewModel.Commands;
using OneView_MappingSet_MVVM.UI.ViewModel.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace OneView_MappingSet_MVVM.UI.ViewModel
{
    public class MappingSetViewModel : ViewModelBase, IFileDragDropTarget
    {
        private readonly IExcelFileDialog _fileDialog;
        private readonly IErrorHandler _errorHandler;
        private readonly IMappingSetGeneratorService _mappingSetGeneratorService;
        private readonly IStandardTagListReadRepository _standardTagListRepository;
        private readonly ISourceItemDictionaryReadRepository _sourceItemDictionaryRepository;
        private readonly ISourceItemListReadRepository _sourceItemListRepository;
        private readonly ISourceItemListWriteRepository _sourceItemListWriteRepository;
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
        private bool _sourceItemListCreating;
        public bool SourceItemListCreating
        {
            get => this._sourceItemListCreating;
            set { this.SetAndNotify(ref this._sourceItemListCreating, value, () => this.SourceItemListCreating); }
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
            , IStandardTagListReadRepository standardMappingSetRepository
            , ISourceItemDictionaryReadRepository sourceItemDictionaryRepository
            , ISourceItemListReadRepository sourceItemListRepository
            , ISourceItemListWriteRepository sourceItemListWriteRepository
            , IExcelSheetNameRepository excelSheetNameRepository
            )
        {
            this._fileDialog = fileDialog;
            this._errorHandler = errorHandler;
            this._errorHandler.NewError += LogNewError;
            this._standardTagListRepository = standardMappingSetRepository;
            this._sourceItemDictionaryRepository = sourceItemDictionaryRepository;
            this._sourceItemListRepository = sourceItemListRepository;
            this._sourceItemListWriteRepository = sourceItemListWriteRepository;
            this._excelSheetNameRepository = excelSheetNameRepository;
            this._mappingSetGeneratorService = mappingSetGeneratorService;

            // Commands
            OpenStandardTagListCommand = new AsyncCommand(OnOpenStandardTagList, OnOpenStandardTagListCanExecute, this._errorHandler);
            GetStandardTagListCommand = new AsyncCommand<string>(execute: OnGetStandardTagList, errorHandler: this._errorHandler);
            OpenSourceItemDictionaryCommand = new AsyncCommand(OnOpenSourceItemDictionary, OnOpenSourceItemDictionaryCanExecute, this._errorHandler);
            GetSourceItemDictionaryCommand = new AsyncCommand<string>(execute: OnGetSourceItemDictionary, errorHandler: this._errorHandler);
            OpenSourceItemListCommand = new AsyncCommand(OnOpenSourceItemList, OnOpenSourceItemListCanExecute, this._errorHandler);
            GetSourceItemListCommand = new AsyncCommand<string>(execute: OnGetSourceItemList, errorHandler: this._errorHandler);

            CreateSourceItemListCommand = new AsyncCommand(OnCreateSourceItemList, OnCreateSourceItemListCanExecute, this._errorHandler);

            ProcessMappingSetCommand = new AsyncCommand(OnProcessMappingSet, OnProcessMappingSetCanExecute, this._errorHandler);

            DragAndDropFilesCommand = new AsyncCommand<string[]>(OnDragAndDropFiles, OnDragAndDropFilesCanExecute, this._errorHandler);
        }

        #region StandardTagList commands
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
                var standardTagList = await _standardTagListRepository.ReadDataAsync(filePath);
                Log("Standard mapping set loaded");

            }
            catch
            {
                Log($"Standard mapping set loading error");
                throw;
            }
            finally
            {
                StandardTagListLoading = false;
            }
        }
        #endregion

        #region SourceItemDictionary commands
        public IAsyncCommand OpenSourceItemDictionaryCommand { get; private set; }
        private async Task OnOpenSourceItemDictionary()
        {
            var filePath = _fileDialog.OpenExcelFile();
            if (!string.IsNullOrEmpty(filePath))
            {
                await GetSourceItemDictionaryCommand.ExecuteAsync(filePath);
            }
        }
        private bool OnOpenSourceItemDictionaryCanExecute()
        {
            return true;
        }
        public IAsyncCommand<string> GetSourceItemDictionaryCommand { get; private set; }
        private async Task OnGetSourceItemDictionary(string filePath)
        {
            try
            {
                SourceItemDictionaryLoading = true;
                SourceItemDictionaryPath = filePath;
                var sourceItemDictionary = await _sourceItemDictionaryRepository.ReadDataAsync(filePath);
                Log("Source item dictionary loaded");

            }
            catch
            {
                Log($"Source item dictionary loading error");
                throw;
            }
            finally
            {
                SourceItemDictionaryLoading = false;
            }
        }
        #endregion

        #region SourceItemList commands
        public IAsyncCommand OpenSourceItemListCommand { get; private set; }
        private async Task OnOpenSourceItemList()
        {
            var filePath = _fileDialog.OpenExcelFile();
            if (!string.IsNullOrEmpty(filePath))
            {
                await GetSourceItemListCommand.ExecuteAsync(filePath);
            }
        }
        private bool OnOpenSourceItemListCanExecute()
        {
            return true;
        }
        public IAsyncCommand<string> GetSourceItemListCommand { get; private set; }
        private async Task OnGetSourceItemList(string filePath)
        {
            try
            {
                SourceItemListLoading = true;
                SourceItemListPath = filePath;
                var sourceItemList = await _sourceItemListRepository.ReadDataAsync(filePath);
                Log("Source item list loaded");

            }
            catch
            {
                Log($"Source item list loading error");
                throw;
            }
            finally
            {
                SourceItemListLoading = false;
            }
        }

        public IAsyncCommand CreateSourceItemListCommand { get; private set; }
        private async Task OnCreateSourceItemList()
        {
            try
            {
                SourceItemListCreating = true;
                var filePath = _fileDialog.SaveExcelFile();
                if (!string.IsNullOrEmpty(filePath))
                {
                    await _sourceItemListWriteRepository.WriteDataAsync(filePath);
                }
                Log($"Source item list template created: {filePath}");
            }
            finally
            {
                SourceItemListCreating = false;
            }
        }
        private bool OnCreateSourceItemListCanExecute()
        {
            return true;
        }
        #endregion

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
                var tasks = new List<Task>();
                foreach (var fp in filepaths)
                {
                    Log($"New file dropped: {fp}");
                    var esn = await _excelSheetNameRepository.ReadDataAsync(fp);
                    var excelFileType = await _mappingSetGeneratorService.GetExcelFileTypeAsync(esn.SheetCollection);
                    Log($"Excel file type: {excelFileType}");
                    switch (excelFileType)
                    {
                        case ExcelFileType.StandardTagList:
                            tasks.Add(GetStandardTagListCommand.ExecuteAsync(fp));
                            break;
                        case ExcelFileType.SourceDictionary:
                            tasks.Add(GetSourceItemDictionaryCommand.ExecuteAsync(fp));
                            break;
                        case ExcelFileType.SourceList:
                            tasks.Add(GetSourceItemListCommand.ExecuteAsync(fp));
                            break;
                        default:
                            break;
                    }
                }
                await Task.WhenAll(tasks);
                Log("All dropped files processed");
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
