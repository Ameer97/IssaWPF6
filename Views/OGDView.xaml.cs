using IssaWPF6.Dtos;
using IssaWPF6.Enum;
using IssaWPF6.Models;
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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using IssaWPF6.Service;
using IssaWPF6.Windows;
using OfficeOpenXml;

namespace IssaWPF6.Views
{
    /// <summary>
    /// Interaction logic for OGDView.xaml
    /// </summary>
    public partial class OGDView : UserControl
    {
        private DataService _dataService;
        private DialogWindow _dialog = new();

        public MainWindow Main { get; }

        public OGDView()
        {
            InitializeComponent();
        }
        public OGDView(MainWindow main)
        {
            InitializeComponent();
            _dataService = new DataService();

            Gender.ItemsSource = new List<string> { Enum.Gender.Male, Enum.Gender.Female };
            Scope.ItemsSource = new List<string> { Enum.Scope.Olympus, Enum.Scope.Pentax };

            Date.SelectedDate = DateTime.UtcNow.Date;
            Main = main;
        }


        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var f = await _dataService.AddStomach(new Models.Stomach
            {
                Name = Name.Text,
                Age = Age.Text,
                Gender = Gender.SelectedItem.ToString(),
                FileNo = FileNo.Text,
                Date = Date.SelectedDate?.Date ?? DateTime.UtcNow,
                Premedication = Premedication.Text,
                Scope = Scope.SelectedItem.ToString(),
                ReferredDoctor = ReferredDoctor.Text,
                ClinicalData = ClinicalData.Text,
                GEJ = GEJ.Text,
                Esophagus = Esophagus.Text,
                StomachDetails = StomachDetails.Text,
                D1 = D1.Text,
                D2 = D2.Text,
                Conclusion = Conclusion.Text,
                Assistant = Assistant.Text,
                Endoscopist = Endoscopist.Text
            });


            Common.RenderOGD(new StomachDto(f));

        }

        private void UserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F4)
            {
                try
                {
                    var g = FocusManager.GetFocusedElement(Application.Current.Windows[0]);
                    _dialog.Close();
                    _dialog = new();
                    _dialog.DataContext = new KeyView((TextBox)g, _dialog, Common.StomacheShoutCuts);
                    _dialog.ShowDialog();
                }
                catch { }
            }
        }

    }


}
