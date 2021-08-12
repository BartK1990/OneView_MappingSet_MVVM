using OneView_MappingSet_MVVM.Model.Item;
using System.Collections.Generic;

namespace OneView_MappingSet_MVVM.Model.ItemsList
{
    public class MappingTagList : SourceListBase<MappingTag>
    {
        public MappingTagList()
        {
            SourceDataList = new List<MappingTag>();
        }
    }
}
