using OfficeOpenXml;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OneView_MappingSet_MVVM.DataAccess
{
    using OneView_MappingSet_MVVM.Model;


    public class StandardTagListExcelAccess : ExcelAccess<StandardTagList>
    {
        private const int TagnameColNum = 1;
        private const int PresentationNameColNum = 5;
        private const int DescriptionColNum = 6;
        private const int OvSiTypeColNum = 7;
        private const int SiUnitColNum = 8;
        private const int TypeColNum = 9;
        private const int DataTypeColNum = 10;
        private const int CollectorTypeColNum = 11;

        public StandardTagListExcelAccess()
        {
            SheetName = MappingSetGenerator.StandardTagListSheetName; // Sheet name used in base class in GetSheetData
            MaxColNum = CollectorTypeColNum;
        }

        public async Task<StandardTagList> GetStandardMappingSetAsync(string path)
        {
            return await Task.Run(() => GetStandardMappingSet(path));
        }

        public StandardTagList GetStandardMappingSet(string path)
        {
            return GetSheetData(path);
        }

        protected override StandardTagList GetSheetData(string path)
        {
            return base.GetSheetData(path);
        }

        protected override StandardTagList ReadSheetData(ExcelWorksheet worksheet, int rows, int columns)
        {
            var standardTagList = new StandardTagList();
            var sheetDataCollection = standardTagList.TagListCollection;

            // Get data
            for (int i = 2; i <= rows; i++)
            {
                // Tagname is empty go next row
                if (string.IsNullOrEmpty(GetCellValue(worksheet.Cells[i, TagnameColNum].Value)))
                    continue;
                Iec6140025Tag iecTag = new Iec6140025Tag();
                for (int j = 1; j <= MaxColNum; j++)
                { 
                    string str = GetCellValue(worksheet.Cells[i, j].Value);
                    if (!string.IsNullOrEmpty(str))
                    {
                        switch (j)
                        {
                            case TagnameColNum:
                                iecTag.Tagname = str;
                                break;
                            case PresentationNameColNum:
                                iecTag.PresentationName = str;
                                break;
                            case DescriptionColNum:
                                iecTag.Description = str;
                                break;
                            case OvSiTypeColNum:
                                iecTag.OvSiType = str;
                                break;
                            case SiUnitColNum:
                                iecTag.SiUnit = str;
                                break;
                            case TypeColNum:
                                iecTag.Type = str;
                                break;
                            case DataTypeColNum:
                                iecTag.DataType= str;
                                break;
                            case CollectorTypeColNum:
                                iecTag.CollectorType = str;
                                break;
                            default:
                                break;
                        }
                    }
                }
                sheetDataCollection.Add(iecTag);
            }
            return standardTagList;
        }
    }
}
