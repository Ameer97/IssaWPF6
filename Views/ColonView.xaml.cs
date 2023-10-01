using IssaWPF6.Dtos;
using IssaWPF6.Models;
using IssaWPF6.Service;
using IssaWPF6.Windows;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
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
    /// Interaction logic for Colon2.xaml
    /// </summary>
    public partial class ColonView : UserControl
    {
        private DataService _dataService;
        private DialogWindow _dialog = new();
        private Colon colon = new Models.Colon();

        private string Img1 ="";
        private string Img2 ="";
        private string Img3 ="";
        public ColonView()
        {
            InitializeComponent();
        }

        public ColonView(FullWindow? main = null, int? id = null,ColonDataView? colonDataView = null)
        {
            InitializeComponent();
            _dataService = new DataService();

            Preparation.ItemsSource = new List<string> { Enum.Preparation.Good, Enum.Preparation.Bad, Enum.Preparation.Fair };
            Gender.ItemsSource = new List<string> { Enum.Gender.Male, Enum.Gender.Female };
            Scope.ItemsSource = new List<string> { Enum.Scope.Olympus, Enum.Scope.Pentax, Enum.Scope.Fujifilm };

            DateTimePicker1.SelectedDate = DateTime.UtcNow.Date;
            Main = main;
            Id = id;
            ColonDataView = colonDataView;
            if (id > 0)
            {
                colon = _dataService.EditColon(id);
                Age.Text = colon.Age;
                AnalInspection.Text = colon.AnalInspection;
                Assistant.Text = colon.Assistant;
                ClinicalData.Text = colon.ClinicalData;
                Colon.Text = colon.ColonDetails;
                Conclusion.Text = colon.Conclusion;
                Endoscopist.Text = colon.Endoscopist;
                FileNo.Text = colon.FileNo;
                PRExam.Text = colon.PRExam;
                Gender.SelectedItem = colon.Gender;
                Ileum.Text = colon.Ileum;
                Name.Text = colon.Name;
                Premedication.Text = colon.Premedication;
                Preparation.SelectedValue = colon.Preparation;
                Rectum.Text = colon.Rectum;
                Scope.SelectedItem = colon.Scope;
                DateTimePicker1.SelectedDate = colon.Date;
                ReferredDoctor.Text = colon.ReferredDoctor;
            }
        }

        public FullWindow Main { get; }
        public int? Id { get; }
        public ColonDataView? ColonDataView { get; }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            colon.Age = Age.Text;
            colon.AnalInspection = AnalInspection.Text;
            colon.Assistant = Assistant.Text;
            colon.ClinicalData = ClinicalData.Text;
            colon.ColonDetails = Colon.Text;
            colon.Conclusion = Conclusion.Text;
            colon.Endoscopist = Endoscopist.Text;
            colon.FileNo = FileNo.Text;
            colon.PRExam = PRExam.Text;
            colon.Gender = Gender.SelectedItem?.ToString();
            colon.Ileum = Ileum.Text;
            colon.Name = Name.Text;
            colon.Premedication = Premedication.Text;
            colon.Preparation = Preparation.SelectedItem?.ToString();
            colon.Rectum = Rectum.Text;
            colon.Scope = Scope.SelectedItem?.ToString();
            colon.Date = DateTimePicker1.SelectedDate?.Date ?? DateTime.UtcNow;
            colon.ReferredDoctor = ReferredDoctor.Text;
            colon = await _dataService.AddColon(colon);

            ColonDataView?.Load();


            if (!string.IsNullOrEmpty(Img1))
                _dataService.SetImage(Img1, nameof(Img1), colon.TypePhoto, colon.Id);
            if (!string.IsNullOrEmpty(Img2))
                _dataService.SetImage(Img2, nameof(Img2), colon.TypePhoto, colon.Id);
            if (!string.IsNullOrEmpty(Img3))
                _dataService.SetImage(Img3, nameof(Img3), colon.TypePhoto, colon.Id);

            Common.RenderColon(new ColonDto(colon));

        }

        private void UserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F4)
            {
                try
                {
                    var g = (TextBox)FocusManager.GetFocusedElement(Main);
                    if (g == null)
                        return;

                    _dialog.Close();
                    _dialog = new();
                    _dialog.DataContext = new KeyView(ChangeText, _dialog, Common.ColonsShoutCuts);
                    _dialog.ShowDialog();
                }
                catch(Exception ex) 
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void ChangeText(string value)
        {
            var MyTextBox = (TextBox)FocusManager.GetFocusedElement(Main);
            MyTextBox.Text += value;
            MyTextBox.Select(MyTextBox.Text.Length, 0);

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
            var main = new FullWindow();
            main.DataContext = new ColonView(Main);
            main.Show();

            Main.Close();
        }
    }
}
