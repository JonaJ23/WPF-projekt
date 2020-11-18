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
                var next_window = new MainWindow();
                next_window.Show();
                this.Close();
            }
            else
            {
                NameField.Text = "...";
            }
        }


        // Öppnar upp så Register knappen tar en till RegisterWindow
        private void Register_Click(object sender, RoutedEventArgs e)
        {
            var next_window = new RegisterWindow();
            next_window.Show();
            this.Close();
        }
    }

    //Behövde skapa en class som säger åt att RegisterWindow ärver från Window. -- > Detta känns riktigt fult och behövs troligtvis lösas.
    public partial class RegisterWindow : Window
    { }





}
