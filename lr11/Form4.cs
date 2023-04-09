using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;

namespace lr11
{
    public partial class Form4 : Form
    {
        UserContext db;

        public Form4()
        {
            InitializeComponent();
            
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Form2 from = new Form2();
            this.Hide();
            from.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
        }

    }

        
    }
    

