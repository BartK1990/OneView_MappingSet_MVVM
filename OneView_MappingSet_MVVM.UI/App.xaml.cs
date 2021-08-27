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
        public IStandardTagListReadRepository StandardMappingSetReadRepository;
        public ISourceItemDictionaryReadRepository SourceItemDictionaryReadRepository;
        public ISourceItemListReadRepository SourceItemListReadRepository;
        public ISourceItemListWriteRepository SourceItemListWriteRepository;
        public IMappingSetWriteRepository MappingSet451WriteRepository;
        public IMappingSetWriteRepository MappingSet450WriteRepository;
        public IMappingSetWriteRepository MappingSet444WriteRepository;
        public IExcelSheetNameRepository ExcelSheetNameRepository;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Application objects initialization
            FileDialog = new ExcelFileDialog();
            ErrorHandler = new ErrorHandler();
            MappingSetGeneratorService = new MappingSetGeneratorService(new MappingSetGenerator());
            StandardMappingSetReadRepository = new StandardTagListReadRepository(new StandardTagListReadExcelAccess());
            SourceItemDictionaryReadRepository = new SourceItemDictionaryReadRepository(new SourceItemDictionaryReadExcelAccess());
            SourceItemListReadRepository = new SourceItemListReadRepository(new SourceItemListReadExcelAccess());
            SourceItemListWriteRepository = new SourceItemListWriteRepository(new SourceItemListCreateExcelAccess());
            MappingSet451WriteRepository = new MappingSet451WriteRepository(new MappingSet451CreateExcelAccess());
            MappingSet450WriteRepository = new MappingSet450WriteRepository(new MappingSet450CreateExcelAccess());
            MappingSet444WriteRepository = new MappingSet444WriteRepository(new MappingSet444CreateExcelAccess());
            ExcelSheetNameRepository = new ExcelSheetNameRepository(new SheetNamesReadExcelAccess());
        }
    }
}
