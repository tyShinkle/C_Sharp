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

        int page = 0;

        //load form
        public MainForm()
        {
            InitializeComponent();
            GatherTextBoxes();
        }

        //load and data and call method to display it.
        public void loadBtn_Click(object sender, EventArgs e)
        {
            //if load button was clicked start from first page.
            if (sender == loadBtn)
            {
                page = 0;
            }

            //otherwise reload data without changing pages and display it.
            try
            {
                db.LoadData("users");
                DisplayData(db.users);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //Should only display 10 users and refernce the index within
        //the users list.
        public void DisplayData(List<User> list)
        {
            //clear text
            for (int i = 0; i < 30; i++)
            {
                textBoxes[i].Text = "";
            }

            try
            {
                //either fill all 10 rows or display all users.
                for (int i = 0; i < 10 && i < list.Count(); i++)
                {
                    textBoxes[0 + (i * 3)].Text = list[i + page * 10].id.ToString();
                    textBoxes[1 + (i * 3)].Text = list[i + page * 10].un;
                    textBoxes[2 + (i * 3)].Text = list[i + page * 10].pw;
                }
            }
            catch
            {
                return;
            }

        }

        //place text boxes in array
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

        //open form to add user
        private void addBtn_Click(object sender, EventArgs e)
        {
            //create & show form
            AddForm addForm = new AddForm(this);
            addForm.Show();
        }

        
        //delete user functions for each row
        private void del1_Click(object sender, EventArgs e)
        {
            try
            {
                db.DeleteUser(Int32.Parse(id1.Text));
                loadBtn_Click(null, null);
            }
            catch
            {
                MessageBox.Show("Could not delete record!");
            }

        }
        private void del2_Click(object sender, EventArgs e)
        {
            try
            {
                db.DeleteUser(Int32.Parse(id2.Text));
                loadBtn_Click(null, null);
            }
            catch
            {
                MessageBox.Show("Could not delete record!");
            }

        }
        private void del3_Click(object sender, EventArgs e)
        {
            try
            {
                db.DeleteUser(Int32.Parse(id3.Text));
                loadBtn_Click(null, null);
            }
            catch
            {
                MessageBox.Show("Could not delete record!");
            }

        }
        private void del4_Click(object sender, EventArgs e)
        {
            try
            {
                db.DeleteUser(Int32.Parse(id4.Text));
                loadBtn_Click(null, null);
            }
            catch
            {
                MessageBox.Show("Could not delete record!");
            }

        }
        private void del5_Click(object sender, EventArgs e)
        {
            try
            {
                db.DeleteUser(Int32.Parse(id5.Text));
                loadBtn_Click(null, null);
            }
            catch
            {
                MessageBox.Show("Could not delete record!");
            }

        }
        private void del6_Click(object sender, EventArgs e)
        {
            try
            {
                db.DeleteUser(Int32.Parse(id6.Text));
                loadBtn_Click(null, null);
            }
            catch
            {
                MessageBox.Show("Could not delete record!");
            }

        }
        private void del7_Click(object sender, EventArgs e)
        {
            try
            {
                db.DeleteUser(Int32.Parse(id7.Text));
                loadBtn_Click(null, null);
            }
            catch
            {
                MessageBox.Show("Could not delete record!");
            }

        }
        private void del8_Click(object sender, EventArgs e)
        {
            try
            {
                db.DeleteUser(Int32.Parse(id8.Text));
                loadBtn_Click(null, null);
            }
            catch
            {
                MessageBox.Show("Could not delete record!");
            }

        }
        private void del9_Click(object sender, EventArgs e)
        {
            try
            {
                db.DeleteUser(Int32.Parse(id9.Text));
                loadBtn_Click(null, null);
            }
            catch
            {
                MessageBox.Show("Could not delete record!");
            }

        }
        private void del10_Click(object sender, EventArgs e)
        {
            try
            {
                db.DeleteUser(Int32.Parse(id10.Text));
                loadBtn_Click(null, null);
            }
            catch
            {
                MessageBox.Show("Could not delete record!");
            }

        }

        //search by user ID
        private void searchID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                db.attemptSearch(Int32.Parse(searchID.Text));
                DisplayData(db.searchResults);
            }
            catch
            {
                //clear text
                for (int i = 0; i < 30; i++)
                {
                    textBoxes[i].Text = "";
                }

                return;
            }
        }

        //clear placeholder text and change color.
        private void searchID_Enter(object sender, EventArgs e)
        {
            searchID.Text = "";
            searchID.ForeColor = Color.Black;
        }

        //revert placeholder and color
        private void searchID_Leave(object sender, EventArgs e)
        {
            searchID.Text = "ID";
            searchID.ForeColor = System.Drawing.SystemColors.ControlDark;
        }
        
        //same for other search fields...
        private void searchUN_TextChanged(object sender, EventArgs e)
        {
            try
            {
                db.attemptSearch(searchUN.Text);
                DisplayData(db.searchResults);
            }
            catch
            {
                //clear text
                for (int i = 0; i < 30; i++)
                {
                    textBoxes[i].Text = "";
                }

                return;
            }
        }

        private void searchUN_Enter(object sender, EventArgs e)
        {
            searchUN.Text = "";
            searchUN.ForeColor = Color.Black;
        }

        private void searchUN_Leave(object sender, EventArgs e)
        {
            searchUN.Text = "Username";
            searchUN.ForeColor = System.Drawing.SystemColors.ControlDark;
        }

        //update buttons
        private void save1_Click(object sender, EventArgs e)
        {
            try
            {
                db.UpdateUser(Int32.Parse(id1.Text),un1.Text,pw1.Text);
                loadBtn_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void save2_Click(object sender, EventArgs e)
        {
            try
            {
                db.UpdateUser(Int32.Parse(id2.Text), un2.Text, pw2.Text);
                loadBtn_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void save3_Click(object sender, EventArgs e)
        {
            try
            {
                db.UpdateUser(Int32.Parse(id3.Text), un3.Text, pw3.Text);
                loadBtn_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void save4_Click(object sender, EventArgs e)
        {
            try
            {
                db.UpdateUser(Int32.Parse(id4.Text), un4.Text, pw4.Text);
                loadBtn_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void save5_Click(object sender, EventArgs e)
        {
            try
            {
                db.UpdateUser(Int32.Parse(id5.Text), un5.Text, pw5.Text);
                loadBtn_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void save6_Click(object sender, EventArgs e)
        {
            try
            {
                db.UpdateUser(Int32.Parse(id6.Text), un6.Text, pw6.Text);
                loadBtn_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void save7_Click(object sender, EventArgs e)
        {
            try
            {
                db.UpdateUser(Int32.Parse(id7.Text), un7.Text, pw7.Text);
                loadBtn_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void save8_Click(object sender, EventArgs e)
        {
            try
            {
                db.UpdateUser(Int32.Parse(id8.Text), un8.Text, pw8.Text);
                loadBtn_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void save9_Click(object sender, EventArgs e)
        {
            try
            {
                db.UpdateUser(Int32.Parse(id9.Text), un9.Text, pw9.Text);
                loadBtn_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void save10_Click(object sender, EventArgs e)
        {
            try
            {
                db.UpdateUser(Int32.Parse(id10.Text), un10.Text, pw10.Text);
                loadBtn_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            page++;
            DisplayData(db.users);
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            page--;
            DisplayData(db.users);
        }
    }
}
