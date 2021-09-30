using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserMaintenance.Entities;
using System.IO;

namespace UserMaintenance
{
    public partial class Form1 : Form
    {
        BindingList<User> users = new BindingList<User>();
        public Form1()
        {
            InitializeComponent();

            label1.Text = Resource1.FullName;
            button1.Text = Resource1.Add;
            button2.Text = Resource1.WriteInFile;
            button3.Text = Resource1.Delete;

            listBox1.DataSource = users;
            listBox1.DisplayMember = "FullName";
            listBox1.ValueMember = "ID";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var a = new User();
            a.FullName = textBox1.Text;
            users.Add(a);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();            
            var res = save.ShowDialog();
            if (res == DialogResult.OK)
            {
                StreamWriter a = new StreamWriter(save.OpenFile());
                foreach (var item in users)
                {
                    a.WriteLine($"id: {item.ID}, full name:{item.FullName}");
                }
                a.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            User a = (User)listBox1.SelectedItem;
            if (a != null)
            {
                users.Remove(a);
            }
        }
    }
}
