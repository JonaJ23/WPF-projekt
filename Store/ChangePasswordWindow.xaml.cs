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
using MaterialDesignThemes;
using MaterialDesignColors;


namespace Store
{
    /// <summary>
    /// Interaction logic for ChangePasswordWindow.xaml
    /// </summary>
    public partial class ChangePasswordWindow : Window
    {
        public ChangePasswordWindow()
        {
            InitializeComponent();
        }

        //Lägger till ny Password
         private void NewPasswordButton(object sender, RoutedEventArgs e)
         {
            if (NewPasswordBox.Password.Length == 0)
            {
                MessageBox.Show("You have not put in all information.", "Missing input", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (OldPasswordBox.Password != State.User.Password)
            {
                MessageBox.Show("Wrong Password, please type in the correct Password.", "Wrong Password", MessageBoxButton.OK, MessageBoxImage.Information);    
            }
            else if (State.User.Password == NewPasswordBox.Password)
                MessageBox.Show("You're already using this Password, please type in a new one.", "Old Password", MessageBoxButton.OK, MessageBoxImage.Information);

            else if (OldPasswordBox.Password == State.User.Password)
            {
              
                State.User.Password = NewPasswordBox.Password;
                API.ctx.Customers.Update(State.User);
                API.ctx.SaveChanges();
                MessageBox.Show("You got a new Password!", "New Password successful", MessageBoxButton.OK, MessageBoxImage.Information);
                var UserInfoPage = new UserInfo();
                UserInfoPage.Show();
                this.Close();
            }
        }


        // clear texten i varje box
        private void OldPasswordBoxRemove(object sender, MouseButtonEventArgs e)
        {
            OldPasswordBox.Clear();
        }

        private void NewPasswordBoxRemove(object sender, MouseButtonEventArgs e)
        {
            NewPasswordBox.Clear();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var MainWindow = new MainWindow();
            MainWindow.Show();
            this.Close();

        }
    }

}
