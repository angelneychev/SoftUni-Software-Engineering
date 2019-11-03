using System;
using System.Data.SqlClient;

namespace DB_APPS_INTRODUCTION
{
    class Program
    {
        static void Main()
        {
            //var town = new Town
            //{
            //    Name = "Sofia"
            //};

            // db.SaveChanges();

            //ORM
            //var towns = db
            //    .Towns
            //    .Where(t => t.Name == "Sofia")
            //    .ToList;

            var connetion = new SqlConnection(@"Server=ANGEL_LAPTOP\SQLEXPRESS; Database=SoftUni; Integrated Security=true");
            connetion.Open();

            string firstName = "Kevin";
           // int age = 5;

            using (connetion)
            {


                var command = new SqlCommand($"Select * From Employees where FirstName = @name", connetion);

                command.Parameters.AddWithValue("@name", firstName);
               // command.Parameters.AddWithValue("@age", age);

              //  var result = command.ExecuteScalar();
                var reader = command.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.Write(reader[i] + " ");
                        }
                        Console.WriteLine();
                        //var firstName = reader["FirstName"];
                        //var lastName = reader["LastName"];
                        //var title = reader["JobTitle"];
                        //var result = firstName + " " + lastName + " " + title;

                        //Console.WriteLine(result);
                    }

                }
            }

           
          //  var result = command.ExecuteReader();
        }
    }
}
