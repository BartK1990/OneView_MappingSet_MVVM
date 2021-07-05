using System.Windows;
using System.Windows.Controls;

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
