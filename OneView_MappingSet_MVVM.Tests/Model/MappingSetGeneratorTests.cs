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
        private static IList<string> ValidExcelType1_ExcelFileType()
        {
            var sheetList = new List<string>
            {
                "SCI Standard Mappingset"
            };
            return sheetList;
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
        private static IList<string> EmptyCollection_ExcelFileType()
        {
            var msp = new MappingSetGenerator();
            var sheetList = new List<string>();
            var result = msp.CheckIfConatainsValidSheet(sheetList);
            return sheetList;
        }

        #endregion
        #region GetTurbineTypes
        [Test]
        public void GetTurbineTypes_2Types_2Items()
        {
            var exptectedOutput = new List<string>()
            {
                "Vestas"
                ,"Nordex"
            };

            var result = msp.GetTurbineTypes(TwoTypes_2Items());
            Assert.AreEqual(exptectedOutput, result);
        }
        [Test]
        public async Task GetTurbineTypesAsync_2Types_2Items()
        {
            var exptectedOutput = new List<string>()
            {
                "Vestas"
                ,"Nordex"
            };

            var result = await msp.GetTurbineTypesAsync(TwoTypes_2Items());
            Assert.AreEqual(exptectedOutput, result);
        }
        private SourceItemDictionary TwoTypes_2Items()
        {
            var sid = new SourceItemDictionary();
            sid.SourceDataList.Add(new DictionaryItem() { TurbineType = "Vestas" });
            sid.SourceDataList.Add(new DictionaryItem() { TurbineType = "Vestas" });
            sid.SourceDataList.Add(new DictionaryItem() { TurbineType = "Vestas" });
            sid.SourceDataList.Add(new DictionaryItem() { TurbineType = "Nordex" });
            sid.SourceDataList.Add(new DictionaryItem() { TurbineType = "Nordex" });
            sid.SourceDataList.Add(new DictionaryItem() { TurbineType = "Vestas" });
            return sid;
        }

        [Test]
        public void GetTurbineTypes_1Type_1Item()
        {
            var exptectedOutput = new List<string>()
            {
                "Vestas"
            };

            var result = msp.GetTurbineTypes(OneType_1Item());
            Assert.AreEqual(exptectedOutput, result);
        }
        [Test]
        public async Task GetTurbineTypesAsync_1Type_1Item()
        {
            var exptectedOutput = new List<string>()
            {
                "Vestas"
            };

            var result = await msp.GetTurbineTypesAsync(OneType_1Item());
            Assert.AreEqual(exptectedOutput, result);
        }
        private SourceItemDictionary OneType_1Item()
        {
            var sid = new SourceItemDictionary();
            sid.SourceDataList.Add(new DictionaryItem() { TurbineType = "Vestas" });
            sid.SourceDataList.Add(new DictionaryItem() { TurbineType = "Vestas" });
            sid.SourceDataList.Add(new DictionaryItem() { TurbineType = "Vestas" });
            return sid;
        }

        [Test]
        public void GetTurbineTypes_1Item_1Item()
        {
            var exptectedOutput = new List<string>()
            {
                "GE"
            };

            var result = msp.GetTurbineTypes(OneItem_1Item());
            Assert.AreEqual(exptectedOutput, result);
        }        
        public async Task GetTurbineTypesAsync_1Item_1Item()
        {
            var exptectedOutput = new List<string>()
            {
                "GE"
            };

            var result = await msp.GetTurbineTypesAsync(OneItem_1Item());
            Assert.AreEqual(exptectedOutput, result);
        }
        private SourceItemDictionary OneItem_1Item()
        {
            var sid = new SourceItemDictionary();
            sid.SourceDataList.Add(new DictionaryItem() { TurbineType = "GE" });
            return sid;
        }

        [Test]
        public void GetTurbineTypes_EmptyList_EmptyList()
        {
            var exptectedOutput = new List<string>();

            var result = msp.GetTurbineTypes(new SourceItemDictionary());
            Assert.AreEqual(exptectedOutput, result);
        }        
        [Test]
        public async Task GetTurbineTypesAsync_EmptyList_EmptyList()
        {
            var exptectedOutput = new List<string>();

            var result = await msp.GetTurbineTypesAsync(new SourceItemDictionary());
            Assert.AreEqual(exptectedOutput, result);
        }
        #endregion
    }
}
