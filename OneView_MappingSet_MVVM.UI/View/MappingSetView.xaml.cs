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
        }

        private void LogConsole_PreviewDragOver(object sender, DragEventArgs e)
        {
            e.Handled = true;
        }

        private void LogConsole_PreviewDragEnter(object sender, DragEventArgs e)
        {
            LogConsole.Background = FindResource("BlockBackgroundDropColor") as SolidColorBrush;
        }

        private void LogConsole_PreviewDragLeave(object sender, DragEventArgs e)
        {
            LogConsole.Background = FindResource("BlockBackgroundColor") as SolidColorBrush;
        }
    }
}
