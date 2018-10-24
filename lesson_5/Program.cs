//using System;
//using System.Data;
//using System.Data.SqlClient;

//namespace lesson_5
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            string connectionString =
//                @" Data source = (localdb)\MSSQLLocalDB;
//                initial catalog = Lesson7;
//                integrated security = True; 
//                Pooling = False";
//            Console.ReadLine();
//            try
//            {
//                var random = new Random();
//                for (int i = 0; i < 10; i++)
//                {
//                    var user = new User
//                    {
//                        FIO = $"FIO_{random.Next(0, 100)}",
//                        Birthday = $"16.08.2018",
//                        Email = $"email_{random.Next(0, 100)}domen@mail.ru",
//                        Phone = $"8(80{random.Next(0, 10)})555-35-3{random.Next(0, 10)}"
//                    };

//                    var sql = $@"INSERT INTO People (FIO, Birthday, Email, Phone)
//                    VALUES ('{user.FIO}', '{user.Birthday}', '{user.Email}', {user.Phone}')";

//                    Console.WriteLine(sql);
//                    Console.WriteLine();

//                    using (SqlConnection connection = new SqlConnection(connectionString))
//                    {
//                        connection.Open();

//                        SqlCommand command = new SqlCommand(sql);
//                        command.ExecuteNonQuery();
//                    }
//                }
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e.Message);
//            }
//            finally
//            {
//                Console.WriteLine("exit");
//            }

//            Console.ReadLine();
//        }        
//    }
//}


