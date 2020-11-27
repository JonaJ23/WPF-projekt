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
    /// Interaction logic for ChangePasswordWindow.xaml
    /// </summary>
    public partial class ChangePasswordWindow : Window
    {
        public ChangePasswordWindow()
        {
            InitializeComponent();
        }

        private void ExistingPasswordBoxClick(object sender, MouseButtonEventArgs e)
        {
            OldPasswordBox.Clear();
        }

        private void NewPasswordBoxClick1(object sender, MouseButtonEventArgs e)
        {
            NewPasswordBox.Clear();
        }

       /* private void ChangePasswordButton(object sender, RoutedEventArgs e)
        {
        /// Ska skriva in kod så de kopplas till SQL databasen samt lösenorden ändras när man klickar på "changepssword"
        }

        */
    }

}
