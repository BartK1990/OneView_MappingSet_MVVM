using OneView_MappingSet_MVVM.Model;
using System.Threading.Tasks;

namespace OneView_MappingSet_MVVM.UI.Data.Repositories
{
    public interface IStandardMappingSetRepository
    {
        Task<StandardMappingSet> GetDataAsync(string path);
    }
}