using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace WindowsDBTest
{
    class DB
    {
        //declarations
        string connString = null;
        SqlConnection conn = null;
        public List<User> users = new List<User>();
        public List<User> searchResults;

        //fetch connection string 
        public static string ConnStringValue(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
        
        //load data
        public void LoadData(string name)
        {

            //clear list
            users.Clear();

            //get connectoin string
            connString = ConnStringValue(name);

            //connect
            conn = new SqlConnection(connString);
            conn.Open();

            //set up the query to load data...
            SqlCommand command = new SqlCommand("SELECT * FROM userInfo", conn);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                User u = new User();
                u.id = (int)reader["id"];
                u.un = (string)reader["un"];
                u.pw = (string)reader["pw"];
                users.Add(u);
            }

            conn.Close();
        }

        //add user
        public void AddUser(string name, string username, string password)
        {
            //get connectoin string for our table
            connString = ConnStringValue(name);

            //connect to server / db
            conn = new SqlConnection(connString);
            conn.Open();

            //Set up command...
            SqlCommand command = new SqlCommand("INSERT INTO userInfo (un,pw) VALUES (@username,@password)", conn);
            command.Parameters.Add(new SqlParameter("@username", username));
            command.Parameters.Add(new SqlParameter("@password", password));

            //execute command
            command.ExecuteNonQuery();

            conn.Close();
        }

        //delete user based on id
        public void DeleteUser(int id)
        {
            connString = ConnStringValue("users");

            conn = new SqlConnection(connString);

            conn.Open();

            SqlCommand command = new SqlCommand("DELETE FROM userInfo WHERE id=@id",conn);

            command.Parameters.Add(new SqlParameter("@id", id));

            command.ExecuteNonQuery();

            conn.Close();
        }

        //search by id
        public void attemptSearch(int id)
        {
            searchResults = new List<User>();

            searchResults.Clear();

            connString = ConnStringValue("users");

            conn = new SqlConnection(connString);

            conn.Open();

            SqlCommand command = new SqlCommand("SELECT * FROM userInfo WHERE id LIKE @id",conn);

            command.Parameters.Add(new SqlParameter("@id", "%"+id+"%"));

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                User u = new User();
                u.id = (int)reader["id"];
                u.un = (string)reader["un"];
                u.pw = (string)reader["pw"];
                searchResults.Add(u);
            }
        }
    }
}
