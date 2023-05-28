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

            var parameters = new List<KeyValuDto>
            {
                new KeyValuDto{ Key = "Age", Value = f.Age },
                new KeyValuDto{ Key = "AnalInspection", Value = f.AnalInspection },
                new KeyValuDto{ Key = "Assistant", Value = f.Assistant },
                new KeyValuDto{ Key = "ClinicalData", Value = f.ClinicalData },
                new KeyValuDto{ Key = "ColonDetails", Value = f.ColonDetails },
                new KeyValuDto{ Key = "Conclusion", Value = f.Conclusion },
                new KeyValuDto{ Key = "Endoscopist", Value = f.Endoscopist },
                new KeyValuDto{ Key = "FileNo", Value = f.FileNo },
                new KeyValuDto{ Key = "PRExam", Value = f.PRExam },
                new KeyValuDto{ Key = "Gender", Value = f.Gender },
                new KeyValuDto{ Key = "Ileum", Value = f.Ileum },
                new KeyValuDto{ Key = "Name", Value = f.Name },
                new KeyValuDto{ Key = "Premedication", Value = f.Premedication },
                new KeyValuDto{ Key = "Preparation", Value = f.Preparation },
                new KeyValuDto{ Key = "Rectum", Value = f.Rectum },
                new KeyValuDto{ Key = "Scope", Value = f.Scope },
                new KeyValuDto{ Key = "Date", Value = f.Date.ToString("dd-MM-yyyy") },
                new KeyValuDto{ Key = "ReferredDoctor", Value = f.ReferredDoctor },
            };

            Common.RenderReport(parameters);
            Main.DataContext = new StartView(Main);

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

        private async void ExcelButton_Click(object sender, RoutedEventArgs e)
        {
            await _dataService.ExportColons();
        }
    }
}
