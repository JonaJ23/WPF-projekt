using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DatabaseConnection;

namespace Store
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
  
    public partial class LoginWindow : Window
    {
  
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            State.User = API.GetCustomerByName(NameField.Text.Trim());

            if (State.User == null)  // Kollar av om det är tom inmatning av användarnamn/lösenord.
            {
                if (NameField.Text.Length == 0)
                {
                    NameField.Text = "username";
                    PasswordField.Password = "password";
                    MessageBox.Show("Please enter a username.", "Missing input", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else if (PasswordField.Password.Length == 0)
                {
                    NameField.Text = "username";
                    PasswordField.Password = "password";
                    MessageBox.Show("Password is required, try again.", "Missing input", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {   // Ger svar om användaren inte finns registrerad i Customer-tabellen.
                    NameField.Text = "username";
                    PasswordField.Password = "password";
                    MessageBox.Show("Username not found, try again.", "Wrong input", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            
            else if (State.User != null) //Om användaren känns igen från Customer-tabellen.
            {
                if (State.User.Password == PasswordField.Password)
                {
                    var next_window = new MainWindow(); //Går vidare till huvudmenyn om lösenordet är korrekt.
                    next_window.Show();
                    this.Close();
                }
                else if (State.User.Password != PasswordField.Password) // Ger besked om lösenordet inte stämmer.
                {
                    NameField.Text = "username";
                    PasswordField.Password = "password";
                    MessageBox.Show("Wrong password, try again.", "Wrong input", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        // Öppnar upp så Register knappen tar en till RegisterWindow när man trycker på kanppen
        private void Register_Click(object sender, RoutedEventArgs e)
        {
            var next_windowTwo = new Window1();
            next_windowTwo.Show();
            this.Close();
        }
        
        private void UserNameClickRemove(object sender, MouseButtonEventArgs e)
        {
            NameField.Clear();
        }

        private void PasswordClickRemove(object sender, MouseButtonEventArgs e)
        {
            PasswordField.Clear();
        }
    }
}
