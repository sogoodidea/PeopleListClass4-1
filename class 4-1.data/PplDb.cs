using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace class_4_1.data
{
    public class PplDb
    {
        private string _conStr = @"Data Source=.\sqlexpress;Initial Catalog=MySecondDb;Integrated Security=True;";

        public List<Person> GetPeople()
        {
            using (SqlConnection conn = new SqlConnection(_conStr))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM People";
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<Person> ppl = new List<Person>();
                while (reader.Read())
                {
                    ppl.Add(new Person
                    {
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                        Age = (int)reader["Age"]
                    });
                }
                return ppl;
            }
        }

        public void AddListPpl(List<Person> ppl)
        {
            foreach (Person p in ppl)
            {
                using (SqlConnection conn = new SqlConnection(_conStr))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO People(FirstName, LastName, Age)
                                        VALUES (@firstname, @lastname, @age)";
                    cmd.Parameters.AddWithValue("@firstname", p.FirstName);
                    cmd.Parameters.AddWithValue("@lastname", p.LastName);
                    cmd.Parameters.AddWithValue("@age", p.Age);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

