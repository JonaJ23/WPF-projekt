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
                if(PasswordField.Password.Length == 0)
                { 
                  if (FirstName.Text.Length == 0)             
                  {
                    if(Email.Text.Length == 0)
                    {
                        if(UserName.Text.Length == 0)
                        {
                           State.User = API.GetCustomerByName(UserName.Text);
                            if(State.User != null)
                            {
                                MessageBox.Show("Try again, you forgot something.");
                            }        
                        }
                    }                 
                  }
                }
                else
                {
                    ctx.Customers.Add(new Customer { Name = FirstName.Text, Email = Email.Text, UserName = UserName.Text, Password = PasswordField.Password});
                    ctx.SaveChanges();

                    MessageBox.Show("You've made an account.");
                    var nextWindow = new LoginWindow();
                    nextWindow.Show();
                    this.Close();
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

