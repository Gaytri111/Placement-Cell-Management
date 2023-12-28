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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Placement_Cell_Management
{
    public partial class Form1 : Form
    {
        public static string ConnectionString = $@"Data Source= DESKTOP-221DFGT\SQLEXPRESS;
                Initial Catalog=Placement Cell Management;Integrated Security=true";

        private Homepage_Student studentForm;
        private Homepage_Alumni alumniForm;

        public Form1(Homepage_Student studentForm)  //to customize form 
        {
            InitializeComponent();
            this.studentForm = studentForm;
        }

        public Form1(Homepage_Alumni alumniForm)  //to customize form 
        {
            InitializeComponent();
            this.alumniForm = alumniForm;
        }

        public Form1()
        {
            InitializeComponent();
        }

            private void username_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            registration reg = new registration();
            reg.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (username.Text.Equals("admin") && password.Text.Equals("123"))
            {
                this.Hide();
                admin admin = new admin();
                admin.Show();
                //MessageBox.Show("welcome admin");
            }
            else
            {
                string selectQuery = "SELECT First_name,C_name, User_Type, Username, Password FROM Users WHERE Username = @Username AND Password = @Password";

                try
                {
                    using (SqlConnection connection = new SqlConnection(ConnectionString))
                    {
                        connection.Open();

                        using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@Username", username.Text);
                            cmd.Parameters.AddWithValue("@Password", password.Text);

                            // Execute the query
                            SqlDataReader reader = cmd.ExecuteReader();

                            if (reader.Read())
                            {
                                string userType = reader["User_Type"].ToString().Trim();
                             
                                if (userType.Equals("Student"))
                                {
                                   
                                    this.Hide();
                                    string company_name = reader["C_name"].ToString();
                                    string First_name = reader["First_name"].ToString();
                                    Homepage_Student hs = new Homepage_Student(username.Text, First_name, company_name);
                                    hs.Show();
                                    //to customize form                                                                    
                                   hs.updates_lbl_stu_welcome(First_name);

                                }
                                else
                                {
                                    this.Hide();
                                    string First_name = reader["First_name"].ToString();
                                    string company_name= reader["C_name"].ToString();
                                    Homepage_Alumni ha = new Homepage_Alumni(username.Text,First_name,company_name);
                                    ha.Show();
                                    //to customize form
                                    ha.update_lbl_al_welcome(First_name);

                                }
                            }
                            else
                            {
                                MessageBox.Show("Invalid username or password");
                            }

                            reader.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

    }
}