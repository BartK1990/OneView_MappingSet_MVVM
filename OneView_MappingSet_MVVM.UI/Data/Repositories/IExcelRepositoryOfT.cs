using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OneView_MappingSet_MVVM.UI.Data.Repositories
{
    public interface IExcelRepository<T>
    {
        Task<T> GetDataAsync(string path);
    }
}
