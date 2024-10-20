﻿using horse_racing_app.Model;
using horse_racing_app.Windows;
using horse_racing_app.Windows.Jockey;
using horse_racing_app.Windows.Judges;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using static MaterialDesignThemes.Wpf.Theme;

namespace horse_racing_app.Window
{
    /// <summary>  
    /// Логика взаимодействия для AuthorizationWindow.xaml  
    /// </summary>  
    public partial class AuthorizationWindow : System.Windows.Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            using (var context = new HorseRacingContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

                if (user != null)
                {
                    MessageBox.Show("Добро пожаловать, " + user.Username + "!");

                    if (user.RoleId == 1)
                    {
                        JudgesWindow judgesWindow = new JudgesWindow();
                        judgesWindow.Show();
                        this.Close();
                    }
                    else if (user.RoleId == 3)
                    {
                        JockeyWindow jockeyWindow = new JockeyWindow();
                        jockeyWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ошибка: Неизвестная роль пользователя.");
                    }
                }
                else
                {
                    MessageBox.Show("Ошибка: Неправильное имя пользователя или пароль.");
                }
            }
        }

        private void FanButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Добро пожаловать, болельщик!");
            FanWindow fanWindow = new FanWindow();
            fanWindow.Show();
            this.Close();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}