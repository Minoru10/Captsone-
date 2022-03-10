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
    public partial class COACHPROFILE : Form
    {
        public COACHPROFILE()
        {
            InitializeComponent();
            displayCoachInfo();
        }
        SqlConnection con = new SqlConnection
            (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tongw\Documents\SportsGoDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void picPB_Click(object sender, EventArgs e)
        {

        }

        private void HomeBtn_Click(object sender, EventArgs e)
        {
            SPORTSHOME H = new SPORTSHOME();
            H.Show();
            this.Hide();
        }
        private void displayRoster()
        {
            con.Open();
            string Query = "Select * from PlayerTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            coachDGV.DataSource = ds.Tables[0];
            con.Close();
        }
        private void displayGSchedule()
        {
            con.Open();
            string Query = "Select * from GameScheduleTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            coachDGV.DataSource = ds.Tables[0];
            con.Close();
        }
        private void displayPSchedule()
        {
            con.Open();
            string Query = "Select * from PracticeScheduleTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            coachDGV.DataSource = ds.Tables[0];
            con.Close();
        }

        private void rosterBtn_Click(object sender, EventArgs e)
        {
            displayRoster();
        }

        private void scheduleBtn_Click(object sender, EventArgs e)
        {
            displayGSchedule();
        }

        private void practiceBtn_Click(object sender, EventArgs e)
        {
            displayPSchedule();
        }

        private void addPlayer_Click(object sender, EventArgs e)
        {
            ADDPLAYER AP = new ADDPLAYER();
            AP.Show();
        }
        int key = 0;
        private void delP_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select the Player");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from PlayerTbl where Id=@Key", con);

                    cmd.Parameters.AddWithValue("@Key", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Player Deleted");
                    con.Close();
                    displayRoster();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void playerDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = coachDGV.CurrentCell.RowIndex;
            key = Convert.ToInt32(coachDGV.Rows[rowIndex].Cells[0].Value.ToString());
            MessageBox.Show(coachDGV.Rows[rowIndex].Cells[1].Value.ToString() + " selected");
        } 

        private void addGame_Click(object sender, EventArgs e)
        {
            ADDGAME AG = new ADDGAME();
            AG.Show();
        }

        private void delG_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select the Game");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from GameScheduleTbl where Id=@Key", con);

                    cmd.Parameters.AddWithValue("@Key", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Game Deleted");
                    con.Close();
                    displayGSchedule();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void addPractice_Click(object sender, EventArgs e)
        {
            ADDGAME AG = new ADDGAME();
            AG.Show();
        }

        private void delPR_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select the Game");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from PracticeScheduleTbl where Id=@Key", con);

                    cmd.Parameters.AddWithValue("@Key", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Practice Deleted");
                    con.Close();
                    displayPSchedule();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SPORTSHOME S = new SPORTSHOME();
            S.Show();
            this.Hide();
        }

        private void displayCoachInfo()
        {
            try
            {
                con.Open();
                var ID = IdLb.Text;
                SqlCommand cmd = new SqlCommand("Select * from CoachTbl", con);
                SqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    IdLb.Text = da.GetValue(0).ToString();
                    nameTb.Text = da.GetValue(1).ToString();
                    titleTB.Text = da.GetValue(5).ToString();
                    phoneTB.Text = da.GetValue(3).ToString();
                    emailTB.Text = da.GetValue(4).ToString();
                    picPB.Load(da.GetValue(8).ToString());
                    bioTB.Text = da.GetValue(7).ToString();
                    dobPK.Text = da.GetValue(2).ToString();

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
                SqlCommand cmd = new SqlCommand("update CoachTbl set image=@IM where Name=@N", con);
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

        private void editinfoBtn_Click(object sender, EventArgs e)
        {
            displayImage();
        }

        private void edit_Click(object sender, EventArgs e)
        {
             try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("update CoachTbl set Name=@N, DOB=@D, Phone=@P, Email=@E," +
                    " Title=@T, Bio=@B where Id=@K", con);

                cmd.Parameters.AddWithValue("@N", nameTb.Text);
                cmd.Parameters.AddWithValue("@D", dobPK.Value);
                cmd.Parameters.AddWithValue("@P", phoneTB.Text);
                cmd.Parameters.AddWithValue("@E", emailTB.Text);
                cmd.Parameters.AddWithValue("@T", titleTB.Text);
                cmd.Parameters.AddWithValue("@B", bioTB.Text);
                cmd.Parameters.AddWithValue("@K", IdLb.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Coach Info updated");
                con.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void COACHPROFILE_Load(object sender, EventArgs e)
        {

        }
    }
}
