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
    public partial class PLAYERPROFILE : Form
    {
        public PLAYERPROFILE()
        {
            InitializeComponent();
            displayPInfo();
        }

        private void displayPInfo()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from PlayerTbl", con);
                SqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    IdLb.Text = da.GetValue(0).ToString();
                    nameTb.Text = da.GetValue(1).ToString();
                    dobPK.Value.Date.Equals(da.GetValue(2));
                    heightTB.Text = da.GetValue(3).ToString();
                    weightTB.Text = da.GetValue(4).ToString();
                    yearTB.Text = da.GetValue(5).ToString();
                    positionTB.Text = da.GetValue(6).ToString();
                    phoneTB.Text = da.GetValue(7).ToString();
                    emailTB.Text = da.GetValue(8).ToString();
                    picPB.Load(da.GetValue(10).ToString());
                    bioTB.Text = da.GetValue(11).ToString();
                }
                con.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message + "\nProfile Picture needed");
                con.Close();
                displayImage();
            }
        }

        SqlConnection con = new SqlConnection
            (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tongw\Documents\SportsGoDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void HomeBtn_Click(object sender, EventArgs e)
        {
            SPORTSHOME H = new SPORTSHOME();
            H.Show();
            this.Hide();
        }
        private void editinfoBtn_Click(object sender, EventArgs e)
        {
            displayImage();
        }
        private void displayImage()
        {
                OpenFileDialog OD = new OpenFileDialog();
                OD.FileName = "";
                OD.Filter = "Supported Images|*.jpg;*.jpeg;*.png";
                if (OD.ShowDialog() == DialogResult.OK)
                    picPB.Load(OD.FileName);
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update PlayerTbl set image=@IM where Name=@N", con);
                    cmd.Parameters.AddWithValue("@IM", OD.FileName);
                    cmd.Parameters.AddWithValue("@N", nameTb.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Profile picture updated");
                    con.Close();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
        }
        private void edit_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("update PlayerTbl set Name=@N, DOB=@D, Height=@H, Weight=@W, Year=@Y" +
                    ", Position=@PO, Phone=@P, Email=@E, Bio=@B where Id=@K", con);
                cmd.Parameters.AddWithValue("@N", nameTb.Text);
                cmd.Parameters.AddWithValue("@D", dobPK.Value);
                cmd.Parameters.AddWithValue("@H", heightTB.Text);
                cmd.Parameters.AddWithValue("@W", weightTB.Text);
                cmd.Parameters.AddWithValue("@Y", yearTB.Text);
                cmd.Parameters.AddWithValue("@PO", positionTB.Text);
                cmd.Parameters.AddWithValue("@P", phoneTB.Text);
                cmd.Parameters.AddWithValue("@E", emailTB.Text);
                cmd.Parameters.AddWithValue("@B", bioTB.Text);
                cmd.Parameters.AddWithValue("@K", IdLb.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Player Info updated");
                con.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void scheduleBtn_Click(object sender, EventArgs e)
        {
            displayGSchedule();
        }

        private void displayGSchedule()
        {
            con.Open();
            string Query = "Select * from GameScheduleTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            playerDGV.DataSource = ds.Tables[0];
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            displayPSchedule();
        }
        private void displayPSchedule()
        {
            con.Open();
            string Query = "Select * from PracticeScheduleTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            playerDGV.DataSource = ds.Tables[0];
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SPORTSHOME S = new SPORTSHOME();
            S.Show();
            this.Hide();
        }

        private void PLAYERPROFILE_Load(object sender, EventArgs e)
        {

        }

        private void playerDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
