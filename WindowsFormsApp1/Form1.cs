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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        string connectString = "Data Source=DESKTOP-987I9KF\\SQLEXPRESS01;Initial Catalog=atele;Integrated Security = true;";

        //SqlCommandBuilder cmdbl;
        SqlDataAdapter adap;
        DataTable dt;
        public Form1()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            Reload_Data2();
        }
       
        private void Reload_Data2()
        {
            SqlConnection con = new SqlConnection(connectString);
            adap = new SqlDataAdapter(@"SELECT * FROM Materiali", con);
            dt = new DataTable();
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectString))
            {

                connection.Open();

                SqlCommand command = new SqlCommand("INSERT INTO Materiali (id, material, ves, razmer, cena) Values(@id, @material, @ves, @razmer, @cena)");
                command.Connection = connection;
                command.Parameters.AddWithValue("id", textBox5.Text);
                command.Parameters.AddWithValue("material", textBox1.Text);
                command.Parameters.AddWithValue("ves", textBox2.Text);
                command.Parameters.AddWithValue("razmer", textBox3.Text);
                command.Parameters.AddWithValue("cena", textBox4.Text);
                command.ExecuteNonQuery();
                MessageBox.Show("Выполнено");
                Reload_Data2();


            }
        }
    }
}
