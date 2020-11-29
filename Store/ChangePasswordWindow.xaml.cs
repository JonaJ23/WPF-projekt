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

            if (OldPasswordBox.Password == State.User.Password)
            {
              
                State.User.Password = NewPasswordBox.Password;
                State.ctx.Customers.Update(State.User);
                State.ctx.SaveChanges();
                MessageBox.Show("You got a new password!", "New password successful", MessageBoxButton.OK, MessageBoxImage.Information);
                var UserInfoPage = new UserInfo();
                UserInfoPage.Show();
                this.Close();

            }
         
            else
            {
                MessageBox.Show("You have not put in correct information.", "Wrong Passsword", MessageBoxButton.OK, MessageBoxImage.Information);
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
