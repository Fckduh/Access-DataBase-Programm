using Login;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Auto
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            if (Access.acc == "0")
            {
                sQLToolStripMenuItem.Visible = false;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string path = Directory.GetCurrentDirectory();
            this.Text = " ReportProg user: " + Access.log + " Время входа " + DateTime.Now;
            FileStream fs = new FileStream($@"{ path }\log.txt", FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("Пользователь: " + Access.log + " зашёл в " + DateTime.Now);
            sw.Close();
            fs.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void запрос1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection riki = new OleDbConnection($@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:sb.mdb");
                riki.Open();
                DataSet ds = new DataSet();
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                if (textBox1.Text != "" && textBox2.Text == "")
                {
                    adapter.SelectCommand = new OleDbCommand("SELECT * FROM EMPLOYEE WHERE FIO = :FIO", riki);
                    adapter.SelectCommand.Parameters.Add(":FIO", OleDbType.VarChar, 128).Value = textBox1.Text;
                }
                if (textBox2.Text != "" && textBox1.Text == "")
                {
                    adapter.SelectCommand = new OleDbCommand("SELECT * FROM EMPLOYEE WHERE TAB_NUM = :TAB_NUM", riki);
                    adapter.SelectCommand.Parameters.Add(":TAB_NUM", OleDbType.VarChar, 128).Value = textBox1.Text;
                }
                if (textBox1.Text == "" && textBox2.Text == "")
                {
                    adapter.SelectCommand = new OleDbCommand("SELECT * FROM EMPLOYEE", riki);
                }
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                ds.Dispose();
                adapter.Dispose();
                riki.Dispose();


                string path = Directory.GetCurrentDirectory();
                FileStream fs = new FileStream($@"{path}\log.txt", FileMode.Append);
                StreamWriter sw = new StreamWriter(fs);
                if (Access.acc == "-1")
                {
                    sw.WriteLine("Пользователь: " + Access.log + ", и с уровнем допуска " + Access.acc + " Не должен иметь доступ к этой кнопке " + DateTime.Now);
                }
                else
                {
                    sw.WriteLine("Пользователь " + Access.log + " нажал на кнопку (Все данные) и ошибок не было " + DateTime.Now);
                }
                sw.WriteLine("Показано строк: " + dataGridView1.RowCount);
                sw.Close();
                fs.Close();
            }
            catch
            {
                OleDbConnection riki = new OleDbConnection($@"Provider=Microsoft.JET.OLEDB.4.0;Data Source=D:sb.mdb");
                riki.Open();
                DataSet ds = new DataSet();
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                if (textBox1.Text != "" && textBox2.Text == "")
                {
                    adapter.SelectCommand = new OleDbCommand("SELECT * FROM EMPLOYEE WHERE FIO = :FIO", riki);
                    adapter.SelectCommand.Parameters.Add(":FIO", OleDbType.VarChar, 128).Value = textBox1.Text;
                }
                if (textBox2.Text != "" && textBox1.Text == "")
                {
                    adapter.SelectCommand = new OleDbCommand("SELECT * FROM EMPLOYEE WHERE TAB_NUM = :TAB_NUM", riki);
                    adapter.SelectCommand.Parameters.Add(":TAB_NUM", OleDbType.VarChar, 128).Value = textBox1.Text;
                }
                if (textBox1.Text == "" && textBox2.Text == "")
                {
                    adapter.SelectCommand = new OleDbCommand("SELECT * FROM EMPLOYEE", riki);
                }
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                ds.Dispose();
                adapter.Dispose();
                riki.Dispose();


                string path = Directory.GetCurrentDirectory();
                FileStream fs = new FileStream($@"{path}\log.txt", FileMode.Append);
                StreamWriter sw = new StreamWriter(fs);
                if (Access.acc == "-1")
                {
                    sw.WriteLine("Пользователь: " + Access.log + ", и с уровнем допуска " + Access.acc + " Не должен иметь доступ к этой кнопке " + DateTime.Now);
                }
                else
                {
                    sw.WriteLine("Пользователь " + Access.log + " нажал на кнопку (Все данные) и ошибок не было " + DateTime.Now);
                }
                sw.WriteLine("Показано строк: " + dataGridView1.RowCount);
                sw.Close();
                fs.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void запрос2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection riki = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=""D:sb.mdb""");
                riki.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT* FROM EMPLOYEE WHERE TAB_NUM=:TUB_NUM", riki);
                adapter.SelectCommand.Parameters.Add(":TAB_NUM", OleDbType.WChar, 128).Value = textBox2.Text;
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                ds.Dispose();
                adapter.Dispose();
                riki.Dispose();
                string path = Directory.GetCurrentDirectory();
                FileStream fs = new FileStream($@"{path}\log.txt", FileMode.Append);
                StreamWriter sw = new StreamWriter(fs);
                if (Access.acc == "-1")
                {
                    sw.WriteLine("Пользователь: " + Access.log + ", и с уровнем допуска " + Access.acc + " Не должен иметь доступ к этой кнопке " + DateTime.Now);
                }
                else
                {
                    sw.WriteLine("Пользователь " + Access.log + " нажал на кнопку (Поиск по номеру) и ошибок не было " + DateTime.Now);
                }
                sw.WriteLine("Показано строк: " + dataGridView1.RowCount);
                sw.Close();
                fs.Close();
            }
            catch
            {
                OleDbConnection riki = new OleDbConnection(@"Provider=Microsoft.JET.OLEDB.4.0;Data Source=""D:sb.mdb""");
                riki.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT* FROM EMPLOYEE WHERE TAB_NUM=:TUB_NUM", riki);
                adapter.SelectCommand.Parameters.Add(":TAB_NUM", OleDbType.WChar, 128).Value = textBox2.Text;
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                ds.Dispose();
                adapter.Dispose();
                riki.Dispose();
                string path = Directory.GetCurrentDirectory();
                FileStream fs = new FileStream($@"{path}\log.txt", FileMode.Append);
                StreamWriter sw = new StreamWriter(fs);
                if (Access.acc == "-1")
                {
                    sw.WriteLine("Пользователь: " + Access.log + ", и с уровнем допуска " + Access.acc + " Не должен иметь доступ к этой кнопке " + DateTime.Now);
                }
                else
                {
                    sw.WriteLine("Пользователь " + Access.log + " нажал на кнопку (Поиск по номеру) и ошибок не было " + DateTime.Now);
                }
                sw.WriteLine("Показано строк: " + dataGridView1.RowCount);
                sw.Close();
                fs.Close();
            }
        }

        private void запрос3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection riki = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=""D:sb.mdb""");
                riki.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT* FROM EMPLOYEE WHERE FIO LIKE :FIO + '%'", riki);
                adapter.SelectCommand.Parameters.Add(":FIO", OleDbType.WChar, 128).Value = textBox1.Text;
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                ds.Dispose();
                adapter.Dispose();
                riki.Dispose();
                string path = Directory.GetCurrentDirectory();
                FileStream fs = new FileStream($@"{path}\log.txt", FileMode.Append);
                StreamWriter sw = new StreamWriter(fs);
                if (Access.acc == "-1")
                {
                    sw.WriteLine("Пользователь: " + Access.log + ", и с уровнем допуска " + Access.acc + " Не должен иметь доступ к этой кнопке " + DateTime.Now);
                }
                else
                {
                    sw.WriteLine("Пользователь " + Access.log + " нажал на кнопку (Поиск по имени) и ошибок не было " + DateTime.Now);
                }
                sw.WriteLine("Показано строк: " + dataGridView1.RowCount);
                sw.Close();
                fs.Close();
            }
            catch
            {
                OleDbConnection riki = new OleDbConnection(@"Provider=Microsoft.JET.OLEDB.4.0;Data Source=""D:sb.mdb""");
                riki.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT* FROM EMPLOYEE WHERE FIO LIKE :FIO + '%'", riki);
                adapter.SelectCommand.Parameters.Add(":FIO", OleDbType.WChar, 128).Value = textBox1.Text;
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                ds.Dispose();
                adapter.Dispose();
                riki.Dispose();
                string path = Directory.GetCurrentDirectory();
                FileStream fs = new FileStream($@"{path}\log.txt", FileMode.Append);
                StreamWriter sw = new StreamWriter(fs);
                if (Access.acc == "-1")
                {
                    sw.WriteLine("Пользователь: " + Access.log + ", и с уровнем допуска " + Access.acc + " Не должен иметь доступ к этой кнопке " + DateTime.Now);
                }
                else
                {
                    sw.WriteLine("Пользователь " + Access.log + " нажал на кнопку (Поиск по имени) и ошибок не было " + DateTime.Now);
                }
                sw.WriteLine("Показано строк: " + dataGridView1.RowCount);
                sw.Close();
                fs.Close();
            }
        }
        private void SQLTest_Load(object sender, EventArgs e)
        {

        }

        private void sQLToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            SQLTest SQL = new SQLTest();
            SQL.Show();
            string path = Directory.GetCurrentDirectory();
            FileStream fs = new FileStream($@"{path}\log.txt", FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            if(Access.acc == "-1")
            {
                sw.WriteLine("Пользователь: " +Access.log + ", и с уровнем допуска " +Access.acc +" Не должен иметь доступ к этой кнопке " + DateTime.Now);
            }
            else
            {
                sw.WriteLine("Пользователь " + Access.log + " нажал на кнопку (SQL) и ошибок не было " + DateTime.Now);
            }
            sw.WriteLine("Показано строк: " + dataGridView1.RowCount);
            sw.Close();
            fs.Close();

        }

        private void выполнитьСПКToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовый документ (*.txt)|*.txt|Все файлы (*.*)| *.*";
            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    OleDbConnection riki = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=""D:sb.mdb""");
                    riki.Open();
                    DataSet ds = new DataSet();
                    OleDbDataAdapter adapter = new OleDbDataAdapter();

                    StreamReader sr = new StreamReader(openFileDialog.FileName);
                    string req = sr.ReadToEnd();
                    adapter.SelectCommand = new OleDbCommand(req, riki);
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    sr.Close();
                    ds.Dispose();
                    adapter.Dispose();
                    riki.Dispose();
                }
            }
            catch
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    OleDbConnection riki = new OleDbConnection(@"Provider=Microsoft.JET.OLEDB.4.0;Data Source=""D:sb.mdb""");
                    riki.Open();
                    DataSet ds = new DataSet();
                    OleDbDataAdapter adapter = new OleDbDataAdapter();

                    StreamReader sr = new StreamReader(openFileDialog.FileName);
                    string req = sr.ReadToEnd();
                    adapter.SelectCommand = new OleDbCommand(req, riki);
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    sr.Close();
                    ds.Dispose();
                    adapter.Dispose();
                    riki.Dispose();
                }
            }
            string path = Directory.GetCurrentDirectory();
            FileStream fs = new FileStream($@"{path}\log.txt", FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            if (Access.acc == "-1")
            {
                sw.WriteLine("Пользователь: " + Access.log + ", и с уровнем допуска " + Access.acc + " Не должен иметь доступ к этой кнопке " + DateTime.Now);
            }
            else
            {
                sw.WriteLine("Пользователь " + Access.log + " нажал на кнопку (Выполнить с ПК) и ошибок не было " + DateTime.Now);
            }
            sw.WriteLine("Показано строк: " + dataGridView1.RowCount);
            sw.Close();
            fs.Close();


        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void добавитьЗаписьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 fr3 = new Form3();
            fr3.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
