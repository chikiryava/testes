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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Registration reg = new Registration();
            reg.ShowDialog();
        }
        public string name, group, surname;
        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader sr = File.OpenText(@"C:\Users\chiki\source\repos\Pract19 ptpm\Pract19 ptpm\bin\Debug\StudentsAccounts.txt");
            int i = 0;
            string[,] str = new string[100000,6];
            while (!sr.EndOfStream)
            {
                for (int j = 0; j < 6; j++)
                {
                    str[i, j] = sr.ReadLine();
                }
                i++;
            }
            for(int r = 0; r<str.GetLength(0); r++) 
            {
                if (str[r,0] == textBox1.Text && str[r, 1] == textBox2.Text)
                {
                    if (str[r, 5] == "1")
                    {
                        name = str[r, 2];
                        surname = str[r, 3];
                        group = str[r, 4];
                        this.Close();
                    }
                    else
                    {
                        TeacherAccount tc = new TeacherAccount();
                        tc.ShowDialog();
                    }
                    break;
                }
                if (str[r, 0] == null)
                {
                    MessageBox.Show("Неверный логин или пароль");
                    break;
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
