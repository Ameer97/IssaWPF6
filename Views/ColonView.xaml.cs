using IssaWPF6.Dtos;
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
            Scope.ItemsSource = new List<string> { Enum.Scope.Olympus, Enum.Scope.Pentax };

            DateTimePicker1.SelectedDate = DateTime.UtcNow.Date;
            Main = main;
        }

        public MainWindow Main { get; }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var f = await _dataService.AddColon(new Models.Colon
            {
                Age = Age.Text,
                AnalInspection = AnalInspection.Text,
                Assistant = Assistant.Text,
                ClinicalData = ClinicalData.Text,
                ColonDetails = Colon.Text,
                Conclusion = Conclusion.Text,
                Endoscopist = Endoscopist.Text,
                FileNo = FileNo.Text,
                PRExam = PRExam.Text,
                Gender = Gender.SelectedItem.ToString(),
                Ileum = Ileum.Text,
                Name = Name.Text,
                Premedication = Premedication.Text,
                Preparation = Preparation.SelectedItem.ToString(),
                Rectum = Rectum.Text,
                Scope = Scope.SelectedItem.ToString(),
                Date = DateTimePicker1.SelectedDate?.Date ?? DateTime.UtcNow,
                ReferredDoctor = ReferredDoctor.Text,
            });

            Common.RenderColon(new ColonDto(f));

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
