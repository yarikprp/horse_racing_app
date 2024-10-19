using horse_racing_app.Pages;
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
using System.Windows.Shapes;

namespace horse_racing_app.Windows
{
    /// <summary>
    /// Логика взаимодействия для FanWindow.xaml
    /// </summary>
    public partial class FanWindow : System.Windows.Window
    {
        public FanWindow()
        {
            InitializeComponent();
            CompetitionsAndRacesPage.Navigate(new CompetitionsAndRacesPage());
            СheckParticipantsPage.Navigate(new СheckParticipantsPage());
            CheckResultsPage.Navigate(new CheckResultsPage());
            DonatePage.Navigate(new DonatePage());
        }

        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}
