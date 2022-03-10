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

namespace SPORTSGO1
{
    public partial class SPORTSHOME : Form
    {
        public SPORTSHOME()
        {
            InitializeComponent();
            displayGSchedule();
            HoverLb.Visible = false;
        }
        SqlConnection con = new SqlConnection
           (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tongw\Documents\SportsGoDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void button1_Click(object sender, EventArgs e)
        {
            LoginForm1 L = new LoginForm1();
            L.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (PB1.Visible == true)
            {
                PB1.Visible = false;
                PB2.Visible = true;
            }
            else if (PB2.Visible == true)
            {
                PB2.Visible = false;
                PB3.Visible = true;
            }
            else if (PB3.Visible == true)
            {
                PB3.Visible = false;
                PB4.Visible = true;
            }
            else if (PB4.Visible == true)
            {
                PB4.Visible = false;
                PB1.Visible = true;
            }
        }
        private void SPORTSHOME_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
        private void homeBtn_Click(object sender, EventArgs e)
        {
            SPORTSHOME H = new SPORTSHOME();
            H.Show();
            this.Hide();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void displayGSchedule()
        {
            con.Open();
            string Query = "Select * from GameScheduleTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            DGV.DataSource = ds.Tables[0];
            con.Close();
        }

        private void label3_MouseHover(object sender, EventArgs e)
        {
            HoverLb.Visible = true;
            HoverLb.Text = "An online Sports management system for Coaches and athletes.";
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            HoverLb.Visible = false;
        }

        private void HoverLb_Click(object sender, EventArgs e)
        {

        }
    }
}
