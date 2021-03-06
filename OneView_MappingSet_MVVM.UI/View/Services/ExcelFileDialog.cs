using Microsoft.Win32;

namespace OneView_MappingSet_MVVM.UI.View.Services
{
    public class ExcelFileDialog : IExcelFileDialog
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

        public string SaveExcelFile()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel documents|*.xlsx;*.xls"; // Filter files by extension
            saveFileDialog.ValidateNames = false;
            bool? result = saveFileDialog.ShowDialog();
            if (result == true)
            {
                return saveFileDialog.FileName;
            }
            return null;
        }
    }
}
