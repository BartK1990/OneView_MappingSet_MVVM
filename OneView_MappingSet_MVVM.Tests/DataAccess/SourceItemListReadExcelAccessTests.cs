using NUnit.Framework;
using OfficeOpenXml;
using OneView_MappingSet_MVVM.DataAccess;
using OneView_MappingSet_MVVM.DataAccess.Exceptions;
using OneView_MappingSet_MVVM.Model;
using System;
using System.Linq;

namespace OneView_MappingSet_MVVM.Tests.DataAccess
{
    public class SourceItemListReadExcelAccessTests
    {
        private SourceItemListReadExcelAccess sourceItemListReadExcelAccess;

        [SetUp]
        public void Setup()
        {
            sourceItemListReadExcelAccess = new SourceItemListReadExcelAccess();
        }

        [Test]
        public void ReadExcelDataTest_ValidSheet1Item_1Item()
        {         
            SourceItemList sourceItemListResult;
            using (ExcelPackage package = new ExcelPackage())
            {
                ExcelWorksheet ws = package.Workbook.Worksheets.Add(MappingSetGenerator.SourceItemListSheetName);
                ws.Cells["A1"].Value = "SourceItemIdentifier";
                ws.Cells["A2"].Value = "Item1";

                sourceItemListResult = sourceItemListReadExcelAccess.ReadExcelData(package);
            }

            SourceItemList sourceItemListExpected = new SourceItemList();
            sourceItemListExpected.SourceDataList.Add(new SourceItem() { SourceItemIdentifier = "Item1" });

            Assert.IsTrue(sourceItemListExpected.SourceDataList.SequenceEqual(sourceItemListResult.SourceDataList));
        }
        [Test]
        public void ReadExcelDataTest_InvalidPath_Exception()
        {
            Assert.Throws(typeof(InvalidExcelSheetException)
                , () => { sourceItemListReadExcelAccess.ReadExcelData("Invalid path string"); }
                );
        }
    }
}
