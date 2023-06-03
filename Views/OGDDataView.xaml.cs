using IssaWPF6.DAL;
using IssaWPF6.Dtos;
using IssaWPF6.Service;
using IssaWPF6.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IssaWPF6.Views
{
    /// <summary>
    /// Interaction logic for Colon2.xaml
    /// </summary>
    public partial class OGDDataView : UserControl
    {
        private DataService _dataService;

        public OGDDataView()
        {
            InitializeComponent();
            _dataService = new DataService();

            Style rowStyle = new Style(typeof(DataGridRow));
            rowStyle.Setters.Add(new EventSetter(DataGridRow.MouseDoubleClickEvent,
                                     new MouseButtonEventHandler(Table_MouseDoubleClick)));
            Table.RowStyle = rowStyle;
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Table.ItemsSource = await _dataService.Stomaches();
        }

        private void Table_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            DataGridRow row = sender as DataGridRow;
            if (row != null)
            {
                var item = (StomachDto)row.Item;
                Common.RenderOGD(item);
            }
        }
    }
}
