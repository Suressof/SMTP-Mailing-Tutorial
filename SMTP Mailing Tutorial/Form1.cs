using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;

namespace SMTP_Mailing_Tutorial
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.To.Add(txtTo.Text);
            mailMessage.From = new MailAddress(txtFrom.Text);
            mailMessage.Body = txtMail.Text;
            mailMessage.Subject = txtSubject.Text;

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.EnableSsl = true;
            smtpClient.Port = 587;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Credentials = new NetworkCredential(txtFrom.Text, txtAppPass.Text);

            try
            {
                smtpClient.SendMailAsync(mailMessage);
                txtStatus.Text += $"Mail Message sent to {txtTo.Text}.{Environment.NewLine}";
            }
            catch (Exception ex)
            {
                txtStatus.Text += $"{ex.Message}{Environment.NewLine}";
            }
        }
    }
}
