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
    public partial class MainForm : Form
    {
        //Object instantiations
        DB db = new DB();
        TextBox[] textBoxes = new TextBox[30];

        //List<TextBox> textBoxes = new List<TextBox>();

        public MainForm()
        {
            InitializeComponent();
            GatherTextBoxes();
        }

        private void loadBtn_Click(object sender, EventArgs e)
        {
            try
            {
                db.LoadData("users");
                DisplayData();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //Should only display 10 users and refernce the index within
        //the users list.
        private void DisplayData()
        {
            for(int i = 0; i < 10 && i < db.users.Count(); i++)
            {
                textBoxes[0+(i*3)].Text = db.users[i].id.ToString();
                textBoxes[1+(i*3)].Text = db.users[i].un;
                textBoxes[2+(i*3)].Text = db.users[i].pw;
            }
        }

        private void GatherTextBoxes()
        {
            //row 1
            textBoxes[0] = id1;
            textBoxes[1] = un1;
            textBoxes[2] = pw1;
            
            //row 2
            textBoxes[3] = id2;
            textBoxes[4] = un2;
            textBoxes[5] = pw2;

            //row 3
            textBoxes[6] = id3;
            textBoxes[7] = un3;
            textBoxes[8] = pw3;

            //row 4
            textBoxes[9] = id4;
            textBoxes[10] = un4;
            textBoxes[11] = pw4;

            //row 5
            textBoxes[12] = id5;
            textBoxes[13] = un5;
            textBoxes[14] = pw5;

            //row 6
            textBoxes[15] = id6;
            textBoxes[16] = un6;
            textBoxes[17] = pw6;

            //row 7
            textBoxes[18] = id7;
            textBoxes[19] = un7;
            textBoxes[20] = pw7;

            //row 8
            textBoxes[21] = id8;
            textBoxes[22] = un8;
            textBoxes[23] = pw8;

            //row 9
            textBoxes[24] = id9;
            textBoxes[25] = un9;
            textBoxes[26] = pw9;

            //row 10
            textBoxes[27] = id10;
            textBoxes[28] = un10;
            textBoxes[29] = pw10;

        }
    }
}
