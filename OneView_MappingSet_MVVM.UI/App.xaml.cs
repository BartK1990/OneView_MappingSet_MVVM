using System.Windows;

namespace OneView_MappingSet_MVVM.UI
{
    using Data.Repositories;
    using OneView_MappingSet_MVVM.DataAccess;
    using OneView_MappingSet_MVVM.Model;
    using OneView_MappingSet_MVVM.UI.Data.Services;
    using View.Services;
    using ViewModel.Services;

    public partial class App : Application
    {

        public IExcelFileDialog FileDialog;
        public IErrorHandler ErrorHandler;
        public IMappingSetGeneratorService MappingSetGeneratorService;
        public IStandardTagListRepository StandardMappingSetRepository;
        public IExcelSheetNameRepository ExcelSheetNameRepository;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Application objects initialization
            FileDialog = new ExcelFileDialog();
            ErrorHandler = new ErrorHandler();
            MappingSetGeneratorService = new MappingSetGeneratorService(new MappingSetGenerator());
            StandardMappingSetRepository = new StandardTagListRepository(new StandardTagListExcelAccess());
            ExcelSheetNameRepository = new ExcelSheetNameRepository(new SheetNamesExcelAccess());
            
        }
    }
}
