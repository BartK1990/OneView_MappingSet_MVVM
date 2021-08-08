using System.Threading.Tasks;

namespace OneView_MappingSet_MVVM.UI.Data.Repositories
{
    public interface IExcelWriteRepository
    {
        Task WriteDataAsync(string path);
    }
}