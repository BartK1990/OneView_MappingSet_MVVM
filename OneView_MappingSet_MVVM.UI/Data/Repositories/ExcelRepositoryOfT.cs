using System;
using System.Threading.Tasks;

namespace OneView_MappingSet_MVVM.UI.Data.Repositories
{
    using OneView_MappingSet_MVVM.DataAccess;

    public class ExcelRepository<TData, TExcelAccess> : IExcelRepository<TData>
        where TData : class
        where TExcelAccess : ExcelAccess<TData>
    {
        protected readonly TExcelAccess ExcelAccess;

        public ExcelRepository(TExcelAccess excelAccess)
        {
            this.ExcelAccess = excelAccess;
        }

        public virtual Task<TData> GetDataAsync(string path)
        {
            throw new NotImplementedException();
        }
    }
}
