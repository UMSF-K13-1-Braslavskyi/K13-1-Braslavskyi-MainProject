using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp123
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void вийтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str_enter_text = textBox1.Text;
            try
            {
                short key = Convert.ToInt16(textBox3.Text);
                short step = Convert.ToInt16(textBox4.Text);
                string str_exit_text = "";
                if (radioButton1.Checked) str_exit_text = Encrypt(str_enter_text, key, step);
                else if (radioButton2.Checked) str_exit_text = Decrypt(str_enter_text, key, step);
                else MessageBox.Show("Оберіть вид шифрування");
                textBox2.Text = "";
                textBox2.Text = str_exit_text;
            }
            catch (Exception exc)
            {

                MessageBox.Show("Щось не так: " + exc.Message);
            }
           
        }
        public static string Encrypt(string str, Int16 key, Int16 step)//Шифрування
        {
            byte[] array = Encoding.Unicode.GetBytes(str);
            byte[] mass = new byte[array.Length];
            for(short j = 0; j < step; j++)
            {
                for (int i = 0; i < mass.Length; i++)
                {
                    mass[i] = (byte)(array[i] ^ key);
                }
                key++;
                mass.CopyTo(array, 0);
            }
            return Encoding.Unicode.GetString(mass);
        }
        public static string Decrypt(string str, Int16 key, Int16 step)//Дешифрування
        {
            key = (short)(key + step);
            byte[] array = Encoding.Unicode.GetBytes(str);
            byte[] mass = new byte[array.Length];
            for (short j = 0; j < step; j++)
            {
                for (int i = 0; i < mass.Length; i++)
                {
                    mass[i] = (byte)(array[i] ^ key);
                }
                key--;
                mass.CopyTo(array, 0);
            }
            return Encoding.Unicode.GetString(mass);
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.SelectAll();
        }

        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            textBox3.SelectAll();
        }

        private void відкритиToolStripMenuItem_Click(object sender, EventArgs e)//вікно відкриття
        {
            Stream myStreamOpen = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStreamOpen = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStreamOpen)
                        {
                            // Insert code to read the stream here.
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void зберегтиToolStripMenuItem_Click(object sender, EventArgs e)//вікно зберегання
        {
            Stream myStreamSave;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStreamSave = saveFileDialog1.OpenFile()) != null)
                {
                    // Code to write the stream goes here.
                    myStreamSave.Close();
                }
            }
        }

        private void textBox4_MouseClick(object sender, MouseEventArgs e)
        {
            textBox4.SelectAll();
        }
    }
}
