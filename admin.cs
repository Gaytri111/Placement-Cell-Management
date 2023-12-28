using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Net;

namespace Placement_Cell_Management
{
    public partial class admin : Form
    {
        public static string ConnectionString = @"Data Source= DESKTOP-221DFGT\SQLEXPRESS;
                Initial Catalog=Placement Cell Management;Integrated Security=true";


        public admin()
        {
            InitializeComponent();

        }




        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }


        //add drive label
        private void label2_Click(object sender, EventArgs e)
        {
            add_Drive.Show();
            student_info.Hide();
            alumni_info.Hide();
            feed.Hide();  
        }

        private void label13_Click(object sender, EventArgs e)
        {
           
        }

        //add about drive
        private void submit_Click(object sender, EventArgs e)
        {
            string insertquery = @"insert into Job(Company_name,Job_Role,stipend,Skill_Set,vacancy,Application_Deadline ,Web_Link)
           values('" + text_cname.Text + "', '" + txt_role.Text + "', '" + txt_stipend.Text + "','" + txt_skill.Text + "','" + txt_interns.Text + "','" + dateTimePicker1.Text+ "','" + web_link.Text + "') ";

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(insertquery, connection))
                    {
                        cmd.CommandText = insertquery;

                        int numberofrowsaffected = cmd.ExecuteNonQuery();
                        if (numberofrowsaffected > 0)
                        {
                            MessageBox.Show("Data Inserted Successfully");
                            text_cname.Text = "";
                            txt_role.Text = "";
                            txt_stipend.Text = "";
                            txt_skill.Text = "";
                            txt_interns.Text = "";
                            dateTimePicker1.Text = "";
                            web_link.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Error: Something went wrong! Data not Inserted.");
                        }
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //main page of form
        private void admin_Load(object sender, EventArgs e)
        {
        }


        //student info label
        private void label3_Click(object sender, EventArgs e)
        {
            LoadStudentData();
            student_info.Show();
            add_Drive.Hide();
            alumni_info.Hide();
            feed.Hide();
        }


        //student info
        private void LoadStudentData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string selectQuery = @"SELECT First_name,Last_name,Email_Id,Mob_No,Linkedin_Link,
                    Roll_No,course,Resume_Link FROM Users where User_Type='Student'";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(selectQuery, connection);
                    DataTable studentDataTable = new DataTable();
                    dataAdapter.Fill(studentDataTable);

                    dataGridView1.DataSource = studentDataTable;

                    // Attach the SelectionChanged event handler
                    //dataGridViewStudents.SelectionChanged += DataGridViewStudents_SelectionChanged;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        
        private void label10_Click(object sender, EventArgs e)
        {
        
        }

        private void student_info_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //remove or delete student
        private void button1_Click(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(ConnectionString))
                    {
                        connection.Open();

                        string query = "DELETE FROM Users WHERE First_name = '"+ search.Text+"'";
                        SqlCommand cmd = new SqlCommand(query, connection);
                        cmd.CommandText = query;

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("User deleted successfully.");
                            LoadStudentData(); // Refresh the DataGridView after deletion
                        }
                        else
                        {
                            MessageBox.Show("User deletion failed.");
                        }
                        connection.Close();
                    }                   
                }
                
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select a user to delete.");
            }

        }


        //to search student
        private void search_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string query = "select First_name, Last_name, Email_Id, Mob_No, Linkedin_Link, Roll_No, course," +
                        " Resume_Link  from Users where First_name like '"+search.Text+"'";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);


                    dataGridView1.DataSource = dataTable;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //Alumni info
        private void LoadAlumnitData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string selectQuery = @"SELECT First_name,Last_name,Email_Id,Mob_No,Linkedin_Link,
                    Designation,Experience,C_name FROM Users where User_Type='Alumni' ";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(selectQuery, connection);
                    DataTable alumniDataTable = new DataTable();
                    dataAdapter.Fill(alumniDataTable);

                    dataGridView2.DataSource = alumniDataTable;

                    // Attach the SelectionChanged event handler
                    //dataGridViewStudents.SelectionChanged += DataGridViewStudents_SelectionChanged;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }


        //alumni info label
        private void label4_Click(object sender, EventArgs e)
        {
            LoadAlumnitData();
            alumni_info.Show();
            student_info.Hide();
            add_Drive.Hide();
            feed.Hide();
        }


        //search alumni
        private void searchc_alumni_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT First_name,Last_name,Email_Id,Mob_No,Linkedin_Link,
                    Designation,Experience,C_name from Users where First_name like '" + search_alumni.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);


                    dataGridView2.DataSource = dataTable;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        //delete alumni 
        private void delete_alumni_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(ConnectionString))
                    {
                        connection.Open();

                        string query = "DELETE FROM Users WHERE First_name = '" + search_alumni.Text + "'";
                        SqlCommand cmd = new SqlCommand(query, connection);
                        cmd.CommandText = query;

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("User deleted successfully.");
                            LoadStudentData(); // Refresh the DataGridView after deletion
                        }
                        else
                        {
                            MessageBox.Show("User deletion failed.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select a user to delete.");
            }

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

            add_Drive.Hide();
            student_info.Hide();
            alumni_info.Hide();
            feed.Hide();
            this.Show();
        }


        //add study material
       /* private void label7_Click(object sender, EventArgs e)
        {
            Add_Study_m.Show();
            add_Drive.Hide();
            add_Drive.Hide();
            student_info.Hide();
            alumni_info.Hide();

        }*/

        //inserting study material
      /*  private void button2_Click(object sender, EventArgs e)
        {
            string query = @"insert into study_material(material_id,description,Topic_name,website_link)values
            ('" + id.Text + "','" + descriptiom.Text + "','" + topic_name.Text + "','" + site_link.Text + "')";

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    using(SqlCommand cmd =new SqlCommand(query,connection))
                    {
                        cmd.CommandText = query;
                        int numofrows= cmd.ExecuteNonQuery();
                        if(numofrows > 0)
                        {
                            MessageBox.Show("Data inserted successfully");
                            id.Text = "";
                            descriptiom.Text = "";
                            topic_name.Text = "";
                            site_link.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Error: Something went wrong! Data not Inserted.");
                        }
                    }
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }*/

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            student_info.Hide();
            alumni_info.Hide();
            add_Drive.Hide();
           feed.Show();

            try
            {
                //string query = @"SELECT * FROM JOb ORDER BY timestamp_column DESC LIMIT 1";
                string query = @"SELECT TOP 1 * FROM Feed ORDER BY interview_date DESC";
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            Ir.Text = reader["Interview_reviews"].ToString();
                            Iquestion.Text = reader["Interview_Q"].ToString();
                            cn.Text = reader["company_name"].ToString();
                            jr.Text = reader["Job_post"].ToString();
                        }
                        else
                        {

                            MessageBox.Show("Something is wrong");
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }



        }

        private void label21_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
