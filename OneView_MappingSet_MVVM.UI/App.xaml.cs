using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace OneView_MappingSet_MVVM.UI
{
    using View.Service;
    using Data.Repositories;
    using OneView_MappingSet_MVVM.DataAccess;

    public partial class App : Application
    {

        public IFileDialog FileDialog;
        public IStandardTagListRepository StandardMappingSetRepository;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Application objects initialization
            FileDialog = new FileDialog();
            StandardMappingSetRepository = new StandardTagListRepository(new StandardTagListExcelAccess());

        }
    }
}
