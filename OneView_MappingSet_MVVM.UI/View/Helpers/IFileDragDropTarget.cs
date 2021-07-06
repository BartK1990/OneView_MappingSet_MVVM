using System.Threading.Tasks;

namespace OneView_MappingSet_MVVM.UI.View.Helpers
{
    public interface IFileDragDropTarget
    {
        Task OnFileDropAsync(string[] filepaths);
    }
}
