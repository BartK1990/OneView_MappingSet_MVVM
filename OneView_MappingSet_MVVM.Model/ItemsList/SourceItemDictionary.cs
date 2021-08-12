using System.Collections.Generic;

namespace OneView_MappingSet_MVVM.Model
{
    public class SourceItemDictionary : SourceListBase<DictionaryItem>
    {
        public SourceItemDictionary()
        {
            SourceDataList = new List<DictionaryItem>();
        }
    }
}
