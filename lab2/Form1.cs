using System;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
        }
        String str;
        int i=0;
        private void button1_Click(object sender, EventArgs e)
        {
            ArrayList lastname = new ArrayList();
            ArrayList firstname = new ArrayList();
            ArrayList oldname = new ArrayList();
            ArrayList group = new ArrayList();
            ArrayList index = new ArrayList();
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;
            string[] lines = File.ReadAllLines(filename);

            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].Name = "Фамилия";
            dataGridView1.Columns[1].Name = "Имя";
            dataGridView1.Columns[2].Name = "Отчествво";
            dataGridView1.Columns[3].Name = "Группа";
            dataGridView1.Columns[4].Name = "средний балл";
            dataGridView1.RowHeadersVisible = false;

            foreach (string s in lines)
            {
                Match match = Regex.Match(s, "ФИО:(.*?)ЛН:(.*?),средний бал:(.*?),");
                Match fio = Regex.Match(match.Groups[1].ToString(), "(.*?) (.*?) (.*?),");
                if (fio.Groups[1].Value.ToString()!=" ")
                {
                    lastname.Add(fio.Groups[1].Value);
                }
                else
                {
                    lastname.Add("");
                }
                firstname.Add(fio.Groups[2].Value);
                oldname.Add(fio.Groups[3].Value);
                group.Add(match.Groups[2].Value);
                index.Add(match.Groups[3].Value);
                
            }
            for (int i = 0; i < lines.Length; i++)
            {
                Console.WriteLine("    "+oldname[i]);
                dataGridView1.Rows.Add(lastname[i], firstname[i], oldname[i], group[i], index[i]);
            }

        }

      
    }
    
}
