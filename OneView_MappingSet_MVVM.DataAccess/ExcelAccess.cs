using OfficeOpenXml;
using System.IO;

namespace OneView_MappingSet_MVVM.DataAccess
{
    public abstract class ExcelAccess<T>
    {
        protected T GetExcelPackage(string path, FileMode fileMode, FileAccess fileAccess, FileShare fileShare)
        {
            using (Stream stream = System.IO.File.Open(path, fileMode, fileAccess, fileShare))
            {
                using (ExcelPackage package = new ExcelPackage(stream))
                {             
                    return ReadWriteExcelData(package);
                }
            }
        }

        protected abstract T ReadWriteExcelData(ExcelPackage package);

    }
}
