using System.Windows;

namespace OneView_MappingSet_MVVM.UI
{
    using Data.Repositories;
    using OneView_MappingSet_MVVM.DataAccess;
    using View.Services;
    using ViewModel.Services;

    public partial class App : Application
    {

        public IFileDialog FileDialog;
        public IStandardTagListRepository StandardMappingSetRepository;
        public IErrorHandler ErrorHandler;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Application objects initialization
            FileDialog = new FileDialog();
            StandardMappingSetRepository = new StandardTagListRepository(new StandardTagListExcelAccess());
            ErrorHandler = new ErrorHandler();

        }
    }
}
