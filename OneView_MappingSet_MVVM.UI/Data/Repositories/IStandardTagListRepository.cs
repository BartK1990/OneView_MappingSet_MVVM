using OneView_MappingSet_MVVM.Model;
using System.Threading.Tasks;

namespace OneView_MappingSet_MVVM.UI.Data.Repositories
{
    public interface IStandardTagListRepository
    {
        Task<StandardTagList> GetDataAsync(string path);
    }
}