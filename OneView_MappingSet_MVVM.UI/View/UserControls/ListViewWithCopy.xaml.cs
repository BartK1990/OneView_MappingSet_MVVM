using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OneView_MappingSet_MVVM.UI.View.UserControls
{
    /// <summary>
    /// Interaction logic for ListViewWithCopy.xaml
    /// </summary>
    public partial class ListViewWithCopy : UserControl
    {
        public ListViewWithCopy()
        {
            InitializeComponent();
        }

        public IEnumerable ItemsSource { get; set; }

        public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty
            .Register("ItemsSource", typeof(IEnumerable), typeof(ListViewWithCopy), new PropertyMetadata(null));


    }
}
