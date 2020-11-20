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
    public partial class MainWindow : Window


        /*   TODO
         * 1) Möjligtvis ändra om så vi har färre i row för få tydligare text?
         * 2) Lägga till så vi kan köra genres + ratings ( ? ) 
         */
    {
        public MainWindow()
        {
            InitializeComponent();

            State.Movies = API.GetMovieSlice(0, 30);
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

                            //skapar variable till movies name + lite info om utseendet.
                            var text = new Label() { };
                            text.Content = movie.Title; // Movies från databas
                            text.FontWeight = FontWeights.UltraBold;
                            text.FontFamily = new FontFamily("Sans-Serif");
                            text.FontSize = 11;

                           
                            //Björns kod + lite extra
                            var image = new Image() { };
                            image.Cursor = Cursors.Hand;
                            image.MouseUp += Image_MouseUp;
                            image.Cursor = Cursors.Hand; // ändrar om cursor.
                            image.MouseUp += Image_MouseUp; 
                            image.HorizontalAlignment = HorizontalAlignment.Center;
                            image.VerticalAlignment = VerticalAlignment.Center;
                            image.Source = new BitmapImage(new Uri(movie.ImageURL));
                            image.Height = 100;
                            image.Margin = new Thickness(4, 4, 4, 4);
                                
                            // så det tillhör rätt grid.
                            MovieGrid.Children.Add(text);
                            Grid.SetRow(text, y);
                            Grid.SetColumn(text, x);
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
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var x = Grid.GetColumn(sender as UIElement);
            var y = Grid.GetRow(sender as UIElement);

            int i = y * MovieGrid.ColumnDefinitions.Count + x;
            State.Pick = State.Movies[i];

            if(API.RegisterSale(State.User, State.Pick))
                MessageBox.Show("All is well and you can download your movie now.", "Sale Succeeded!", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("An error happened while buying the movie, please try again at a later time.", "Sale Failed!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }
         //Ger åtkomst till användarens konto via huvudmenyn.
        private void Account_Click(object sender, RoutedEventArgs e)
        {
            var next_window = new UserInfo();
            next_window.Show();
            Close();
        }
        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            var next_window = new LoginWindow();
            next_window.Show();
            Close();
        }
    }
}
