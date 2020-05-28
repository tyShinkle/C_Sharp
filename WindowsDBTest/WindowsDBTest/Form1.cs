using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsDBTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        //CLEAN UP!!!
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn=null;
            try
            {
                //Create and connect to SQL on this machine! Connection string can also be used to decouple connection (App.config)
                conn = new SqlConnection(@"Data Source = (LocalDB)\SQL; Initial Catalog=Users; Integrated Security=true");
                
                //open connection
                conn.Open();

                //Set up query with the query itself and the connection.
                SqlCommand command = new SqlCommand("SELECT * FROM userInfo",conn);
                
                //You could also pass null as ther first parameter in the above instantiation and then...
                //command.CommandText = ("SELECT * FROM userInfo WHERE un='tyler'");

                /*
                    Make array of text boxes for 10 users at time (30 total)
                    Store reader into list!
                    Loop through to load the first 10 users then add a page button!
                    CLEAN !!
                 */

                //Read response and set our textBox to the value of the pw key!
                using(SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        userDataOneID.Text = reader["id"].ToString();
                        userDataOneUN.Text = reader["un"].ToString();
                        userDataOnePW.Text = reader["pw"].ToString();
                    }
                }

                //Close connection
                conn.Close();
            }
            catch (Exception ex)
            {
                userDataOneID.Text = ex.Message;
            }
        }
    }
}
