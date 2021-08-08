using OfficeOpenXml;
using System.IO;

namespace OneView_MappingSet_MVVM.DataAccess
{
    public abstract class ExcelAccess<T>
    {
        protected T GetExcelPackage(string path, FileMode fileMode, FileAccess fileAccess, FileShare fileShare)
        {
            FileInfo fileInfo = new FileInfo(path);
            using (ExcelPackage package = new ExcelPackage(fileInfo))
            {             
                return ReadWriteExcelData(package);
            }
        }

        protected abstract T ReadWriteExcelData(ExcelPackage package);
    }
}
