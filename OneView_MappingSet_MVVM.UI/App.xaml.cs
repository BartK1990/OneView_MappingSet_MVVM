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

    public partial class App : Application
    {

        public IFileDialog FileDialog;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Application objects initialization
            FileDialog = new FileDialog();

        }
    }
}
