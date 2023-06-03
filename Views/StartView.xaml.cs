﻿using IssaWPF6.Service;
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
        }

        public MainWindow Main { get; }

        private DataService _dataService;

        private void ColonButton_Click(object sender, RoutedEventArgs e)
        {
            Main.DataContext = new ColonView(Main);
        }

        private void OGDButton_Click(object sender, RoutedEventArgs e)
        {
            Main.DataContext = new OGDView(Main);
        }

        private async void ColonDataButton_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new MainWindow();
            newWindow.DataContext = new ColonDataView();
            newWindow.Show();
        }

        private async void ColonExcelButton_Click(object sender, RoutedEventArgs e)
        {
            await _dataService.ExportColons();
        }

        private async void OGDExcelButton_Click(object sender, RoutedEventArgs e)
        {
            await _dataService.ExportStomaches();
        }

        private void OGDDataButton_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new MainWindow();
            newWindow.DataContext = new OGDDataView();
            newWindow.Show();
        }
    }
}
