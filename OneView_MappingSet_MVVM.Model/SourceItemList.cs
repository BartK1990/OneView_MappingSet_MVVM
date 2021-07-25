using System.Collections.Generic;

namespace OneView_MappingSet_MVVM.Model
{
    public class SourceItemList : SourceListBase<SourceItem>
    {
        public SourceItemList()
        {
            SourceDataList = new List<SourceItem>();
        }
    }
}
