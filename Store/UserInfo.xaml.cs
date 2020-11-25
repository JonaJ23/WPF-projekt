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

            int y = 0;
            int x = 0;
            var text = new Label() { };
            text.Content = State.Pick.Title; // Titel från databasen.
            CustomerMovieGrid.Children.Add(text);
            Grid.SetRow(text, y);
            Grid.SetColumn(text, x);

            var image = new Image()
            {

                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(4, 4, 4, 4),
            };

            try
            {
                image.Source = new BitmapImage(new Uri(State.Pick.ImageURL)); // Hämta hem bildlänken till RAM
            }
            catch (Exception e) when
                (e is ArgumentNullException ||
                 e is System.IO.FileNotFoundException ||
                 e is UriFormatException)
            {
                // Om något gick fel så lägger vi in en placeholder 
                image.Source = new BitmapImage(new Uri("https://wolper.com.au/wp-content/uploads/2017/10/image-placeholder.jpg"));
            }

            CustomerMovieGrid.Children.Add(image);
            Grid.SetRow(image, y);
            Grid.SetColumn(image, x);

        }

        private void MainMenu_Click(object sender, RoutedEventArgs e) //Gör att användaren kan klicka tillbaka till huvudmenyn från användarmenyn.
        {
            var next_window = new MainWindow();
            next_window.Show();
            Close();
        }
    }
}
