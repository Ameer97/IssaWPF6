using IssaWPF6.Service;
using IssaWPF6.Windows;
using Microsoft.Win32;
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
    /// Interaction logic for StartView.xaml
    /// </summary>
    public partial class StartView : UserControl
    {
        public StartView()
        {
            InitializeComponent();
        }
        public StartView(MainWindow main)
        {
            InitializeComponent();
            Main = main;
            _dataService = new DataService();
            _dataService.Migrate();
        }

        public MainWindow Main { get; }

        private DataService _dataService;

        private void ColonButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new FullWindow();
            window.DataContext = new ColonView(window);
            window.Show();
        }

        private void OGDButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new FullWindow();
            window.DataContext = new OGDView(window);
            window.Show();
        }

        private async void ColonDataButton_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new MainWindow();
            newWindow.DataContext = new ColonDataView(newWindow);
            newWindow.Show();
        }

        private async void ColonExcelButton_Click(object sender, RoutedEventArgs e)
        {
            await _dataService.ExportColons();
            //var fileDialog = new OpenFileDialog();
            //if (fileDialog.ShowDialog() == true)
            //{
            //    Common.ImportColonsExcel(fileDialog.FileName);

            //}
        }

        private async void OGDExcelButton_Click(object sender, RoutedEventArgs e)
        {
            await _dataService.ExportStomaches();
            //var fileDialog = new OpenFileDialog();
            //if (fileDialog.ShowDialog() == true)
            //{
            //    Common.ImportODGExcel(fileDialog.FileName);

            //}
        }

        private void OGDDataButton_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new MainWindow();
            newWindow.DataContext = new OGDDataView(newWindow);
            newWindow.Show();
        }
    }
}
