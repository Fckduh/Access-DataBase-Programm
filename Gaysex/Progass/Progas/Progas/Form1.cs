using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;

namespace Auto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection riki = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:sb.mdb");

                riki.Open();
                OleDbCommand login_data = riki.CreateCommand();
                OleDbCommand access_data = riki.CreateCommand();
                login_data.CommandText = "SELECT USER_NAME, PASSWORD FROM LOGIN WHERE USER_NAME = :LOG";
                access_data.CommandText = "SELECT ACCESS_LEVEL FROM LOGIN\r\nWHERE USER_NAME = :LOG";
                login_data.Parameters.Add(":LOG", OleDbType.VarChar, 128).Value = textBox1.Text;
                access_data.Parameters.Add(":LOG", OleDbType.VarChar, 128).Value = textBox1.Text;
                OleDbDataReader readerlog = login_data.ExecuteReader();
                OleDbDataReader readeracc = access_data.ExecuteReader();

                string pas = string.Empty;
                string path = Directory.GetCurrentDirectory();

                {

                }
                while (readerlog.Read())
                {
                    Access.log += readerlog["user_name"];
                    pas += readerlog["password"];

                }

                while (readeracc.Read())
                {
                    Access.acc += readeracc["access_level"];
                }

                readerlog.Close();
                readeracc.Close();
                riki.Close();

                if (textBox1.Text == Access.log && textBox2.Text == pas && textBox1.Text != "" && textBox2.Text != "")
                {
                    Form2 fr = new Form2(); 
                    fr.Show();
                    this.Hide();
                    FileStream fs = new FileStream($@"{path}\log.txt", FileMode.Append);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine("Пользователь: " + textBox1.Text + " с уровнем допуска " + Access.acc + " зашёл в " + DateTime.Now + " пароль: " + textBox2.Text);
                    sw.Close();
                    fs.Close();
                }

                else
                {
                    const string caption = "Ошибка";
                    var result = MessageBox.Show("Вы неверно ввели логин и пароль! Попробуйте еще раз.", caption,
                                            MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    if (result == DialogResult.OK)
                    {
                        textBox1.Text = "";
                        textBox2.Text = "";
                    }
                }
            }
            catch
            {
                OleDbConnection riki = new OleDbConnection(@"Provider=Microsoft.JET.OLEDB.4.0;Data Source=D:sb.mdb");

                riki.Open();
                OleDbCommand login_data = riki.CreateCommand();
                OleDbCommand access_data = riki.CreateCommand();
                login_data.CommandText = "SELECT USER_NAME, PASSWORD FROM LOGIN WHERE USER_NAME = :LOG";
                access_data.CommandText = "SELECT ACCESS_LEVEL FROM LOGIN\r\nWHERE USER_NAME = :LOG";
                login_data.Parameters.Add(":LOG", OleDbType.VarChar, 128).Value = textBox1.Text;
                access_data.Parameters.Add(":LOG", OleDbType.VarChar, 128).Value = textBox1.Text;
                OleDbDataReader readerlog = login_data.ExecuteReader();
                OleDbDataReader readeracc = access_data.ExecuteReader();

                string pas = string.Empty;
                string path = Directory.GetCurrentDirectory();

                {

                }
                while (readerlog.Read())
                {
                    Access.log += readerlog["user_name"];
                    pas += readerlog["password"];

                }

                while (readeracc.Read())
                {
                    Access.acc += readeracc["access_level"];
                }

                readerlog.Close();
                readeracc.Close();
                riki.Close();

                if (textBox1.Text == Access.log && textBox2.Text == pas && textBox1.Text != "" && textBox2.Text != "")
                {
                    Form2 fr = new Form2();
                    fr.Show();
                    this.Hide();
                    FileStream fs = new FileStream($@"{path}\log.txt", FileMode.Append);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine("Пользователь: " + textBox1.Text + " с уровнем допуска " + Access.acc + " зашёл в " + DateTime.Now + " пароль: " + textBox2.Text);
                    sw.Close();
                    fs.Close();
                }

                else
                {
                    const string caption = "Ошибка";
                    var result = MessageBox.Show("Вы неверно ввели логин и пароль! Попробуйте еще раз. ", caption,
                                            MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    if (result == DialogResult.OK)
                    {
                        textBox1.Text = "";
                        textBox2.Text = "";
                    }
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SQLTest SQL = new SQLTest();
            SQL.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
