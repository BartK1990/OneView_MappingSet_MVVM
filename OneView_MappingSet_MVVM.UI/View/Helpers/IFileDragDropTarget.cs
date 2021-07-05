using System.Threading.Tasks;

namespace OneView_MappingSet_MVVM.UI.View.Helpers
{
    public interface IFileDragDropTarget
    {
        //void OnFileDrop(string[] filepaths);
        Task OnFileDropAsync(string[] filepaths);
    }
}
