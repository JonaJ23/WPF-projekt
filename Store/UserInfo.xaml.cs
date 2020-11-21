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

namespace Store
{
    /// <summary>
    /// Interaction logic for UserInfo.xaml
    /// </summary>
    
    public partial class UserInfo : Window
    {
        public UserInfo()
        {
            InitializeComponent();

            //Tillkallar info från usern genom använda State.User och sedan ta fram det jag vill ha, i detta fall info om kunden i kundens info-sida.
            MainLableName.Content = "Hi, " + State.User.Name; 
            UserNameTextBlock.Text = State.User.UserName;
            EmailTextBlock.Text = State.User.Email;
            MovieNamesBlock.Text = State.Pick.Title; //Får funka för stunden, så kunden iaf kan se namnet på filmen de hyrt.
        } 

        private void MainMenu_Click(object sender, RoutedEventArgs e) //Gör att användaren kan klicka tillbaka till huvudmenyn från användarmenyn.
        {
            var next_window = new MainWindow();
            next_window.Show();
            Close();
        }
    }
}
