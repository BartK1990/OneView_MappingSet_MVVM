﻿using System;
using System.Windows.Input;

namespace OneView_MappingSet_MVVM.UI.ViewModel
{
    using Commands;
    using Data.Repositories;
    using ViewModel.Services;
    using View.Services;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;

    public class MappingSetViewModel : ViewModelBase
    {
        private readonly IStandardTagListRepository _standardMappingSetRepository;
        private readonly IFileDialog _fileDialog;
        private readonly IErrorHandler _errorHandler;

        public ObservableCollection<string> LoggerItems { get; set; } = new ObservableCollection<string>();

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
       
        public MappingSetViewModel(IFileDialog fileDialog, IStandardTagListRepository standardMappingSetRepository, IErrorHandler errorHandler)
        {
            this._standardMappingSetRepository = standardMappingSetRepository;
            this._fileDialog = fileDialog;
            this._errorHandler = errorHandler;
            //this.LoggerItems = (ObservableCollection<string>)this._errorHandler.ErrorList;

            // Commands
            OpenExcelFileCommand = new AsyncCommand(OnOpenExcelFile, OnOpenExcelFileCanExecute);
        }
        public IAsyncCommand OpenExcelFileCommand { get; private set; }
        private async Task OnOpenExcelFile()
        {
            try
            {
                var filePath = _fileDialog.OpenExcelFile();
                if (!string.IsNullOrEmpty(filePath))
                {
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
        private bool OnOpenExcelFileCanExecute()
        {
            return true;
        }

        private void Log(string log)
        {
            var time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            LoggerItems.Add($"{time}|{log}");
        }
    }
}
