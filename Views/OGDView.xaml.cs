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
        private Stomach stomach = new();
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
            Scope.ItemsSource = new List<string> { Enum.Scope.Olympus, Enum.Scope.Pentax, Enum.Scope.Fujifilm };

            Date.SelectedDate = DateTime.UtcNow.Date;
            Main = main;
        }


        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            stomach.Name = Name.Text;
            stomach.Age = Age.Text;
            stomach.Gender = Gender.SelectedItem?.ToString();
            stomach.FileNo = FileNo.Text;
            stomach.Date = Date.SelectedDate?.Date ?? DateTime.UtcNow;
            stomach.Premedication = Premedication.Text;
            stomach.Scope = Scope.SelectedItem?.ToString();
            stomach.ReferredDoctor = ReferredDoctor.Text;
            stomach.ClinicalData = ClinicalData.Text;
            stomach.GEJ = GEJ.Text;
            stomach.Esophagus = Esophagus.Text;
            stomach.StomachDetails = StomachDetails.Text;
            stomach.D1 = D1.Text;
            stomach.D2 = D2.Text;
            stomach.Conclusion = Conclusion.Text;
            stomach.Assistant = Assistant.Text;
            stomach.Endoscopist = Endoscopist.Text;
            stomach = await _dataService.AddStomach(stomach);


            Common.RenderOGD(new StomachDto(stomach));

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
