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
    public partial class LoginForm1 : Form
    {
        public LoginForm1()
        {
            InitializeComponent();
        }
        public String getID()
        {
            String ID = IdTb.Text;
            return ID;
        }
        string Role = "";
        SqlConnection con = new SqlConnection
            (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tongw\Documents\SportsGoDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (roleCB.SelectedIndex == -1)
            {
                MessageBox.Show("Are you a player or a coach? ");
            }
            else if (roleCB.SelectedIndex == 0)
            {
                if (IdTb.Text == "" || loginPassTB.Text == "")
                {
                    MessageBox.Show("Enter Name and Password");
                }
                else
                {
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("Select count(*) from CoachTbl where Name='" + IdTb.Text + "' and Password='" + loginPassTB.Text + "'", con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        Role = "Coach";
                        COACHPROFILE Obj = new COACHPROFILE();
                        MessageBox.Show("welcome back " + Role + " " + IdTb.Text);
                        Obj.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Coach Not Found");
                    }
                    con.Close();
                }
            }
            else if (roleCB.SelectedIndex == 1)
            {
                if (IdTb.Text == "" || loginPassTB.Text == "")
                {
                    MessageBox.Show("Enter Name and Password");
                }
                else
                {
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("Select count(*) from PlayerTbl where Name='" + IdTb.Text + "' and Password='" + loginPassTB.Text + "'", con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        Role = "Player";
                        PLAYERPROFILE Obj = new PLAYERPROFILE();
                        MessageBox.Show("welcome back " + Role + " " + IdTb.Text);
                        Obj.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Player Not Found");
                    }
                    con.Close();
                }
            }
        }

        private void roleCB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void IdTb_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
