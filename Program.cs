using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalManagementSystem_V2
{
    internal class Program
    {
        static MovieRepository repository = new MovieRepository();
        static void Main(string[] args)
        {
            menu();
        }

        static void menu()
        {

            bool loop = true;
            while (loop)
            {
                Console.Clear();
                Console.WriteLine("Movie Rental Management System:\r\n1. Add a Movie\r\n2. View All Movies\r\n3. Update a Movie\r\n4. Delete a Movie\r\n5. Exit");
                Console.Write("Choose an option: ");

                int opt = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (opt)
                {
                    case 1:
                                  Console.Write("Enter Movie Title: ");
                        string title = Console.ReadLine();
                        Console.Write("Enter Movie Director: ");
                        string director = Console.ReadLine();
                        Console.Write("Enter Movie rental price: ");
                        int price = int.Parse(Console.ReadLine());
                        
                        repository.AddMovie(new Movie(title,director,price));
                        Console.ReadLine();
                        break;
                    case 2:
                        repository.GetAllMovie();

                        break;
                    case 3:
                        Console.Write("Enter the movie id to update : ");
                        string movid = Console.ReadLine();
                        Console.Write("Enter Movie Title: ");
                        string newtitle = Console.ReadLine();
                        Console.Write("Enter Movie Director: ");
                        string newdirector = Console.ReadLine();
                        Console.Write("Enter Movie rental price: ");
                        decimal newprice = decimal.Parse(Console.ReadLine());
                        repository.UpdateMovie(new Movie(movid,newtitle,newdirector,newprice));
                        break;
                    case 4:
                        Console.Write("Enter the movie id to delete : ");
                        string delid = Console.ReadLine();
                        repository.deleteMovie(delid);
                        break;
                    case 5:
                        loop = false;
                        break;
                    default:
                        Console.WriteLine("Enter the correct option");
                        break;
                }

            }


        }
    }

}

