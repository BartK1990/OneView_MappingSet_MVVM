using OneView_MappingSet_MVVM.DataAccess;

namespace OneView_MappingSet_MVVM.UI.Data.Repositories
{
    public abstract class ExcelRepository<TData, TExcelAccess> : IExcelRepository
        where TData : class
        where TExcelAccess : ExcelAccess<TData>
    {
        protected readonly TExcelAccess ExcelAccess;

        public ExcelRepository(TExcelAccess excelAccess)
        {
            this.ExcelAccess = excelAccess;
        }
    }
}
