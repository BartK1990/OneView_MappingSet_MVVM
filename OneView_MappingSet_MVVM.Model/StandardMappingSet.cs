﻿using System.Collections;
using System.Collections.Generic;

namespace OneView_MappingSet_MVVM.Model
{
    public class StandardMappingSet
    {
        public IDictionary<string, long> TagIndexDictionary;
        public ICollection<Iec6140025Tag> TaglistCollection;
    }
}
