﻿using System.Collections.Generic;

namespace OneView_MappingSet_MVVM.Model
{
    public class ExcelSheetName
    {
        public ExcelSheetName()
        {
            SheetCollection = new List<string>();
        }

        public IList<string> SheetCollection { get; set; }
    }
}
