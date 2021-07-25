using OneView_MappingSet_MVVM.DataAccess;
using OneView_MappingSet_MVVM.Model;
using OneView_MappingSet_MVVM.UI.Data.Repositories;
using OneView_MappingSet_MVVM.UI.Data.Services;
using OneView_MappingSet_MVVM.UI.View.Services;
using OneView_MappingSet_MVVM.UI.ViewModel.Services;
using System.Windows;

namespace OneView_MappingSet_MVVM.UI
{
    public partial class App : Application
    {
        public IExcelFileDialog FileDialog;
        public IErrorHandler ErrorHandler;
        public IMappingSetGeneratorService MappingSetGeneratorService;
        public IStandardTagListRepository StandardMappingSetRepository;
        public ISourceItemDictionaryRepository SourceItemDictionaryRepository;
        public ISourceItemListRepository SourceItemListRepository;
        public IExcelSheetNameRepository ExcelSheetNameRepository;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Application objects initialization
            FileDialog = new ExcelFileDialog();
            ErrorHandler = new ErrorHandler();
            MappingSetGeneratorService = new MappingSetGeneratorService(new MappingSetGenerator());
            StandardMappingSetRepository = new StandardTagListRepository(new StandardTagListExcelAccess());
            SourceItemDictionaryRepository = new SourceItemDictionaryRepository(new SourceItemDictionaryExcelAccess());
            SourceItemListRepository = new SourceItemListRepository(new SourceItemListExcelAccess());
            ExcelSheetNameRepository = new ExcelSheetNameRepository(new SheetNamesExcelAccess());
        }
    }
}
