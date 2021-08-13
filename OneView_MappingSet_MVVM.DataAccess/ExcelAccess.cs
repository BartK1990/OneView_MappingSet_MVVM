using OfficeOpenXml;
using System.IO;

namespace OneView_MappingSet_MVVM.DataAccess
{
    public abstract class ExcelAccess<T>
    {
        protected T GetExcelData(ExcelPackage package)
        {
            using (package)
            {             
                return ReadWriteExcelData(package);
            }
        }

        protected ExcelPackage GetExcelPackage(string path)
        {
            FileInfo fileInfo = new FileInfo(path);
            return new ExcelPackage(fileInfo);
        }

        protected abstract T ReadWriteExcelData(ExcelPackage package);
    }
}
