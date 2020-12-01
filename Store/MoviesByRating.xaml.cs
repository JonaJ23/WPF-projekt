using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DatabaseConnection;

namespace Store
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MoviesByRating : Window
    {

        public MoviesByRating()
        {
            InitializeComponent();

            State.Movies = API.GetMovieByRating(0, 50);
            for (int y = 0; y < MovieGrid.RowDefinitions.Count; y++)
            {
                for (int x = 0; x < MovieGrid.ColumnDefinitions.Count; x++)
                {
                    int i = y * MovieGrid.ColumnDefinitions.Count + x;
                    if (i < State.Movies.Count)
                    {
                        var movie = State.Movies[i];

                        try
                        {

                            //Movie
                            var text = new Label() { };
                            text.Content = movie.Title; // Movies från databas
                            text.FontWeight = FontWeights.UltraBold;
                            text.FontFamily = new FontFamily("Sans-Serif");
                            text.Foreground = Brushes.White;
                            text.HorizontalAlignment = HorizontalAlignment.Center;
                            text.VerticalAlignment = VerticalAlignment.Top;
                            text.FontSize = 12;

                            // Rating and Genre
                            var genreRating = new Label() { };
                            genreRating.Content =
                            genreRating.Content = movie.Genre + " " + "(" + movie.Rating + "/10" + ")";
                            genreRating.HorizontalAlignment = HorizontalAlignment.Center;
                            genreRating.VerticalAlignment = VerticalAlignment.Bottom;
                            genreRating.FontWeight = FontWeights.UltraBold;
                            genreRating.Foreground = Brushes.White;
                            genreRating.FontSize = 12;
                            genreRating.FontFamily = new FontFamily("Sans-Serif");

                            //Björns kod + lite extra
                            var image = new Image() { };
                            image.Cursor = Cursors.Hand;
                            image.MouseUp += Image_MouseUp;
                            image.Cursor = Cursors.Hand; // ändrar om cursor. 
                            //image.MouseUp += Image_MouseUp; 
                            image.HorizontalAlignment = HorizontalAlignment.Center;
                            image.VerticalAlignment = VerticalAlignment.Center;
                            image.Source = new BitmapImage(new Uri(movie.ImageURL));
                            image.Height = 100;
                            image.Margin = new Thickness(4, 4, 4, 4);

                            // så det tillhör rätt grid.
                            MovieGrid.Children.Add(text);
                            Grid.SetRow(text, y);
                            Grid.SetColumn(text, x);
                            MovieGrid.Children.Add(genreRating);
                            Grid.SetRow(genreRating, y);
                            Grid.SetColumn(genreRating, x);
                            MovieGrid.Children.Add(image);
                            Grid.SetRow(image, y);
                            Grid.SetColumn(image, x);


                        }
                        catch (Exception e) when
                            (e is ArgumentNullException ||
                             e is System.IO.FileNotFoundException ||
                             e is UriFormatException)
                        {
                            continue;
                        }
                    }
                }
            }
            this.KeyDown += new KeyEventHandler(MainWindow_KeyDown);
        }

        //  Kod till search box 
        public void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                State.Movies.Clear();
                State.Movies.AddRange(API.GetMovieByName(SearchMovieBox.Text));
                var next_Searchwindow = new SearchWindow();
                next_Searchwindow.Show();
                Close();

                if (State.Movies.Count == 0)
                {
                    MessageBox.Show("No movie(s) were found.", "Search failed", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var ctx = new Context();
            var x = Grid.GetColumn(sender as UIElement);
            var y = Grid.GetRow(sender as UIElement);

            int i = y * MovieGrid.ColumnDefinitions.Count + x;
            State.Pick = State.Movies[i];

            MessageBoxResult option = MessageBox.Show("Do you wanna download this film?", "" + State.Pick.Title + "", MessageBoxButton.YesNo, MessageBoxImage.Question);
            switch (option)
            {
                case MessageBoxResult.Yes:
                    API.RegisterSale(State.User, State.Pick);
                    MessageBox.Show("The movie is now on your Account-page.", "Download Succeeded!", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }

        //Ger åtkomst till användarens konto via huvudmenyn.
        private void Account_Click(object sender, RoutedEventArgs e)
        {
            var next_window = new UserInfo();
            next_window.Show();
            Close();
        }

        //Loggar ut användaren. 
        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            var next_window = new LoginWindow();
            next_window.Show();
            Close();
        }

        private void TextRemove(object sender, MouseButtonEventArgs e)
        {
            SearchMovieBox.Clear();
        }

    }
}
