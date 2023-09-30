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
using Microsoft.Win32;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

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
        public FullWindow Main { get; set; }
        public int? Id { get; }
        public OGDDataView? DataView { get; }


        private string Img1 = "";
        private string Img2 = "";
        private string Img3 = "";
        public OGDView()
        {
            InitializeComponent();
        }
        public OGDView(FullWindow? main = null, int? id = null, OGDDataView? dataView = null)
        {
            InitializeComponent();
            _dataService = new DataService();

            Gender.ItemsSource = new List<string> { Enum.Gender.Male, Enum.Gender.Female };
            Scope.ItemsSource = new List<string> { Enum.Scope.Olympus, Enum.Scope.Pentax, Enum.Scope.Fujifilm };

            Date.SelectedDate = DateTime.UtcNow.Date;
            Main = main;
            Id = id;
            DataView = dataView;

            if(id > 0)
            {
                stomach = _dataService.EditStomache(id);
                Name.Text = stomach.Name;
                Age.Text = stomach.Age;
                Gender.SelectedItem = stomach.Gender;
                FileNo.Text = stomach.FileNo;
                Date.SelectedDate = stomach.Date;
                Premedication.Text = stomach.Premedication;
                Scope.SelectedItem = stomach.Scope;
                ReferredDoctor.Text = stomach.ReferredDoctor;
                ClinicalData.Text = stomach.ClinicalData;
                GEJ.Text = stomach.GEJ;
                Esophagus.Text = stomach.Esophagus;
                StomachDetails.Text = stomach.StomachDetails;
                D1.Text = stomach.D1;
                D2.Text = stomach.D2;
                Conclusion.Text = stomach.Conclusion;
                Assistant.Text = stomach.Assistant;
                Endoscopist.Text = stomach.Endoscopist;
            }
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
            DataView?.Load();
            stomach = await _dataService.AddStomach(stomach);


            if (!string.IsNullOrEmpty(Img1))
                _dataService.SetImage(Img1, nameof(Img1), stomach.TypePhoto, stomach.Id);
            if (!string.IsNullOrEmpty(Img2))
                _dataService.SetImage(Img2, nameof(Img2), stomach.TypePhoto, stomach.Id);
            if (!string.IsNullOrEmpty(Img3))
                _dataService.SetImage(Img3, nameof(Img3), stomach.TypePhoto, stomach.Id);

            Common.RenderOGD(new StomachDto(stomach));

        }

        private void UserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F4)
            {
                try
                {
                    var g = FocusManager.GetFocusedElement(Application.Current.Windows[2]);
                    _dialog = new DialogWindow();
                    _dialog.Close();
                    _dialog = new();
                    _dialog.DataContext = new KeyView((TextBox)g, _dialog, Common.StomacheShoutCuts);
                    _dialog.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Name.Focus();
        }
        private void Image1Button_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                Img1 = openFileDialog.FileName;
        }

        private void Image2Button_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                Img2 = openFileDialog.FileName;
        }

        private void Image3Button_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                Img3 = openFileDialog.FileName;
        }

        private void Reload_Click(object sender, RoutedEventArgs e)
        {
            Main.Close();
            Main = new FullWindow();
            Main.DataContext = new OGDView(Main);
            Main.Show();

        }

    }


}
