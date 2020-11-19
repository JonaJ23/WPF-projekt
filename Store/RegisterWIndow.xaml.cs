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

        /*private void Submit_Click(object sender, RoutedEventArgs e)
        {
            var next_windowTwo = new LoginWindow();
            next_windowTwo.Show();
            this.Close();
        }
        */
        // Register new customer
        /* TODO
         *  Fixa en try/catch om all info inte finns med.
         *  Fixa en Error om UserName används redan.
         * 
         */
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            //Lägga till ny användare.

            using (var ctx = new Context())
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
                 else
                {
                    ctx.Customers.Add(new Customer { Name = FirstName.Text, Email = Email.Text, UserName = UserName.Text });
                    ctx.SaveChanges();

                    MessageBox.Show("You've made an account.");
                    var nextWindow = new LoginWindow();
                    nextWindow.Show();
                    this.Close();
                }

            }

        }


        // Tar en tillbaka till LoginWindow
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            var next_windowTwo = new LoginWindow();
            next_windowTwo.Show();
            this.Close();
        }
        

    }
}

