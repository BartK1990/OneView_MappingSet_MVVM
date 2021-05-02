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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OneView_MappingSet_MVVM.UI.View
{
    /// <summary>
    /// Interaction logic for MappingSetView.xaml
    /// </summary>
    public partial class MappingSetView : Page
    {
        public MappingSetView()
        {
            InitializeComponent();
            LogConsoleDropGrid.Visibility = Visibility.Hidden;
        }

        private void LogConsole_PreviewDragEnter(object sender, DragEventArgs e)
        {
            LogConsoleDropGrid.Visibility = Visibility.Visible;
        }

        private void LogConsoleDropRect_DragLeave(object sender, DragEventArgs e)
        {
            LogConsoleDropGrid.Visibility = Visibility.Hidden;
        }

        private void LogConsoleDropRect_Drop(object sender, DragEventArgs e)
        {
            LogConsoleDropGrid.Visibility = Visibility.Hidden;
        }
    }
}
