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

namespace CRUD_Csharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

       

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }



        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-LN734PK;Initial Catalog=ProgrammingTutorialDB;Integrated Security=True"))
            {
                try
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("INSERT INTO Table_1(ProductId, ItemName, Design, Color, InsertDate) VALUES (@ProductId, @ItemName, @Design, @Color, @InsertDate)", con);

                    command.Parameters.AddWithValue("@ProductId", int.Parse(textBox1.Text));
                    command.Parameters.AddWithValue("@ItemName", textBox2.Text);
                    command.Parameters.AddWithValue("@Design", textBox3.Text);
                    command.Parameters.AddWithValue("@Color", comboBox1.Text);
                    command.Parameters.AddWithValue("@InsertDate", DateTime.Now);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Successfully Inserted.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void BindData()
        {
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-LN734PK;Initial Catalog=ProgrammingTutorialDB;Integrated Security=True"))
            {
                try
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("Select * from Table_1", con);
                    SqlDataAdapter sd = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    sd.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while fetching data: " + ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-LN734PK;Initial Catalog=ProgrammingTutorialDB;Integrated Security=True"))
            {
                try
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("UPDATE Table_1 SET ItemName = @ItemName, Design = @Design, Color = @Color WHERE ProductId = @ProductId", con);

                    command.Parameters.AddWithValue("@ProductId", int.Parse(textBox1.Text));
                    command.Parameters.AddWithValue("@ItemName", textBox2.Text);
                    command.Parameters.AddWithValue("@Design", textBox3.Text);
                    command.Parameters.AddWithValue("@Color", comboBox1.Text);
                    command.Parameters.AddWithValue("@InsertDate", DateTime.Now);
                    
                    command.ExecuteNonQuery();
                    MessageBox.Show("Successfully Updated.");
                    BindData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-LN734PK;Initial Catalog=ProgrammingTutorialDB;Integrated Security=True"))
                {
                    try
                    {
                        con.Open();
                        SqlCommand command = new SqlCommand("DELETE FROM Table_1 WHERE ProductID = '"+ int.Parse(textBox1.Text)+"'", con);

                        command.Parameters.AddWithValue("@ProductId", int.Parse(textBox1.Text));

                        command.ExecuteNonQuery();
                        MessageBox.Show("Successfully Deleted.");
                        BindData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter a Product ID.");
            }
        }
    }
}
