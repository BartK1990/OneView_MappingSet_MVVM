using System.Collections.Generic;

namespace OneView_MappingSet_MVVM.Model
{
    public class StandardTagList : SourceListBase<Iec6140025Tag>
    {
        public StandardTagList()
        {
            SourceDataList = new List<Iec6140025Tag>();
        }
    }
}
