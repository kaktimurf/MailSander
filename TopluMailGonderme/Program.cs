using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopluMailGonderme
{
    class Program
    {
        

        static void Main(string[] args)
        {
            //---------ÖNEMLİ NOTLAR--------//
            //MailSenderClass sınıfında content değişkeni yani mesajın içeriğini oluşturmayı unutma
            //MailSenderClass sınıfında  mailYollanyan değişkenine selcukbtt@mail.com yani hangi mail üzerinde yollanacaksa mailler o maili ekleyin ve mailYollanyanPass değişkenine de mail adresinin şifresini girin
            //Mail adresleri ile kişilerin isimlerini aynı sırayla dizilere ekleyin 
            //Dizileri isim ve epostalar ile doldurduktan sonra  çalıştırman yeterli olacaktır.


            ArrayClass ac = new ArrayClass();
            var isimler = ac.isimler;
            var mailAdresleri = ac.mailAdresleri;


            int count = 0;
            for (int i = 0; i < mailAdresleri.Length; i++)
            {
               
             var result=MailSenderClass.MailSendMethod(mailAdresleri[i], ReplaceClass.ReplaceName(isimler[i]),isimler[i]);
                if (result)
                {
                    count++;
                }
                
            }
            Console.WriteLine("Gönderilen toplam mail sayısı :" + count);
            Console.ReadLine();
        }
    }
}
