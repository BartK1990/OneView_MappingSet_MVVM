using System.Collections.Generic;

namespace OneView_MappingSet_MVVM.Model
{
    public abstract class SourceListBase<T>
    {
        public IList<T> SourceDataList { get; set; }
    }
}