using NUnit.Framework;
using OneView_MappingSet_MVVM.Model;
using OneView_MappingSet_MVVM.Model.Item;
using OneView_MappingSet_MVVM.Model.ItemsList;
using System.Collections.Generic;
using System.Linq;
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
            var result = msp.CheckIfConatainsValidSheet(CheckIfConatainsValidSheet_ValidExcelType1());
            Assert.AreEqual(ExcelFileType.StandardTagList, result);
        }
        [Test]
        public async Task CheckIfConatainsValidSheetAsync_ValidExcelType1_ExcelFileType()
        {
            var result = await msp.CheckIfConatainsValidSheetAsync(CheckIfConatainsValidSheet_ValidExcelType1());
            Assert.AreEqual(ExcelFileType.StandardTagList, result);
        }
        private static IList<string> CheckIfConatainsValidSheet_ValidExcelType1()
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
            var result = msp.CheckIfConatainsValidSheet(CheckIfConatainsValidSheet_ValidExcelType2());
            Assert.AreEqual(ExcelFileType.SourceDictionary, result);
        }
        [Test]
        public async Task CheckIfConatainsValidSheetAsync_ValidExcelType2_ExcelFileType()
        {
            var result = await msp.CheckIfConatainsValidSheetAsync(CheckIfConatainsValidSheet_ValidExcelType2());
            Assert.AreEqual(ExcelFileType.SourceDictionary, result);
        }
        private static IList<string> CheckIfConatainsValidSheet_ValidExcelType2()
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
            var result = msp.CheckIfConatainsValidSheet(CheckIfConatainsValidSheet_ValidExcelType3());
            Assert.AreEqual(ExcelFileType.SourceList, result);
        }
        [Test]
        public async Task CheckIfConatainsValidSheetAsync_ValidExcelType3_ExcelFileType()
        {
            var result = await msp.CheckIfConatainsValidSheetAsync(CheckIfConatainsValidSheet_ValidExcelType3());
            Assert.AreEqual(ExcelFileType.SourceList, result);
        }
        private static IList<string> CheckIfConatainsValidSheet_ValidExcelType3()
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
            var result = msp.CheckIfConatainsValidSheet(CheckIfConatainsValidSheet_InvalidExcelType1());
            Assert.AreEqual(ExcelFileType.Invalid, result);
        }
        [Test]
        public async Task CheckIfConatainsValidSheetAsync_InvalidExcelType1_ExcelFileType()
        {
            var result = await msp.CheckIfConatainsValidSheetAsync(CheckIfConatainsValidSheet_InvalidExcelType1());
            Assert.AreEqual(ExcelFileType.Invalid, result);
        }
        private static IList<string> CheckIfConatainsValidSheet_InvalidExcelType1()
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
            var result = msp.CheckIfConatainsValidSheet(CheckIfConatainsValidSheet_EmptyCollection());
            Assert.AreEqual(ExcelFileType.Invalid, result);
        }
        [Test]
        public async Task CheckIfConatainsValidSheetAsync_EmptyCollection_ExcelFileType()
        {
            var result = await msp.CheckIfConatainsValidSheetAsync(CheckIfConatainsValidSheet_EmptyCollection());
            Assert.AreEqual(ExcelFileType.Invalid, result);
        }
        private static IList<string> CheckIfConatainsValidSheet_EmptyCollection()
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

            var result = msp.GetTurbineTypes(GetTurbineTypes_2Types());
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

            var result = await msp.GetTurbineTypesAsync(GetTurbineTypes_2Types());
            Assert.AreEqual(exptectedOutput, result);
        }
        private SourceItemDictionary GetTurbineTypes_2Types()
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

            var result = msp.GetTurbineTypes(GetTurbineTypes_1Type());
            Assert.AreEqual(exptectedOutput, result);
        }
        [Test]
        public async Task GetTurbineTypesAsync_1Type_1Item()
        {
            var exptectedOutput = new List<string>()
            {
                "Vestas"
            };

            var result = await msp.GetTurbineTypesAsync(GetTurbineTypes_1Type());
            Assert.AreEqual(exptectedOutput, result);
        }
        private SourceItemDictionary GetTurbineTypes_1Type()
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

            var result = msp.GetTurbineTypes(GetTurbineTypes_1Item());
            Assert.AreEqual(exptectedOutput, result);
        }
        [Test]
        public async Task GetTurbineTypesAsync_1Item_1Item()
        {
            var exptectedOutput = new List<string>()
            {
                "GE"
            };

            var result = await msp.GetTurbineTypesAsync(GetTurbineTypes_1Item());
            Assert.AreEqual(exptectedOutput, result);
        }
        private SourceItemDictionary GetTurbineTypes_1Item()
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

        #region GetMappingSet
        [Test]
        public void GetMappingSet_1ValidFunc1NotValid_1Function()
        {
            var expectedResult = GetTurbineTypes_1ValidFunc1NotValid(out var sid, out var sil, out var turbineType);
            var result = msp.GetMappingSet(null, sid, sil, turbineType);
            Assert.IsTrue(expectedResult.SourceDataList.All(result.SourceDataList.Contains));
        }
        [Test]
        public async Task GetTurbineTypesAsync_1ValidFunc1NotValid_1Function()
        {
            var expectedResult = GetTurbineTypes_1ValidFunc1NotValid(out var sid, out var sil, out var turbineType);
            var result = await msp.GetMappingSetAsync(new StandardTagList(), sid, sil, turbineType);
            Assert.IsTrue(expectedResult.SourceDataList.All(result.SourceDataList.Contains));
        }
        private MappingTagList GetTurbineTypes_1ValidFunc1NotValid(out SourceItemDictionary sid, out SourceItemList sil, out string turbineType)
        {
            turbineType = "Type1";

            sid = new SourceItemDictionary()
            {
                SourceDataList = new List<DictionaryItem>()
                {
                    new DictionaryItem(){TurbineType=turbineType, Tagname="Tagname1", ReadExpression=@"return HistValSngl(""Tagname3"", Now(),TimeSpan(1,0,0));"}
                    ,new DictionaryItem(){TurbineType=turbineType, Tagname="Tagname2", SourceItemIdentifier="sii2", SiType="Double"}
                    ,new DictionaryItem(){TurbineType=turbineType, Tagname="Tagname3", SourceItemIdentifier="sii3"}
                }
            };

            sil = new SourceItemList()
            {
                SourceDataList = new List<SourceItem>()
                {
                    new SourceItem(){SourceItemIdentifier="sii2"}
                }
            };

            var expectedResult = new MappingTagList()
            {
                SourceDataList = new List<MappingTag>()
                {
                    new MappingTag(){Tagname="Tagname2", SourceItemIdentifier="sii2", SiType = "Double"}
                }
            };

            return expectedResult;
        }

        [Test]
        public void GetMappingSet_2ValidFunc_2Function()
        {
            var expectedResult = GetTurbineTypes_2ValidFunc(out var sid, out var sil, out var turbineType);
            var result = msp.GetMappingSet(null, sid, sil, turbineType);
            Assert.IsTrue(expectedResult.SourceDataList.All(result.SourceDataList.Contains));
        }
        [Test]
        public async Task GetTurbineTypesAsync_2ValidFunc_2Function()
        {
            var expectedResult = GetTurbineTypes_2ValidFunc(out var sid, out var sil, out var turbineType);
            var result = await msp.GetMappingSetAsync(new StandardTagList(), sid, sil, turbineType);
            Assert.IsTrue(expectedResult.SourceDataList.All(result.SourceDataList.Contains));
        }
        private MappingTagList GetTurbineTypes_2ValidFunc(out SourceItemDictionary sid, out SourceItemList sil, out string turbineType)
        {
            turbineType = "Type1";

            sid = new SourceItemDictionary()
            {
                SourceDataList = new List<DictionaryItem>()
                {
                    new DictionaryItem(){TurbineType=turbineType, Tagname="Tagname1", ReadExpression=@"return HistValSngl(""Tagname3"", Now(),TimeSpan(1,0,0));"}
                    ,new DictionaryItem(){TurbineType=turbineType, Tagname="Tagname2", SourceItemIdentifier="sii2", SiType="Double"}
                    ,new DictionaryItem(){TurbineType=turbineType, Tagname="Tagname3", SourceItemIdentifier="sii3"}
                }
            };

            sil = new SourceItemList()
            {
                SourceDataList = new List<SourceItem>()
                {
                    new SourceItem(){SourceItemIdentifier="sii2"}
                    ,new SourceItem(){SourceItemIdentifier="sii3"}
                }
            };

            var expectedResult = new MappingTagList()
            {
                SourceDataList = new List<MappingTag>()
                {
                    new MappingTag(){Tagname="Tagname1", ReadExpression=@"return HistValSngl(""Tagname3"", Now(),TimeSpan(1,0,0));"}
                    ,new MappingTag(){Tagname="Tagname2", SourceItemIdentifier="sii2", SiType = "Double"}
                    ,new MappingTag(){Tagname="Tagname3", SourceItemIdentifier="sii3"}
                }
            };

            return expectedResult;
        }
        #endregion
    }
}
