﻿using IssaWPF6.DAL;
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

        public async void Load(object? sender = null, RoutedEventArgs? e = null)
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

        void SelectedF(int casee)
        {
            var selectedIndex = Table.SelectedIndex;
            if (selectedIndex == -1) return;

            var item = Table.Items.SourceCollection.Cast<StomachDto>().ToArray()[selectedIndex];

            if (item == null) return;

            switch (casee)
            {
                case 0:
                    Common.RenderOGD(item);
                    break;

                case 1:
                    {
                        var main = new FullWindow();
                        main.DataContext = new OGDView(id: item.Id, dataView: this);
                        main.Show();
                    }
                    break;

                case 2:_dataService.DeleteStomach(item.Id);
                    break;
                default:
                    break;
            }
        }

        private void PDF_Click(object sender, RoutedEventArgs e)
        {
            SelectedF(0);
        }


        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            SelectedF(1);
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
