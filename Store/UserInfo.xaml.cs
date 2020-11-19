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
            MainLableName.Content = "Hi, ExampleUser!";
        }

        private void MainMenu_Click(object sender, RoutedEventArgs e) //Gör att användaren kan klicka tillbaka till huvudmenyn från användarmenyn.
        {
            var next_window = new MainWindow();
            next_window.Show();
            Close();
        }
    }
}
