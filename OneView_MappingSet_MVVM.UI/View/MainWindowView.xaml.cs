using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
            mappingSetView.DataContext = new ViewModel.MappingSetViewModel(curApp.FileDialog, curApp.StandardMappingSetRepository, curApp.ErrorHandler);

            //Only one view for now
            WindowContent.Navigate(mappingSetView);

            
        }
    }
}
