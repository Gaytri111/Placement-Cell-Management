using System;
using System.Collections;
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

    public partial class Homepage_Student : Form
    {
        public static string ConnectionString = @"Data Source= DESKTOP-221DFGT\SQLEXPRESS;
                Initial Catalog=Placement Cell Management;Integrated Security=true";

        public Homepage_Student()
        {
            InitializeComponent();
          /*  DataGridViewLinkColumn linkColumn = new DataGridViewLinkColumn();
            linkColumn.HeaderText = "Resume_Link";
            linkColumn.Name = "Resume_Link";
            linkColumn.DataPropertyName = "Resume_Link";
            dataGridView.Columns.Add(linkColumn);*/

        }

        public Homepage_Student(string username,string First_name,string company_name)
        {
            InitializeComponent();
            textBox8.Text = username;
            name.Text = First_name;
            com_name.Text = company_name;
        }
       
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lbl_stu_welcome_Click(object sender, EventArgs e)
        {

        }

        public void updates_lbl_stu_welcome(String fname)
        {
            lbl_stu_welcome.Text = "welcome " + fname + " !";
        }

        private void Homepage_Student_Load(object sender, EventArgs e)
        {

        }

        private void dashboard_st_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

         private void label2_Click(object sender, EventArgs e)
        {
            LoadProfiletData(); 
            dashboard_st.Show();
            update_resume.Hide();
            Drive_info.Hide();
            Feedback.Hide();
            feed.Hide();
            panel4.Hide();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            dashboard_st.Hide();
            update_resume.Hide();
            Drive_info.Hide();
            this.Show();
            stu_feedback.Hide();
            feed.Hide();
            panel4.Hide();
        }



        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LoadProfiletData()
        {
            try
            {
                string name = textBox8.Text;
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string selectQuery = @"SELECT First_name,Last_name,Email_Id,Mob_No,Linkedin_Link,
                    Roll_No,course,Resume_Link FROM Users where Username= '"+name+"'   ";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(selectQuery, connection);
                    DataTable ProfileDataTable = new DataTable();
                    dataAdapter.Fill(ProfileDataTable);

                    dataGridView.DataSource = ProfileDataTable;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void submit_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBox8.Text;
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    string update = @"update users set Resume_Link='" + resumelink.Text + "' where Username='" + name + "' ";
                    using (SqlCommand cmd = new SqlCommand(update, connection))
                    {
                        cmd.CommandText = update;
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Resume Updated Succesfully");
                        }
                        else
                        {
                            MessageBox.Show("Resue updation failed.");
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


        private void label3_Click(object sender, EventArgs e)
        {
            update_resume.Show();
            panel4.Hide();
            dashboard_st.Hide();
            Drive_info.Hide();
            stu_feedback.Hide();
            feed.Hide();

            try
            {
                string name = textBox8.Text;
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    string show = @"Select First_name,Last_name,C_name,Achievements from Users inner join Feed where username='" + name + "' ;";
                    using (SqlCommand cmd = new SqlCommand(show, connection))
                    { }
                }
            }
            catch(Exception ex )
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Drive_info.Show();
            update_resume.Hide();
            dashboard_st.Hide();
            stu_feedback.Hide();
            feed.Hide();
            panel4.Hide();

            try
          {
                //string query = @"SELECT * FROM JOb ORDER BY timestamp_column DESC LIMIT 1";
                string query = @"SELECT TOP 1 * FROM Job ORDER BY Application_Deadline DESC";
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                    {
                        connection.Open();

                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                           SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            cname.Text = reader["Company_name"].ToString();
                            job_role.Text = reader["Job_Role"].ToString() ;
                            stipend.Text = reader["stipend"].ToString();
                            skill.Text = reader["Skill_Set"].ToString();
                            vacancy.Text = reader["vacancy"].ToString();
                            deadline.Text = reader["Application_Deadline"].ToString();
                            web_link.Text = reader["Web_Link"].ToString();
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

        private void flowLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {
            Drive_info.Hide();
            update_resume.Hide();
            dashboard_st.Hide();
            stu_feedback.Hide();
            feed.Hide();
            panel4.Hide();
            this.Show();
        }

        private void add_ach_Click(object sender, EventArgs e)
        {

        }

        private void submit_achievment_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            stu_feedback.Show();
            Drive_info.Hide();
            update_resume.Hide();
            dashboard_st.Hide();
            feed.Hide();
            panel4.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void submit_feedback_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBox8.Text;
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    string update = @"insert into Feed(Interview_reviews,Interview_Q ,Job_post,company_name,username,interview_date)
                    values('" + Ireview.Text + "','" +IQ.Text + "','" +jobrole.Text + "','" +c_name.Text + "','" + name + "','" +date1.Text + "');";
                    using (SqlCommand cmd = new SqlCommand(update, connection))
                    {
                        cmd.CommandText = update;
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data inserted successfully");
                            Ireview.Text = " ";
                            IQ.Text = "";
                            jobrole.Text = "";
                            c_name.Text = "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exeption occured" + ex.Message);
            }

        }

        /* private void dataGridViewStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
         {
             if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView.Columns["Resume_Link"].Index)
             {
                 // Open the link in the default web browser
                 string link = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                 System.Diagnostics.Process.Start(link);
             }
         }

        private void dataGridViewStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView.Columns["Resume_Link"].Index)
            {
                try
                {
                    // Get the original Google Drive link
                    string originalLink = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                    // Modify the link to force download
                    string directDownloadLink = GetDirectDownloadLink(originalLink);

                    // Open the modified link in the default web browser
                    System.Diagnostics.Process.Start(directDownloadLink);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error opening link: {ex.Message}");
                }
            }
        }

        private string GetDirectDownloadLink(string originalLink)
        {
            // Replace the '/view' or '/edit' part of the link with '/export?format=pdf'
            return originalLink.Replace("/view", "/export?format=pdf").Replace("/edit", "/export?format=pdf");
        }
        */

        private void label30_Click(object sender, EventArgs e)
        {
            feed.Show();
            Drive_info.Hide();
            update_resume.Hide();
            dashboard_st.Hide();
            stu_feedback.Hide();
            panel4.Hide();

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

        private void label42_Click(object sender, EventArgs e)
        {
           
        }

        private void Ir_TextChanged(object sender, EventArgs e)
        {

        }

        private void label42_Click_1(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void label43_Click(object sender, EventArgs e)
        {
            feed.Hide();
            Drive_info.Hide();
            update_resume.Hide();
            dashboard_st.Hide();
            stu_feedback.Hide();
            panel4.Show();

            try
            {
                //string query = @"SELECT * FROM JOb ORDER BY timestamp_column DESC LIMIT 1";
                string query = @"SELECT TOP 1 * FROM achievment ORDER BY date DESC;
";
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            name.Text = reader["Name"].ToString();
                            com_name.Text = reader["company_name"].ToString();
                            achievment.Text = reader["achievment"].ToString();

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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}