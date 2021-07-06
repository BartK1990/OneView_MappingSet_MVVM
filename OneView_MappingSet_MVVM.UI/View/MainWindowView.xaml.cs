﻿using System.Windows;

namespace OneView_MappingSet_MVVM.UI.View
{
    public partial class MainWindowView : Window
    {
        private readonly MappingSetView mappingSetView;
        private readonly App curApp;

        public MainWindowView()
        {
            InitializeComponent();

            // Reference for this application
            curApp = (App)Application.Current;

            // Initialize views for Window
            mappingSetView = new MappingSetView();

            // Initialize ViewModel and assign to DataContext for window/page
            mappingSetView.DataContext = new ViewModel.MappingSetViewModel(fileDialog: curApp.FileDialog
                , errorHandler: curApp.ErrorHandler
                , standardMappingSetRepository: curApp.StandardMappingSetRepository
                , excelSheetNameRepository: curApp.ExcelSheetNameRepository);

            //Only one view for now
            WindowContent.Navigate(mappingSetView);

            
        }
    }
}
