using System;
using System.Collections.Generic;
using System.Text;

namespace OneView_MappingSet_MVVM.UI.View.Helpers
{
    public interface IFileDragDropTarget
    {
        void OnFileDrop(string[] filepaths);
    }
}
