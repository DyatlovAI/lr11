using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace lr11
{
    public partial class Form1 : Form
    {

        UserContext db;
        public Form1()
        {
            InitializeComponent();
            db = new UserContext();
            db.Users.Load();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" | textBox2.Text == "" | textBox3.Text == "" | textBox4.Text == "" | textBox5.Text == "" | textBox6.Text == "" | textBox7.Text == "" | textBox8.Text == "" | textBoxpPass.Text == "" )
            {
                MessageBox.Show("введите все данные");
            }
            else
            {
                using (UserContext db = new UserContext())
                {
                    User user = new User(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, 
                        this.GetHashString(textBoxpPass.Text));
                    

                    db.Users.Add(user);
                    db.SaveChanges();
                   
                }
                MessageBox.Show("Аккаунт  " + textBox8.Text + " зарегистрирован");

               


            }

        }

        private string GetHashString(string s)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(s);
            MD5CryptoServiceProvider CSP = new MD5CryptoServiceProvider();
            byte[] byteHash = CSP.ComputeHash(bytes);
            string hash = "";
            foreach (byte b in byteHash)
            {
                hash += string.Format("{0:x2}", b);
            }
            return hash;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 from = new Form2();
            this.Hide();
            from.Show();

        }  
    }
}
