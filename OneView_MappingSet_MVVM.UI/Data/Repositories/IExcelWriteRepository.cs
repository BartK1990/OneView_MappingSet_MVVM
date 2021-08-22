using System.Threading.Tasks;

namespace OneView_MappingSet_MVVM.UI.Data.Repositories
{
    public interface IExcelWriteRepository<TData>
    {
        Task WriteDataAsync(string path, TData data);
    }
}