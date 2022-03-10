using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPORTSGO1
{
    public partial class ADDGAME : Form
    {
        public ADDGAME()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection
            (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tongw\Documents\SportsGoDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void addPBtn_Click(object sender, EventArgs e)
        {
            if (idTB.Text == "" || dobPK.Text == "" || timeTB.Text == "" || locTB.Text == "" || teamTB.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into GameScheduleTbl(Id,Location,Date,Time,Team)" +
                        "values(@Id,@L,@D,@TI,@TE)", con);
                    cmd.Parameters.AddWithValue("@Id", idTB.Text);
                    cmd.Parameters.AddWithValue("@L", locTB.Text);
                    cmd.Parameters.AddWithValue("@D", dobPK.Value.Date);
                    cmd.Parameters.AddWithValue("@TI", timeTB.Text);
                    cmd.Parameters.AddWithValue("@TE", teamTB.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Team Added");
                    con.Close();
                    this.Close();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (idTB.Text == "" || dobPK.Text == "" || timeTB.Text == "" || locTB.Text == "" || teamTB.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into PracticeScheduleTbl(Id,Location,Date,Time,Team)" +
                        "values(@Id,@L,@D,@TI,@TE)", con);
                    cmd.Parameters.AddWithValue("@Id", idTB.Text);
                    cmd.Parameters.AddWithValue("@L", locTB.Text);
                    cmd.Parameters.AddWithValue("@D", dobPK.Value.Date);
                    cmd.Parameters.AddWithValue("@TI", timeTB.Text);
                    cmd.Parameters.AddWithValue("@TE", teamTB.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Team Added");
                    con.Close();
                    this.Close();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
    }
}
