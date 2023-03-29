using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pract19_ptpm
{
   
    public partial class ChangeQuestions : Form
    {
        string[,] questions = new string[Questions(7, "questions.txt"), 7];
        public ChangeQuestions()
        {
            StreamReader sr = File.OpenText("questions.txt");
            InitializeComponent();
            int i = 0, j;
            while (!sr.EndOfStream)
            {
                for (j = 0; j < 7; j++)
                {
                    questions[i, j] = sr.ReadLine();
                }
                i++;
            }
            sr.Close();
            textBox2.Text = questions[0, 0];
            textBox1.Text = questions[0, 1];
            textBox3.Text = questions[0, 2];
            textBox4.Text = questions[0, 3];
            textBox5.Text = questions[0, 4];
            textBox6.Text = questions[0, 6];
            if (questions[0, 5] == "1")
                radioButton1.Checked = true;
            else
                radioButton2.Checked = true;
            button1.Enabled = false;

        }
        static int Questions(int k, string file)
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
        int i = 0;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void ChangeQuestions_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            i++;
            if (i == questions.GetLength(0) - 1)
                button2.Enabled = false;
            button1.Enabled = true;
            textBox2.Text = questions[i, 0];
            textBox1.Text = questions[i, 1];
            textBox3.Text = questions[i, 2];
            textBox4.Text = questions[i, 3];
            textBox5.Text = questions[i, 4];
            textBox6.Text = questions[i, 6];
            if (questions[i, 5] == "1")
                radioButton1.Checked = true;
            else
                radioButton2.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            i--;
            if (i == 0)
                button1.Enabled = false;
            button2.Enabled = true;
            textBox2.Text = questions[i, 0];
            textBox1.Text = questions[i, 1];
            textBox3.Text = questions[i, 2];
            textBox4.Text = questions[i, 3];
            textBox5.Text = questions[i, 4];
            textBox6.Text = questions[i, 6];
            if (questions[i, 5] == "1")
                radioButton1.Checked = true;
            else
                radioButton2.Checked = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            questions[i, 0] = textBox2.Text;
            questions[i,1] = textBox1.Text;
            questions[i,2] = textBox3.Text;
            questions[i,3] = textBox4.Text;
            questions[i,4] = textBox5.Text;
            StreamWriter sr = File.CreateText("questions.txt");
            for(int i = 0; i < questions.GetLength(0); i++)
            {
                for(int j = 0; j<questions.GetLength(1); j++)
                {
                    if (questions[i, 0] == "")
                    {
                        if (i == questions.GetLength(0) - 1)
                            break;
                        else
                        {
                            i++;
                            j = -1;
                        }
                    }
                    else
                    {
                        sr.WriteLine(questions[i, j].ToString());
                    }
                        
                    
                }
            }
            sr.Close();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = "";
        }
    }
}
