using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace db
{
    public class PersonMapper
    {

        private SqlConnection _connection;
        public PersonMapper()
        {
            _connection = new(DBInfo.connectionString);
        }


        public List<Person> GetPeople()
        {
            try
            {
                List<Person> list = [];

                _connection.Open();
                //put the right command in the quotes
                using SqlCommand cmd = new SqlCommand("SELECT p.Id as pId, p.name as pName, p.age as pAge," +
                                                      "s.Id as sId,s.name as sName FROM Person p join PersonSex ps on p.id = ps.PersonId " +
                                                      "join Sex s on ps.SexId = s.Id", _connection);
                using SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int id = (int)reader["pId"];
                        string name = (string)reader["Pname"];
                        int age = (int)reader["pAge"];
                        int SexId = (int)reader["sId"];
                        string SexName = (string)reader["sName"];
                        Sex s = new(SexId, SexName);
                        Person p = new(id, name, age,s);
                        list.Add(p);
                    }
                }
                return list;
            }
            finally
            {
                _connection.Close();
            }
        }


        public void DeletePerson(Person person)
        {
            try
            {
                _connection.Open();
                using SqlCommand cmd = new SqlCommand("DELETE FROM Person p WHERE p.name = {@id}", _connection);
                cmd.Parameters.AddWithValue("@id",person.Id);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                _connection.Close();
            }
        }
    }
}
