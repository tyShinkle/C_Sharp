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

        //fetch connection string 
        public static string ConnStringValue(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
        
        //load data
        public void LoadData(string name)
        {
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

        }
    }
}
