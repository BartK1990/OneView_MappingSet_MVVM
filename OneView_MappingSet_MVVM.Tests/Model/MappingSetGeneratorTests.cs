using NUnit.Framework;
using OneView_MappingSet_MVVM.Model;
using System.Collections.Generic;

namespace OneView_MappingSet_MVVM.Tests.Model
{
    class MappingSetGeneratorTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void CheckIfConatainsValidSheet_ValidExcelType1_ExcelFileType()
        {
            var msp = new MappingSetGenerator();
            var sheetList = new List<string>
            {
                "SCI Standard Mappingset"
            };
            var result = msp.CheckIfConatainsValidSheet(sheetList);

            Assert.AreEqual(ExcelFileType.StandardTagList, result);
        }

        [Test]
        public void CheckIfConatainsValidSheet_ValidExcelType2_ExcelFileType()
        {
            var msp = new MappingSetGenerator();
            var sheetList = new List<string>
            {
                "SCI Source Dictionary",
                "Some other sheet"
            };

            var result = msp.CheckIfConatainsValidSheet(sheetList);

            Assert.AreEqual(ExcelFileType.SourceDictionary, result);
        }

        [Test]
        public void CheckIfConatainsValidSheet_ValidExcelType3_ExcelFileType()
        {
            var msp = new MappingSetGenerator();
            var sheetList = new List<string>
            {
                "SCI Source Items",
                "Some other sheet"
            };
            var result = msp.CheckIfConatainsValidSheet(sheetList);

            Assert.AreEqual(ExcelFileType.SourceList, result);
        }

        [Test]
        public void CheckIfConatainsValidSheet_InvalidExcelType1_ExcelFileType()
        {
            var msp = new MappingSetGenerator();
            var sheetList = new List<string>
            {
                "Some sheet",
                "Some other sheet"
            };
            var result = msp.CheckIfConatainsValidSheet(sheetList);

            Assert.AreEqual(ExcelFileType.Invalid, result);
        }

        [Test]
        public void CheckIfConatainsValidSheet_EmptyCollection_ExcelFileType()
        {
            var msp = new MappingSetGenerator();
            var sheetList = new List<string>();
            var result = msp.CheckIfConatainsValidSheet(sheetList);

            Assert.AreEqual(ExcelFileType.Invalid, result);
        }

    }
}
