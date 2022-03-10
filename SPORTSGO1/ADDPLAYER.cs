using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SPORTSGO1
{
    public partial class ADDPLAYER : Form
    {
        public ADDPLAYER()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection
            (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tongw\Documents\SportsGoDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void ADDP_Load(object sender, EventArgs e)
        {

        }

        private void addPBtn_Click(object sender, EventArgs e)
        {
            if (nameTb.Text == "" || idTB.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into PlayerTbl(Id, Name,DOB,Height,Weight," +
                        "Year,Position,Phone, Email)values(@Id,@N,@D,@H,@W,@Y,@HO,@P,@E)", con);
                    cmd.Parameters.AddWithValue("@Id", idTB.Text);
                    cmd.Parameters.AddWithValue("@N", nameTb.Text);
                    cmd.Parameters.AddWithValue("@D", dobPK.Value);
                    cmd.Parameters.AddWithValue("@H", heightTB.Text);
                    cmd.Parameters.AddWithValue("@W", weightTB.Text);
                    cmd.Parameters.AddWithValue("@Y", yearTB.Text);
                    cmd.Parameters.AddWithValue("@HO", townTB.Text);
                    cmd.Parameters.AddWithValue("@P", phoneTB.Text);
                    cmd.Parameters.AddWithValue("@E", emailTB.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Player Added");
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
            this.Close();
        }
    }
}
