using System;
using System.Threading.Tasks;

namespace OneView_MappingSet_MVVM.UI.Data.Repositories
{
    public class ExcelRepositoryOfT<TData, TExcelAccess> : IExcelRepositoryOfT<TData>
        where TData : class
        where TExcelAccess : class
    {
        protected readonly TExcelAccess ExcelAccess;

        public ExcelRepositoryOfT(TExcelAccess excelAccess)
        {
            this.ExcelAccess = excelAccess;
        }

        public virtual Task<TData> GetDataAsync(string path)
        {
            throw new NotImplementedException();
        }
    }
}
