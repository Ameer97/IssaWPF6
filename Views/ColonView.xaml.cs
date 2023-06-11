using IssaWPF6.Dtos;
using IssaWPF6.Models;
using IssaWPF6.Service;
using IssaWPF6.Windows;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
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
        public ColonView()
        {
            InitializeComponent();
        }

        public ColonView(MainWindow main)
        {
            InitializeComponent();
            _dataService = new DataService();

            Preparation.ItemsSource = new List<string> { Enum.Preparation.Good, Enum.Preparation.Bad, Enum.Preparation.Fair };
            Gender.ItemsSource = new List<string> { Enum.Gender.Male, Enum.Gender.Female };
            Scope.ItemsSource = new List<string> { Enum.Scope.Olympus, Enum.Scope.Pentax, Enum.Scope.Fujifilm };

            DateTimePicker1.SelectedDate = DateTime.UtcNow.Date;
            Main = main;
        }

        public MainWindow Main { get; }

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

            Common.RenderColon(new ColonDto(colon));

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
                    _dialog.DataContext = new KeyView((TextBox)g, _dialog, Common.ColonsShoutCuts);
                    _dialog.ShowDialog();
                }
                catch { }
            }
        }

    }
}
