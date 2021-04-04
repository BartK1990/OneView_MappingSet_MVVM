using Microsoft.Win32;

namespace OneView_MappingSet_MVVM.UI.View.Service
{
    public class FileDialog : IFileDialog
    {
        public string OpenExcelFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel documents|*.xlsx;*.xls"; // Filter files by extension
            openFileDialog.ValidateNames = false;
            bool? result = openFileDialog.ShowDialog();
            if (result == true)
            {
                return openFileDialog.FileName;
            }
            return null;
        }
    }
}
