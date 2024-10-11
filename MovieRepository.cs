using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalManagementSystem_V2
{
    internal class MovieRepository
    {
        private readonly string connectionstring = "Server=(localdb)\\MSSQLLocalDB;database=MovieRentalManagement;Integrated Security=true";
        public void AddMovie(Movie movie)
        {
            try
            {
                using (var conn = new SqlConnection(connectionstring))
                {
                    conn.Open();
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = @"insert into Movies (MovieId,Title,Director,RentalPrice)values(@MovieId,@Title,@Director,@RentalPrice)";
                    cmd.Parameters.AddWithValue("@MovieId", movie.MovieId);
                    cmd.Parameters.AddWithValue("@Title", movie.Title);
                    cmd.Parameters.AddWithValue("@Director", movie.Director);
                    cmd.Parameters.AddWithValue("@RentalPrice", movie.RentalPrice);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            
        }

        public void GetAllMovie()
        {
            try
            {
                using (var conn = new SqlConnection(connectionstring))
                {
                    conn.Open();
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = @"select * from  Movies ";
                    using (var reader = cmd.ExecuteReader()) 
                    {
                        while (reader.Read()) 
                        {
                            foreach (var movie in reader)
                            {
                                var mov = new Movie
                                {
                                    MovieId = reader.GetString(0),
                                    Title = reader.GetString(1),
                                    Director = reader.GetString(2),
                                    RentalPrice = reader.GetDecimal(3),
                                };
                                Console.WriteLine(mov);
                            }
                            Console.ReadLine();    
             
                        }
                    }
                   
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void GetMoviebyId(string id)
        {
            try
            {
                using (var conn = new SqlConnection(connectionstring))
                {
                    conn.Open();
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = @"select * from  Movies where MovieId = @MovieId";
                    cmd.Parameters.AddWithValue("@MovieId", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                               var mov = new Movie
                                {
                                    MovieId = reader.GetString(0),
                                    Title = reader.GetString(1),
                                    Director = reader.GetString(2),
                                    RentalPrice = reader.GetDecimal(3),
                                };
                                Console.WriteLine(mov);
                              

                        }
                        else
                        {
                            Console.WriteLine("invalid id");
                        }
                        Console.ReadLine();
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void UpdateMovie(Movie movie)
        {
            try
            {
                using (var conn = new SqlConnection(connectionstring))
                {
                    conn.Open();
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = @"update Movies set Title=@Title,Director=@Director,RentalPrice=@RentalPrice where MovieId=@MovieId";
                    cmd.Parameters.AddWithValue("@MovieId", movie.MovieId);
                    cmd.Parameters.AddWithValue("@Title", movie.Title);
                    cmd.Parameters.AddWithValue("@Director", movie.Director);
                    cmd.Parameters.AddWithValue("@RentalPrice", movie.RentalPrice);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void deleteMovie(string id)
        {
            try
            {
                using (var conn = new SqlConnection(connectionstring))
                {
                    conn.Open();
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = @"delete Movies where MovieId = @MovieId";
                    cmd.Parameters.AddWithValue("@MovieId",id);
                    
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
