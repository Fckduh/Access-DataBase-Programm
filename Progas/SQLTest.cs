using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Auto
{
    public partial class SQLTest : Form
    {
        public SQLTest()
        {
            InitializeComponent();
        }
        
        private void SQLTest_Load(object sender, EventArgs e)
        {
            textBox1.Text = "";
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {




                    if (textBox1.Text != "")
                    {


                        OleDbConnection riki = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=""D:sb.mdb""");
                        riki.Open();
                        DataSet ds = new DataSet();
                        OleDbDataAdapter adapter = new OleDbDataAdapter();
                        adapter.SelectCommand = new OleDbCommand(textBox1.Text, riki);
                        adapter.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                        ds.Dispose();
                        adapter.Dispose();
                        riki.Dispose();
                    }
                    else
                    {
                        const string caption = "ошибка";
                        var resilt = MessageBox.Show("Заполните поле", caption,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        if (resilt == DialogResult.OK)
                        {
                            textBox1.Text = "";
                        }
                    }
                }


                catch
                {
                    if (textBox1.Text != "")
                    {


                        OleDbConnection riki = new OleDbConnection(@"Provider=Microsoft.JET.OLEDB.4.0;Data Source=""D:sb.mdb""");
                        riki.Open();
                        DataSet ds = new DataSet();
                        OleDbDataAdapter adapter = new OleDbDataAdapter();
                        adapter.SelectCommand = new OleDbCommand(textBox1.Text, riki);
                        adapter.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                        ds.Dispose();
                        adapter.Dispose();
                        riki.Dispose();
                    }
                    else
                    {
                        const string caption = "ошибка";
                        var resilt = MessageBox.Show("Заполните поле", caption,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        if (resilt == DialogResult.OK)
                        {
                            textBox1.Text = "";
                        }
                    }
                }
            }
            catch (OleDbException)
            {
                MessageBox.Show("Ошибка");
            }
            }
        
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "Запрос";
            saveFileDialog.Filter = "Текстовый документ (*.txt)|*.txt|Все файлы (*.*)| *.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFileDialog.FileName);
                string savetext = textBox1.Text;
                sw.WriteLine(savetext);
                sw.Close();
                MessageBox.Show("Сохранение прошло успешно", "Сообщение №2");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовый документ (*.txt)|*.txt|Все файлы (*.*)| *.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDialog.FileName);
                textBox1.Text = sr.ReadToEnd();
                sr.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
