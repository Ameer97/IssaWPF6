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
    /// Interaction logic for ColonKeyView.xaml
    /// </summary>
    public partial class KeyView : UserControl
    {

        private Action<string> ChangeTextAction;
        private readonly DialogWindow dialog = new DialogWindow();
        


        public KeyView()
        {
            InitializeComponent();
        }

        public KeyView(Action<string> action, DialogWindow dialog, List<string> shortcuts)
        {
            InitializeComponent();
            ChangeTextAction = action;
            this.dialog = dialog;
            ListView.ItemsSource = shortcuts;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var button = sender as Button;
                var g = (string)button.Tag;
                ChangeTextAction?.Invoke(g);
                dialog.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("1");
            }
            
        }
    }
}
