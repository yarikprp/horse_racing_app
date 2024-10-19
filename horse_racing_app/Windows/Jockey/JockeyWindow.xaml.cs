using horse_racing_app.Pages;
using horse_racing_app.Pages.Jockey;
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

namespace horse_racing_app.Windows.Jockey
{
    /// <summary>
    /// Логика взаимодействия для JockeyWindow.xaml
    /// </summary>
    public partial class JockeyWindow : System.Windows.Window
    {
        public JockeyWindow()
        {
            InitializeComponent();
            ResultPage.Navigate(new ResultPage());
            RegistrationPage.Navigate(new RegistrationPage());
            CheckParticipantsPage.Navigate(new CheckParticipantsPage());
            InformationJockeyPage.Navigate(new InformationJockeyPage());
            InformationHorsesPage.Navigate(new InformationHorsesPage());
        }
    }
}
