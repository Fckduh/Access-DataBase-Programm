using Auto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Login
{

    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
 
        Regex rx = new Regex(@"\D", RegexOptions.IgnoreCase);
    private void Form3_Load(object sender, EventArgs e)
        {
            try
            {
                textBox1.Enabled = false;
                OleDbConnection connection1 = new OleDbConnection($@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:sb.mdb");
                connection1.Open();
                OleDbCommand PUK = connection1.CreateCommand();
                PUK.CommandText = "SELECT MAX (ID) FROM LOGIN";
                OleDbDataReader seqreadr = PUK.ExecuteReader();
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                adapter.SelectCommand = new OleDbCommand("Select * From Login", connection1);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
                ds.Dispose();
                string sequence = string.Empty;
                while (seqreadr.Read())
                {
                    sequence += seqreadr[0];
                }
                int g;
                g = Convert.ToInt32(sequence) + 1;
                textBox1.Text = g.ToString();
            }
            catch
            {
                textBox1.Enabled = false;
                OleDbConnection connection1 = new OleDbConnection($@"Provider=Microsoft.JET.OLEDB.4.0;Data Source=D:sb.mdb");
                connection1.Open();
                OleDbCommand PUK = connection1.CreateCommand();
                PUK.CommandText = "SELECT MAX (ID) FROM LOGIN";
                OleDbDataReader seqreadr = PUK.ExecuteReader();
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                adapter.SelectCommand = new OleDbCommand("Select * From Login", connection1);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
                ds.Dispose();
                string sequence = string.Empty;
                while (seqreadr.Read())
                {
                    sequence += seqreadr[0];
                }
                int g;
                g = Convert.ToInt32(sequence) + 1;
                textBox1.Text = g.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
                    {
                        OleDbConnection connection1 = new OleDbConnection($@"Provider=Microsoft.JET.OLEDB.4.0;Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:sb.mdb");
                        connection1.Open();
                        DataSet ds = new DataSet();
                        OleDbDataAdapter adapter = new OleDbDataAdapter();
                        adapter.InsertCommand = new OleDbCommand("insert into LOGIN VALUES(:1,:2,:3,:4,:5)", connection1);
                        adapter.InsertCommand.Parameters.Add(":1", OleDbType.VarChar, 128).Value = textBox1.Text;
                        adapter.InsertCommand.Parameters.Add(":2", OleDbType.VarChar, 128).Value = textBox2.Text;
                        adapter.InsertCommand.Parameters.Add(":3", OleDbType.VarChar, 128).Value = textBox3.Text;
                        adapter.InsertCommand.Parameters.Add(":4", OleDbType.VarChar, 128).Value = textBox4.Text;
                        adapter.InsertCommand.Parameters.Add(":5", OleDbType.VarChar, 128).Value = textBox5.Text;
                        adapter.InsertCommand.ExecuteNonQuery();
                        MessageBox.Show("Пользователь добавлен", "",
                                MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        int g2;
                        g2 = Convert.ToInt32(textBox1.Text) + 1;
                        textBox1.Text = g2.ToString();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();
                        textBox5.Clear();

                        adapter.SelectCommand = new OleDbCommand("Select * From Login", connection1);
                        adapter.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                        ds.Dispose();
                        adapter.Dispose();
                        connection1.Close();
                    }
                    else
                    {
                        const string caption = "Ошибка";
                        var resilt = MessageBox.Show("Введите данные для добавления пользователя! " +
                            "" +
                            "System.Data.OleDb.OleDbException: Data type mismatch in criteria expression.", caption,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        if (resilt == DialogResult.OK)
                        {

                            textBox2.Text = "";
                            textBox3.Text = "";
                            textBox4.Text = "";
                            textBox5.Text = "";
                        }
                    }
                }
                catch
                {
                    if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
                    {
                        OleDbConnection connection1 = new OleDbConnection($@"Provider=Microsoft.JET.OLEDB.4.0;Data Source=D:sb.mdb");
                        connection1.Open();
                        DataSet ds = new DataSet();
                        OleDbDataAdapter adapter = new OleDbDataAdapter();
                        adapter.InsertCommand = new OleDbCommand("insert into LOGIN VALUES(:1,:2,:3,:4,:5)", connection1);
                        adapter.InsertCommand.Parameters.Add(":1", OleDbType.VarChar, 128).Value = textBox1.Text;
                        adapter.InsertCommand.Parameters.Add(":2", OleDbType.VarChar, 128).Value = textBox2.Text;
                        adapter.InsertCommand.Parameters.Add(":3", OleDbType.VarChar, 128).Value = textBox3.Text;
                        adapter.InsertCommand.Parameters.Add(":4", OleDbType.VarChar, 128).Value = textBox4.Text;
                        adapter.InsertCommand.Parameters.Add(":5", OleDbType.VarChar, 128).Value = textBox5.Text;
                        adapter.InsertCommand.ExecuteNonQuery();
                        MessageBox.Show("Пользователь добавлен", "",
                                MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        int g2;
                        g2 = Convert.ToInt32(textBox1.Text) + 1;
                        textBox1.Text = g2.ToString();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();
                        textBox5.Clear();

                        adapter.SelectCommand = new OleDbCommand("Select * From Login", connection1);
                        adapter.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                        ds.Dispose();
                        adapter.Dispose();
                        connection1.Close();
                    }
                    else
                    {
                        const string caption = "Ошибка";
                        var resilt = MessageBox.Show("Введите данные для добавления пользователя! " +
                            "" +
                            "System.Data.OleDb.OleDbException: Data type mismatch in criteria expression.", caption,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        if (resilt == DialogResult.OK)
                        {

                            textBox2.Text = "";
                            textBox3.Text = "";
                            textBox4.Text = "";
                            textBox5.Text = "";
                        }
                    }
                }
            }
            catch(InvalidOperationException)
            {
                const string caption = "Ошибка";
                var resilt = MessageBox.Show("В программе произошла непредвиденная ошибка", caption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 sre = new Form2();
            sre.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.Text = rx.Replace(textBox3.Text, "");
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox4.Text = rx.Replace(textBox4.Text, "");
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            textBox5.Text = rx.Replace(textBox5.Text, "");
        }
    }
}
