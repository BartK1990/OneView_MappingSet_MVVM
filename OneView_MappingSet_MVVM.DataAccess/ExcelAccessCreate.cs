﻿using OfficeOpenXml;
using System.Threading.Tasks;

namespace OneView_MappingSet_MVVM.DataAccess
{
    public abstract class ExcelAccessCreate<T> : ExcelAccess<T>
    {
        protected T GetExcelData(ExcelPackage package)
        {
            using (package)
            {
                return ReadWriteExcelData(package);
            }
        }

        protected abstract T ReadWriteExcelData(ExcelPackage package);

        public void WriteExcelData(string path)
        {
            GetExcelData(GetExcelPackage(path));
        }
        public void WriteExcelData(ExcelPackage package)
        {
            GetExcelData(package);
        }

        public async Task WriteExcelDataAsync(string path)
        {
            await Task.Run(() => WriteExcelData(path));
        }
        public async Task WriteExcelDataAsync(ExcelPackage package)
        {
            await Task.Run(() => WriteExcelData(package));
        }  
    }
}
