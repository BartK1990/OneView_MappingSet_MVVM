using System;
using System.Collections.Generic;
using System.Text;

namespace OneView_MappingSet_MVVM.Model
{
    public class ExcelSheetName
    {
        public ExcelSheetName()
        {
            SheetCollection = new List<string>();
        }

        public ICollection<string> SheetCollection { get; set; }
    }
}
