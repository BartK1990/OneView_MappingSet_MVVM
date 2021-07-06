using NUnit.Framework;
using OneView_MappingSet_MVVM.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OneView_MappingSet_MVVM.Tests.Model
{
    class MappingSetGeneratorTests
    {
        private MappingSetGenerator msp;

        [SetUp]
        public void Setup()
        {
            msp = new MappingSetGenerator();
        }

        #region CheckIfConatainsValidSheet
        [Test]
        public void CheckIfConatainsValidSheet_Null_ExcelFileType()
        {
            var result = msp.CheckIfConatainsValidSheet(null);
            Assert.AreEqual(ExcelFileType.Invalid, result);
        }

        [Test]
        public async Task CheckIfConatainsValidSheetAsync_Null_ExcelFileType()
        {
            var result = await msp.CheckIfConatainsValidSheetAsync(null);
            Assert.AreEqual(ExcelFileType.Invalid, result);
        }

        [Test]
        public void CheckIfConatainsValidSheet_ValidExcelType1_ExcelFileType()
        {
            var result = msp.CheckIfConatainsValidSheet(ValidExcelType1_ExcelFileType());
            Assert.AreEqual(ExcelFileType.StandardTagList, result);
        }

        [Test]
        public async Task CheckIfConatainsValidSheetAsync_ValidExcelType1_ExcelFileType()
        {
            var result = await msp.CheckIfConatainsValidSheetAsync(ValidExcelType1_ExcelFileType());
            Assert.AreEqual(ExcelFileType.StandardTagList, result);
        }

        [Test]
        public void CheckIfConatainsValidSheet_ValidExcelType2_ExcelFileType()
        {
            var result = msp.CheckIfConatainsValidSheet(ValidExcelType2_ExcelFileType());
            Assert.AreEqual(ExcelFileType.SourceDictionary, result);
        }

        [Test]
        public async Task CheckIfConatainsValidSheetAsync_ValidExcelType2_ExcelFileType()
        {
            var result = await msp.CheckIfConatainsValidSheetAsync(ValidExcelType2_ExcelFileType());
            Assert.AreEqual(ExcelFileType.SourceDictionary, result);
        }

        [Test]
        public void CheckIfConatainsValidSheet_ValidExcelType3_ExcelFileType()
        {
            var result = msp.CheckIfConatainsValidSheet(ValidExcelType3_ExcelFileType());
            Assert.AreEqual(ExcelFileType.SourceList, result);
        }

        [Test]
        public async Task CheckIfConatainsValidSheetAsync_ValidExcelType3_ExcelFileType()
        {
            var result = await msp.CheckIfConatainsValidSheetAsync(ValidExcelType3_ExcelFileType());
            Assert.AreEqual(ExcelFileType.SourceList, result);
        }

        [Test]
        public void CheckIfConatainsValidSheet_InvalidExcelType1_ExcelFileType()
        {
            var result = msp.CheckIfConatainsValidSheet(InvalidExcelType1_ExcelFileType());
            Assert.AreEqual(ExcelFileType.Invalid, result);
        }

        [Test]
        public async Task CheckIfConatainsValidSheetAsync_InvalidExcelType1_ExcelFileType()
        {
            var result = await msp.CheckIfConatainsValidSheetAsync(InvalidExcelType1_ExcelFileType());
            Assert.AreEqual(ExcelFileType.Invalid, result);
        }

        [Test]
        public void CheckIfConatainsValidSheet_EmptyCollection_ExcelFileType()
        {
            var result = msp.CheckIfConatainsValidSheet(EmptyCollection_ExcelFileType());
            Assert.AreEqual(ExcelFileType.Invalid, result);
        }

        [Test]
        public async Task CheckIfConatainsValidSheetAsync_EmptyCollection_ExcelFileType()
        {
            var result = await msp.CheckIfConatainsValidSheetAsync(EmptyCollection_ExcelFileType());
            Assert.AreEqual(ExcelFileType.Invalid, result);
        }

        private static IList<string> ValidExcelType1_ExcelFileType()
        {
            var sheetList = new List<string>
            {
                "SCI Standard Mappingset"
            };
            return sheetList;
        }

        private static IList<string> ValidExcelType2_ExcelFileType()
        {
            var msp = new MappingSetGenerator();
            var sheetList = new List<string>
            {
                "SCI Source Dictionary",
                "Some other sheet"
            };
            return sheetList;
        }

        private static IList<string> ValidExcelType3_ExcelFileType()
        {
            var msp = new MappingSetGenerator();
            var sheetList = new List<string>
            {
                "Some other sheet",
                "SCI Source Items"
            };
            return sheetList;
        }

        private static IList<string> InvalidExcelType1_ExcelFileType()
        {
            var msp = new MappingSetGenerator();
            var sheetList = new List<string>
            {
                "Some sheet",
                "Some other sheet"
            };
            return sheetList;
        }

        private static IList<string> EmptyCollection_ExcelFileType()
        {
            var msp = new MappingSetGenerator();
            var sheetList = new List<string>();
            var result = msp.CheckIfConatainsValidSheet(sheetList);
            return sheetList;
        }

        #endregion
    }
}
