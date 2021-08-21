using OfficeOpenXml;
using System.IO;

namespace OneView_MappingSet_MVVM.DataAccess
{
    public abstract class ExcelAccess<T>
    {
        protected ExcelPackage GetExcelPackage(string path)
        {
            FileInfo fileInfo = new FileInfo(path);
            return new ExcelPackage(fileInfo);
        }
    }
}
