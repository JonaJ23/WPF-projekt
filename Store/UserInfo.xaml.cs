using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using DatabaseConnection;



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
            MainLableName.Content = "Hi, " + State.User.Name + "!";
            UserNameTextBlock.Text = State.User.UserName;
            EmailTextBlock.Text = State.User.Email;
                
            for (int y = 0; y < CustomerMovieGrid.RowDefinitions.Count; y++)
            {
                for (int x = 0; x < CustomerMovieGrid.ColumnDefinitions.Count; x++)
                {
                    int i = y * CustomerMovieGrid.ColumnDefinitions.Count + x;

                    if (State.User.Sales == null)
                    {
                        CustomerMovieGrid.ColumnDefinitions.Clear();
                        CustomerMovieGrid.RowDefinitions.Clear();
                        
                    }

                    else if (i < State.User.Sales.Count)
                    {
                        
                        Rental rental = State.User.Sales[i];

                        var text = new Label() { };
                        text.Content = "Date: " + rental.Date + "\n" + rental.Movie.Title;
                        text.FontWeight = FontWeights.UltraBold;
                        text.FontFamily = new FontFamily("Sans-Serif");
                        text.Foreground = Brushes.White;
                        text.HorizontalAlignment = HorizontalAlignment.Center;
                        text.VerticalAlignment = VerticalAlignment.Top;
                        text.FontSize = 12;

                        var image = new Image() { };
                        image.HorizontalAlignment = HorizontalAlignment.Center;
                        image.VerticalAlignment = VerticalAlignment.Center;
                        image.Source = new BitmapImage(new Uri(rental.Movie.ImageURL));
                        image.Height = 100;
                        image.Margin = new Thickness(4, 4, 4, 4);

                        CustomerMovieGrid.Children.Add(text);
                        Grid.SetRow(text, y);
                        Grid.SetColumn(text, x);
                        CustomerMovieGrid.Children.Add(image);
                        Grid.SetRow(image, y);
                        Grid.SetColumn(image, x);
                      

                    }
                }
            }
         }
            

            private void MainMenu_Click(object sender, RoutedEventArgs e) //Gör att användaren kan klicka tillbaka till huvudmenyn från användarmenyn.
        {
            var next_window = new MainWindow();
            next_window.Show();
            Close();
        }

        private void NewPassword_Click(object sender, RoutedEventArgs e)
        {
            var next_window = new ChangePasswordWindow();
            next_window.Show();
            Close();
        }
    }
}
