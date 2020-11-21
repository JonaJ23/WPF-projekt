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
            if (State.User != null)
            {
                if(State.User.Password == PasswordField.Password)
                { 
                var next_window = new MainWindow();
                next_window.Show();
                this.Close();
                }
                else
                {
                    MessageBox.Show("Wrong password, try again.");
                }
            }
            else
            {
                NameField.Text = "...";
            }
        }


        // Öppnar upp så Register knappen tar en till RegisterWindow när man trycker på kanppen
       private void Register_Click(object sender, RoutedEventArgs e)
        {
            var next_windowTwo = new Window1();
            next_windowTwo.Show();
            this.Close();
        } 
    }
}
