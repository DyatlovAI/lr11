using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace lr11
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Form1 from = new Form1();
            this.Hide();
            from.Show();
        }


        private void label5_Click(object sender, EventArgs e)
        {
            Form3 from = new Form3();
            this.Hide();
            from.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (UserContext db = new UserContext())
            {
                //try {
                    foreach (User user in db.Users)
                    {


                        if (textBox1.Text == user.Login1 && this.GetHashString(textBox2.Text) == user.Pasword)
                        {
                            MessageBox.Show("Вход успешен!");
                            Form4 from = new Form4();
                            from.label1.Text = ("Логин: ") + user.Login1;
                            from.label3.Text = ("Почта: ") + user.email;
                            from.label4.Text = ("телефон: ") + user.number_phone;
                            from.label5.Text = ("Имя: ") + user.Name1;
                            from.label6.Text = ("Фамилия: ") + user.FirstName;
                            from.label7.Text = ("Дата первой покупки: ") + user.date_of_first_buy;
                            from.label8.Text = ("День рождение: ") + user.Date_of_birthday;
                            from.label9.Text = ("Адрес: ") + user.adres;
                        MessageBox.Show("вы вошли под учетной записью " + user.Login1);
                        this.Hide();
                        from.Show();   
                        this.Visible = false;
                        return;
                        
                        }

                }
                MessageBox.Show("Неверный пароль");


            }
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



    }
}



