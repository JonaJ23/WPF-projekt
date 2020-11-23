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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
        /* TODO
         *  Fixa en Error om UserName används redan.
         */
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            //Lägger till ny användare samt hänvisar tillbaka till LoginWindow. 

            using (var ctx = new Context())
            {
                if (FirstName.Text.Length == 0)
                {          
                    MessageBox.Show("Please enter your first name.");                    
                }

                else if (UserName.Text.Length == 0)
                {
                    MessageBox.Show("Please enter a username.");
                }

                else if (PasswordField.Password.Length == 0)
                {
                    MessageBox.Show("Please enter a password.");
                }

                else if (Email.Text.Length == 0)
                {
                    MessageBox.Show("Please enter an e-mailadress.");
                }

                else
                {
                    State.User = API.GetCustomerByName(Email.Text);
                    if (State.User != null)
                    {
                        MessageBox.Show("Username already taken.");
                        UserName.Clear();
                    }

                    else
                    {
                        ctx.Customers.Add(new Customer { Name = FirstName.Text, UserName = UserName.Text, Password = PasswordField.Password, Email = Email.Text });
                        ctx.SaveChanges();

                        MessageBox.Show("You've made an account!");
                        var next_window = new LoginWindow();
                        next_window.Show();
                        this.Close();
                    }
                }
            }
        }
        // Hänvisar tillbaka till LoginWindow
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            var next_windowTwo = new LoginWindow();
            next_windowTwo.Show();
            this.Close();
        }
    }
}

