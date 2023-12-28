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

namespace Placement_Cell_Management
{
    public partial class registration : Form
    {
        public static string ConnectionString = @"Data Source= DESKTOP-221DFGT\SQLEXPRESS;
                Initial Catalog=Placement Cell Management;Integrated Security=true";


        Boolean availability = false;

        public registration()
        {
            InitializeComponent();
            panel2.Visible = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void vScrollBar1_Scroll_1(object sender, ScrollEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Student_rbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (Student_rbtn.Checked)
            {

                panel3.Hide();
               
            }

        }

        private void alumni_rbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (alumni_rbtn.Checked)
            {
                panel3.Show();
               
            }
        }

        private void student1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usertype = Student_rbtn.Checked ? "Student" : "Alumni";

            string insertStudent = @"insert into Users(First_name,Last_name,Email_Id,Mob_No,Linkedin_Link,User_Type,Username,Password,Roll_No,course,Resume_Link,Designation,Experience,C_name)
           values('" + fname.Text + "', '" + lname.Text + "', '" + email.Text + "','" + mobno.Text + "','" + linkedinlink.Text + "','"+usertype+"','" + username.Text + "','" + password.Text + "'," +
           "'" + rollno.Text + "','" + course.Text + "','" +resumelink.Text + "','" + null + "', null ,'" + null + "')";


            string insertAlumni = @"insert into Users(First_name,Last_name,Email_Id,Mob_No,Linkedin_Link,User_Type,Username,Password,Roll_No,course,Resume_Link,Designation,Experience,C_name)
           values('" + fname.Text + "', '" + lname.Text + "', '" + email.Text + "','" + mobno.Text + "','" + linkedinlink.Text + "','" + usertype + "','" + username.Text + "','" + password.Text +
           "', null ,'" + null + "','" + null + "','" + des.Text + "','" + exp.Text + "','" + cname.Text + "')";


            try
            {
                if (password.Text.Equals(con_pass.Text) && availability)
                {
                    using (SqlConnection connection = new SqlConnection(ConnectionString))
                    {//users info
                        connection.Open();

                        if (usertype == "Student")
                        {
                            using (SqlCommand cmd = new SqlCommand(insertStudent, connection))
                            {
                                cmd.CommandText = insertStudent;

                                int numberofrowsaffected = cmd.ExecuteNonQuery();
                                if (numberofrowsaffected > 0)
                                {
                                    MessageBox.Show("Data Inserted Successfully");
                                    fname.Text = "";
                                    lname.Text = "";
                                    email.Text = "";
                                    mobno.Text = "";
                                    linkedinlink.Text = "";
                                    username.Text = "";
                                    password.Text = "";
                                    con_pass.Text = "";
                                    rollno.Text = "";
                                    course.Text = "";
                                    resumelink.Text = "";
                                    Form1 sign_in = new Form1();
                                    sign_in.Show();
                                    this.Hide();
                                }
                                else
                                {
                                    MessageBox.Show("Error: Something went wrong! Data not Inserted.");
                                }
                            }
                        }
                        else
                        {
                            using (SqlCommand cmd1 = new SqlCommand(insertAlumni, connection))
                            {
                                cmd1.CommandText = insertAlumni;

                                int numberofrowsaffected1 = cmd1.ExecuteNonQuery();
                                if (numberofrowsaffected1 > 0)
                                {
                                    MessageBox.Show("Data Inserted Successfully");
                                    fname.Text = "";
                                    lname.Text = "";
                                    email.Text = "";
                                    mobno.Text = "";
                                    linkedinlink.Text = "";
                                    username.Text = "";
                                    password.Text = "";
                                    con_pass.Text = "";
                                    rollno.Text = "";
                                    course.Text = "";
                                    resumelink.Text = "";
                                    des.Text = "";
                                    exp.Text = "";
                                    cname.Text = "";
                                    Form1 sign_in = new Form1();
                                    sign_in.Show();
                                    this.Hide();
                                }
                                else
                                {
                                    MessageBox.Show("Error: Something went wrong! Data not Inserted.");
                                }
                            }
                        }                   
                                
                          connection.Close();
                        }
                    }

                else
                {
                    if (availability == false)
                    { MessageBox.Show("username is not available"); }
                    else
                    { MessageBox.Show("Password and conform password are not matched."); }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void check_available_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            String checkquery = @"select username from Users where username='" + username.Text + "'";
          
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(checkquery, connection))
                    {
                        // Execute the query
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            MessageBox.Show("This username not available.");
                            availability = false;
                        }
                        else
                        {
                            MessageBox.Show("This username is available.");
                            availability = true;
                        }
                        connection.Close();
                    }
                }
            }
            catch (Exception i)
            {
                MessageBox.Show(i.Message);
            }
        }

        private void username_TextChanged(object sender, EventArgs e)
        {

        }
    }
    
}

