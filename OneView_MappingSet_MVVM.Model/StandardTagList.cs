using System.Collections;
using System.Collections.Generic;

namespace OneView_MappingSet_MVVM.Model
{
    public class StandardTagList
    {
        public StandardTagList()
        {
            TagListCollection = new List<Iec6140025Tag>();
        }
    
        public ICollection<Iec6140025Tag> TagListCollection { get; set; }

    }
}
