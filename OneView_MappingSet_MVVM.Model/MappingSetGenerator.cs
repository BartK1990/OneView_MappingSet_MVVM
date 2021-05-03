using System;
using System.Collections.Generic;
using System.Text;

namespace OneView_MappingSet_MVVM.Model
{
    public enum ExcelFileType
    {
        Invalid = -1,
        StandardTagList = 1
    }

    public class MappingSetGenerator
    {
        public const string StandardTagListSheetName = "SCI Standard Mappingset";

        public ExcelFileType CheckExcelFileType(string path) 
        {
            throw new NotImplementedException();
        }
    }
}
