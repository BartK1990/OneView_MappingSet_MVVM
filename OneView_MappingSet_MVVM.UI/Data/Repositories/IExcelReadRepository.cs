using System.Threading.Tasks;

namespace OneView_MappingSet_MVVM.UI.Data.Repositories
{
    public interface IExcelReadRepository<TData>
    {
        Task<TData> ReadDataAsync(string path);
    }
}