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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Placement_Cell_Management
{
    public partial class Homepage_Alumni : Form
    {
        public static string ConnectionString = @"Data Source= DESKTOP-221DFGT\SQLEXPRESS;
                Initial Catalog=Placement Cell Management;Integrated Security=true";

        public Homepage_Alumni()
        {
            InitializeComponent();
        }

        public Homepage_Alumni(string username,string First_name,string company_name)
        {
            InitializeComponent();
            textBox8.Text = username;
            txt_name.Text = First_name;
            cname.Text= company_name;
        }
        private void Homepage_Alumni_Load(object sender, EventArgs e)
        {

        }

        public void update_lbl_al_welcome(String First_name)
        {
            lbl_al_welcome.Text = "welcome " + First_name + " !";
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            dashboard_alumni.Show();
            add_achievment.Hide();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            dashboard_alumni.Hide();
            add_achievment.Hide();
            this.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            add_achievment.Show();
            dashboard_alumni.Hide();
            
        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void submit_achievment_Click(object sender, EventArgs e)
        {
                try
                {
                string name = txt_name.Text;
                string company_name = cname.Text;
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    string insert = @"insert into achievment(Name, company_name,achievment,date)
                    values('" +name + "','" + company_name + "','" + award.Text + "','" + dateTimePicker1.Text + "');";
                    using (SqlCommand cmd = new SqlCommand(insert, connection))
                    {
                        cmd.CommandText = insert;
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data inserted successfully");
                            cname.Text = " ";
                            award.Text = "";
                            dateTimePicker1.Text = "";
                            txt_name.Text = "";
                        }
                    }
                }
                }
            catch (Exception ex)
            {
                MessageBox.Show("Exeption occured" + ex.Message);
            }

        }

        private void label42_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();

        }
    }
}
