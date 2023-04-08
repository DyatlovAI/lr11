using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lr11
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MailAddress from = new MailAddress("zaid-mingaliev@mail.ru", "Zaid");
                MailAddress to = new MailAddress(textBox1.Text);
                MailMessage m = new MailMessage(from, to);
                m.Subject = "Тест";
                using (UserContext db = new UserContext())
                {
                    foreach (User user in db.Users)
                    {
                        if (textBox1.Text == user.email)
                        {
                            m.Body = "<h1>Пароль: " + user.Pasword + "</h1>";
                        }
                    }
                    
                }
                m.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
                smtp.Credentials = new NetworkCredential("zaid-mingaliev@mail.ru", "123");
                smtp.EnableSsl = true;
                smtp.Send(m);


            }
            catch
            {
                MessageBox.Show("Ошибка");
            };
        }
        private void Recover_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            
            Form2 from= new Form2();
            this.Hide();
            from.Show();
        }
    }
}

