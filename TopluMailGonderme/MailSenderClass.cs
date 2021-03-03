using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace TopluMailGonderme
{
    public class MailSenderClass
    {
        public  static bool MailSendMethod(string alıcıEposta, string mesaJ,string mesajYollananKisi)
        {
            string subject = "Konu Başlığı";
            string content = mesaJ;
           
            bool control;


            var mailAlan = alıcıEposta; //alıcı 
            var mailYollayan = ".......@gmail.com";// gönderici Mail adresi
            var mailYollayanPass = "*********"; //gönderici password 


            var _defaultCredentials = false;
            var _enableSsl = true;

            var Host = "smtp.gmail.com"; // 
            var Port = 587;

            MailMessage mailMessage = new MailMessage();
            mailMessage.IsBodyHtml = true;//content değişkeninde yani mesaj içeriğinde html taglarının kullanımına izin verir.
           
            mailMessage.From = new MailAddress(mailYollayan);//gönderici mail adresi
            mailMessage.To.Add(mailAlan);//alıcı mail adresi


            mailMessage.Subject = subject;
            mailMessage.Body = content;
            using (var smtpClient = new SmtpClient(Host, Port))
            {

                smtpClient.EnableSsl = _enableSsl;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.UseDefaultCredentials = _defaultCredentials;

                if (_defaultCredentials == false)
                {
                    smtpClient.Credentials = new NetworkCredential(mailYollayan, mailYollayanPass);//göndericinin kimliği olulturuluyor...
                }

                try
                {
                    smtpClient.Send(mailMessage);//Mail gönderiliyor...
                    control = true;
                    Console.WriteLine("Email gönderildi :" + mesajYollananKisi+" ==================> "+"Mail Adresi :"+ alıcıEposta);
                }
                catch (Exception e)
                {
                    Directory.CreateDirectory(@"C:\Users\kakti\Documents\");//dizini değiştirmeyi unutma knki
                    var path = Path.Combine(@"C:\Users\kakti\Documents\", "Mail iletilmeyen eposta adresleri.txt");
                    FileStream fs = new FileStream(path, FileMode.Open);
                    StreamWriter file = new StreamWriter(fs);                
                    file.WriteLine(alıcıEposta + "\n");
                    file.Close();
                    control = false;
                }
            }
           
            return control;
        }



      
    }
}
