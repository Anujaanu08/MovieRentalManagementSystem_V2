using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalManagementSystem_V2
{
    internal class Movie
    {
        public string MovieId { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public decimal RentalPrice { get; set; }

        public Movie()
        {

        }
        public Movie( string title, string director, decimal rentalPrice)
        {
            
            Title = title;
            Director = director;
            RentalPrice = rentalPrice;
        }
        public Movie(string movieId, string title, string director, decimal rentalPrice)
        {
            MovieId = movieId;
            Title = title;
            Director = director;
            RentalPrice = rentalPrice;
        }
    }

}
