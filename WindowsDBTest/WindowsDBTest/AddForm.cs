using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsDBTest
{
    public partial class AddForm : Form
    {
        DB db = new DB();
        MainForm main;

        public AddForm(MainForm main)
        {
            InitializeComponent();
            this.main = main;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            db.AddUser("users",this.username.Text, this.password.Text);
            main.loadBtn_Click(null, null);
            this.Close();
        }
    }
}
