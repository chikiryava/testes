using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.ComponentModel.Com2Interop;

namespace Pract19_ptpm
{

    public partial class Form1 : Form
    {
        Random rnd = new Random();
        public string[,] questions = new string[Questions(7, "questions.txt"), 7];
        int[] myarray = new int[Questions(7, "questions.txt")];
        string[,] users = new string[Questions(4,"Results.txt")+1,4];
        int questionnumber = 0, answer = 0;
        static int Questions(int k,string file)
        {
            StreamReader sr = File.OpenText(file);
            int i = 0;
            while (!sr.EndOfStream)
            {
                string meow = sr.ReadLine();
                if (meow == null)
                {
                    break;
                }
                else
                    i++;
            }
            sr.Close();
            return i / k;
        }
        Registration frm = new Registration();
        Login log = new Login();
        public Form1()
        {
            InitializeComponent();
            log.ShowDialog();
            groupBox1.Text = "";
            groupBox2.Text = "";
            StreamReader sr = File.OpenText("questions.txt");
            int i = 0, j;
            while(!sr.EndOfStream)
            {
                for(j=0;j<7;j++)
                {
                    questions[i,j] = sr.ReadLine();
                }
                i++;
            }
            int k = 0;
            sr.Close();

            while (k<myarray.Length-1)
            {
                bool stop = false;
                int test = rnd.Next(0,myarray.Length);
                for(int t = 0; t < myarray.Length; t++)
                {
                    if (myarray[t] == test)  
                        stop = true;
                }
                if (stop == false)
                {
                    myarray[k] = test;
                    k++;
                }
            }
            this.Text = "Вопрос " + (questionnumber + 1);
            if (questions[myarray[questionnumber], 5] == "1")
            {
                label1.Text = questions[myarray[questionnumber], 0];
                radioButton1.Text = questions[myarray[questionnumber], 1];
                radioButton2.Text = questions[myarray[questionnumber], 2];
                radioButton3.Text = questions[myarray[questionnumber], 3];
                foreach (RadioButton rb in groupBox1.Controls.OfType<RadioButton>())
                {
                    if (rb.Text == "")
                        rb.Visible = false;
                    else
                        rb.Visible = true;
                }
                if (questions[myarray[questionnumber], 6] != "null")
                {
                    pictureBox1.Visible = true;
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox1.Image = Image.FromFile($"{questions[myarray[questionnumber], 6]}");
                }
                else
                    pictureBox1.Visible = false;
            }
            else
            {
                groupBox2.Visible = true;
                label2.Text = questions[myarray[questionnumber], 0];
                checkBox1.Text = questions[myarray[questionnumber], 1];
                checkBox2.Text = questions[myarray[questionnumber], 2];
                checkBox3.Text = questions[myarray[questionnumber], 3];
                foreach (CheckBox cb in groupBox2.Controls.OfType<CheckBox>())
                {
                    if (cb.Text == "")
                        cb.Visible = false;
                    else
                        cb.Visible = true;
                }
                if (questions[myarray[questionnumber], 6] != "null")
                {
                    pictureBox1.Visible = true;
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox1.Image = Image.FromFile($"{questions[myarray[questionnumber], 6]}");
                }
                else
                    pictureBox1.Visible = false;
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            groupBox2.Visible = false;
            string useranswer = string.Empty;
            if (questions[myarray[questionnumber], 5] == "2")
            {
                foreach (CheckBox cb in groupBox2.Controls.OfType<CheckBox>())
                {
                    if (cb.Checked)
                    {
                        useranswer += cb.Text;
                    }
                }
            }
            else
            {

                foreach (RadioButton rb in groupBox1.Controls.OfType<RadioButton>())
                {
                    if (rb.Checked)
                    {
                        useranswer += rb.Text;
                    }
                }
            }
            if (useranswer == questions[myarray[questionnumber], 4])
                answer++;
            
            
            if (questionnumber < questions.GetLength(0)-1&& questions[myarray[questionnumber+1], 5]=="1")
            {
                checkBox1.Checked = true;
                questionnumber++;                
                label1.Text = questions[myarray[questionnumber], 0];
                radioButton1.Text = questions[myarray[questionnumber], 1];
                radioButton2.Text = questions[myarray[questionnumber], 2];
                radioButton3.Text = questions[myarray[questionnumber], 3];
                if (questions[myarray[questionnumber], 6] != "null")
                {
                    pictureBox1.Visible = true;
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox1.Image = Image.FromFile($"{questions[myarray[questionnumber], 6]}");
                }
                else
                    pictureBox1.Visible = false;
                this.Text = "Вопрос " + (questionnumber + 1);
                foreach (RadioButton rb in groupBox1.Controls.OfType<RadioButton>())
                {
                    if (rb.Text == "")
                        rb.Visible = false;
                    else
                        rb.Visible = true;
                }

            }
            else if (questionnumber < questions.GetLength(0) - 1 && questions[myarray[questionnumber+1], 5] == "2")
            {
                groupBox2.Visible = true;
                questionnumber++;
                label2.Text = questions[myarray[questionnumber], 0];
                checkBox1.Text = questions[myarray[questionnumber], 1];
                checkBox2.Text = questions[myarray[questionnumber], 2];
                checkBox3.Text = questions[myarray[questionnumber], 3];
                if (questions[myarray[questionnumber], 6] != "null")
                {
                    pictureBox1.Visible = true;
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox1.Image = Image.FromFile($"{questions[myarray[questionnumber], 6]}");
                }
                else
                    pictureBox1.Visible = false;
                this.Text = "Вопрос " + (questionnumber + 1);
                foreach(CheckBox cb in groupBox2.Controls.OfType<CheckBox>())
                {
                    if(cb.Text =="")
                        cb.Visible = false;
                    else
                        cb.Visible = true;
                }
            }
            else
            {
                pictureBox1.Visible = true;
                groupBox1.Visible= false;
                button1.Enabled = false;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                if(File.Exists($"{answer}.png"))
                    pictureBox1.Image = Image.FromFile($"{answer}.png");
                MessageBox.Show($"Вы ответили на {answer} из {questionnumber + 1 } вопросов правильно");
                frm.user += $" правильных ответов: {answer}";
                StreamWriter sw = File.AppendText("Results.txt");
                sw.WriteLine(log.name);
                sw.WriteLine(log.surname);
                sw.WriteLine(log.group);
                sw.WriteLine(answer);
                sw.Close();
            }                        
        }
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
