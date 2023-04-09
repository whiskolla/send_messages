using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net; 
using System.Net.Mail;

namespace FLP_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static void SendMessage(string userName, string adressTo, string messageSubject, string messageText)
        {

            //nik.nikipetrov@gmail.com
            //HJeWBPvJevfEeQge2LCU
            string from = @"flp_test@mail.ru"; // адреса отправител€
                string pass = "HJeWBPvJevfEeQge2LCU"; // пароль отправител€

            SmtpClient client = new SmtpClient("smtp.mail.ru", 587);
            client.Credentials = new System.Net.NetworkCredential(from, pass);
            client.EnableSsl = true;
            string msgFrom = from;

            string msgTo = adressTo;

            string msgSubject = messageSubject;

            string msgBody = messageText;

            MailMessage msg = new MailMessage(msgFrom, msgTo, msgSubject, msgBody);

            try
            {
                //client.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis;
                client.Send(msg);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            string userName = textBox1.Text; //им€ пользовател€
            string adressTo = textBox2.Text; //адрес пользовател€
            string messageSubject = textBox3.Text; //тема
            string messageText = richTextBox1.Text; //текст
            SendMessage(userName, adressTo, messageSubject, messageText);


        }
    }
}