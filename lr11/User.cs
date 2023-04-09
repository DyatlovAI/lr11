using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lr11
{
    internal class User
    {
        //10
        public int Id { get; set; }
        public string Pasword { get; set; }
        public string Login1 { get; set; }
        public string Name1 { get; set; }
        public string FirstName { get; set; }
        public string Date_of_birthday { get; set; }
        public string email { get; set; }
        public string number_phone { get; set; }
        public string adres { get; set; }
        public string date_of_first_buy { get; set; }
        
        public User()
        { }
        public User(string Name1, string FirstName, string Date_of_birthday, string Email, string number_phone, string adres, string date_of_first_buy, string Login1, string Pasword)
        {
            this.Login1 = Login1;
            this.Pasword = Pasword;
            this.email = Email;
            this.number_phone = number_phone;
            this.adres = adres;
            this.date_of_first_buy = date_of_first_buy;
            this.FirstName = FirstName;
            this.Name1 = Name1;
            this.Date_of_birthday = Date_of_birthday;
            
        }
        public string getName()
        {
            return this.Name1;
        }
    }

}
