using OfficeOpenXml;
using System.Threading.Tasks;

namespace OneView_MappingSet_MVVM.DataAccess
{
    public abstract class ExcelAccessCreate<T> : ExcelAccess<T>
    {
        protected abstract void PutExcelData(ExcelPackage package, T data);

        protected void PutExcelDataUsingWrapper(ExcelPackage package, T data)
        {
            using (package)
            {
                PutExcelData(package, data);
            }
        }

        public void WriteExcelData(string path, T data)
        {
            PutExcelDataUsingWrapper(GetExcelPackage(path), data);
        }
        public void WriteExcelData(ExcelPackage package, T data)
        {
            PutExcelDataUsingWrapper(package, data);
        }

        public async Task WriteExcelDataAsync(string path, T data)
        {
            await Task.Run(() => WriteExcelData(path, data));
        }
        public async Task WriteExcelDataAsync(ExcelPackage package, T data)
        {
            await Task.Run(() => WriteExcelData(package, data));
        }  
    }
}
