using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace DatabaseConnection
{
    public class API
    {
        public static Context ctx = new Context();

        /* Tänker mig något sådant för att plocka ut genres sen.
         * 
        public static List<Movie> GetMovieGenre(string Genre)
        {
            using var ctx = new Context();
           
            ctx.Add(new SingleGenre() {Genre.split("|")};
            return ctx.SaveChanges() == 1;
        }

        */

        public static List<Movie> GetMovieByRating(int a, int b)
        {
            using var ctx = new Context();
            return ctx.Movies.OrderByDescending(r => r.Rating).Skip(a).Take(b).ToList();
        }
        

        public static List<Movie> GetMovieByName(string title)
        {     
            return ctx.Movies.AsEnumerable().Where(m => m.Title.Contains(title, StringComparison.OrdinalIgnoreCase)).ToList();
        }
        public static List<Movie> GetMovieSlice(int a, int b)
        {
            return ctx.Movies.OrderBy(m => m.Title).Skip(a).Take(b).ToList();
        }
        public static Customer GetCustomerByName(string name)
        {          
            return ctx.Customers.Include(c => c.Sales).FirstOrDefault(c => c.UserName.ToLower() == name.ToLower());
        }
        public static bool RegisterSale(Customer customer, Movie movie)
        {
            try
            {
                // Här säger jag åt contextet att inte oroa sig över innehållet i dessa records.
                // Om jag inte gör detta så kommer den att försöka updatera databasens Id och cracha.
                ctx.Entry(customer).State = EntityState.Unchanged;
                ctx.Entry(movie).State = EntityState.Unchanged;

                ctx.Add(new Rental() { Date = DateTime.Now, Customer = customer, Movie = movie });
                return ctx.SaveChanges() == 1;
            }
            catch(DbUpdateException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                System.Diagnostics.Debug.WriteLine(e.InnerException.Message);
                return false;
            }
        }
    }
}
