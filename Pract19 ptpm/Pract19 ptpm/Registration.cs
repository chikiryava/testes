using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pract19_ptpm
{
    public partial class Registration : Form
    {
        public string user,name,surname,group;
        public Registration()
        {
            InitializeComponent();
            radioButton1.Checked = true;
        }
        AddQuestions add = new AddQuestions();
        private void button2_Click(object sender, EventArgs e)
        {
            add.ShowDialog();
        }

        private void Registration_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (Check(textBox1.Text) && Check(textBox2.Text) && textBox3.Text.Length != 0 && CheckData(textBox4.Text) && CheckData(textBox5.Text))
            {
                StreamWriter sw = File.AppendText(@"C:\Users\chiki\source\repos\Pract19 ptpm\Pract19 ptpm\bin\Debug\StudentsAccounts.txt");
                name = char.ToUpper(textBox1.Text[0]).ToString() + textBox1.Text.Substring(1);
                surname = char.ToUpper(textBox2.Text[0]).ToString() + textBox2.Text.Substring(1);
                group = textBox3.Text;
                sw.WriteLine(textBox4.Text);
                sw.WriteLine(textBox5.Text);
                sw.WriteLine(name);
                sw.WriteLine(surname);
                sw.WriteLine(group);
                if (radioButton1.Checked)
                    sw.WriteLine("1");
                else
                    sw.WriteLine("2");
                sw.Close();
                this.Close();
            }
        }

        bool Check(string test)
        {
            Regex rg = new Regex("[^а-яА-Я]");
            if(test.Length == 0)
            {
                MessageBox.Show("Пустое поле");
                return false;
            }
            else if (rg.IsMatch(test))
            {
                MessageBox.Show("Используйте только русские буквы");
                return false;
            }
            else
            {
                bool check = false;
                for(int i = 0; i < test.Length; i++)
                {
                    if (!char.IsLetter(test[i]))
                        check = true;
                }
                if (check == true)
                {
                    MessageBox.Show("В поле имя и фамилия могут быть только буквы");
                    return false;
                }
                else
                    return true;
            }
        }
        bool CheckData(string str)
        {
            if (str.Length < 4)
            {
                MessageBox.Show("Длина логина и пароля должна быть больше, чем 4 символа");
                return false;
            }
            else
            {
                bool test = false;
                foreach(char i in str)
                {
                    if (!char.IsLetterOrDigit(i))
                        test = true;
                }
                if (test == true)
                {
                    MessageBox.Show("Логин и пароль могут содержать в себе только буквы и цифры");
                    return false;
                }
                else
                    return true;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (Check(textBox1.Text) && Check(textBox2.Text) && textBox3.Text.Length != 0&&CheckData(textBox4.Text)&&CheckData(textBox5.Text))
            {
                StreamWriter sw = File.AppendText(@"C:\Users\chiki\source\repos\Pract19 ptpm\Pract19 ptpm\bin\Debug\StudentsAccounts.txt");
                name = char.ToUpper(textBox1.Text[0]).ToString()+textBox1.Text.Substring(1);
                surname = char.ToUpper(textBox2.Text[0]).ToString() + textBox2.Text.Substring(1);
                group = textBox3.Text;
                sw.WriteLine(name);
                sw.WriteLine(surname); sw.WriteLine(group);
                sw.Close();
                this.Close();
            }

        }
    }
}
