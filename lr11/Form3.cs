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
using System.Security.Cryptography;

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
           
                MailAddress from = new MailAddress("artem.dyatlov.2023@mail.ru", "Artem123");
                MailAddress to = new MailAddress(textBox1.Text);
                MailMessage m = new MailMessage(from, to);
                m.Subject = "Тест";
                using (UserContext db = new UserContext())
                {
                    foreach (User user in db.Users)
                    {
                        if (textBox1.Text == user.email)
                        {
                            string newPasword = GeneratePass();
                            m.Body = "<h1>Пароль: " + newPasword + "</h1>";
                            user.Pasword = GetHashString(newPasword);
                            MessageBox.Show("пароль отправлен на почту"+newPasword);
                        }
                    }
                db.SaveChanges();
                }
                m.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
                smtp.Credentials = new NetworkCredential("artem.dyatlov.2023@mail.ru", "WmkwQSPgvPg9KV4hBVZY");
                smtp.EnableSsl = true;
                smtp.Send(m);
            }
        private string GetHashString(string s)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(s);

            MD5CryptoServiceProvider CSP = new
            MD5CryptoServiceProvider();
            byte[] byteHash = CSP.ComputeHash(bytes);
            string hash = "";
            foreach (byte b in byteHash)
            {
                hash += string.Format("{0:x2}", b);
            }
            return hash;
        }
        private string GeneratePass()
        {
            string iPass = "";
            char[] arr = { '1', '2', '3', '4', '5', '6', '7', '8', '9', 'B', 'C', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'Q', 'R', 'S', 'T', 'V', 'W', 'X', 'Z', 'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'z', 'A', 'E', 'U', 'Y', 'a', 'e', 'i', 'o', 'u', 'y' };
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                iPass = iPass + arr[rnd.Next(0, 57)].ToString();
            }
            return iPass;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Form2 from= new Form2();
            this.Hide();
            from.Show();
        }
    }
}

