using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pract19_ptpm
{
    public partial class AddQuestions : Form
    {
        public AddQuestions()
        {
            InitializeComponent();
            openFileDialog1.Filter = "Image Files(*.BMP; *.JPG; *.PNG)| *.BMP; *.JPG; *.png | All files(*.*) | *.*";
            saveFileDialog1.Filter = "Image Files(*.BMP; *.JPG; *.PNG)| *.BMP; *.JPG; *.png | All files(*.*) | *.*";
        }
        int i = 1;
        string[] str = new string[7];

        private void AddQuestions_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (button1.Text == "Введите вопрос")
            {
                if (textBox1.Text.Length > 2)
                {
                    str[0] = textBox1.Text;
                    button1.Text = $"Введите вариант ответа";
                    radioButton2.Checked = true;
                    radioButton1.Visible = radioButton2.Visible = true;
                    textBox1.Clear();
                }
                else
                    MessageBox.Show("Вопрос не может быть короче 2х символов");
            }
            else if (button1.Text == "Введите вариант ответа")
            {
                str[i] = textBox1.Text;
                i++;
                textBox1.Clear();
                if (i > 3)
                {
                    button1.Text = "Введите правильный(е) ответ(ы)";
                    if (radioButton1.Checked == true)
                        textBox2.Visible = true;
                    radioButton1.Visible = radioButton2.Visible = false;
                }
            }
            else if (button1.Text == "Введите правильный(е) ответ(ы)")
            {
                bool test = false;
                bool test1 = false;
                foreach (string i in str)
                {
                    if (textBox1.Text == i)
                        test = true;
                    if(radioButton1.Checked == true && textBox2.Text ==i)
                        test1= true;
                }
                if (test == false || radioButton1.Checked && test1 == false)
                {
                    MessageBox.Show("У вас нет такого варианта ответа");
                }
                else
                {
                    textBox2.Visible = false;
                    str[4] = textBox2.Text+ textBox1.Text;
                    if (radioButton1.Checked)
                        str[5] = "2";
                    else if (radioButton2.Checked)
                        str[5] = "1";
                    button1.Text = "Путь к картинке";
                    textBox1.Clear();
                    textBox2.Clear();
                    button3.Visible = true;

                }
            }
            else if(button1.Text=="Путь к картинке")
            {
                if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                string filename = openFileDialog1.FileName;
                if (!File.Exists(filename))
                    MessageBox.Show("Такого файла нет");
                else
                {
                    str[6] = Path.GetFileName(filename);
                    StreamWriter sw = File.AppendText("questions.txt");
                    for(int i = 0; i< str.Length; i++)
                    {
                        sw.WriteLine(str[i].ToString());
                    }
                    button1.Text = "Добавить еще вопрос";
                    button3.Visible = false;
                    sw.Close();
                }
                
                
            }
            else if (button1.Text == "Добавить еще вопрос")
            {
                button1.Text = "Введите вопрос";
                radioButton1.Visible = radioButton2.Visible = false;
                textBox2.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            str[6] = "null";
            StreamWriter sw = File.AppendText("questions.txt");
            for (int i = 0; i < str.Length; i++)
            {
                sw.WriteLine(str[i].ToString());
            }
            button1.Text = "Добавить еще вопрос";
            button3.Visible = false;
            sw.Close();
        }
    }
}
