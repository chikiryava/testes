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
    public partial class TeacherAccount : Form
    {
        AddQuestions add = new AddQuestions();
        public TeacherAccount()
        {
            InitializeComponent();
            StreamReader sr = File.OpenText(@"C:\Users\chiki\source\repos\Pract19 ptpm\Pract19 ptpm\bin\Debug\Results.txt");
            while (!sr.EndOfStream)
            {
                listBox1.Items.Add($"{sr.ReadLine()} {sr.ReadLine()} {sr.ReadLine()} {sr.ReadLine()}");
            }
        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            add.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChangeQuestions cq = new ChangeQuestions();
            cq.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
