using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopluMailGonderme
{
   public class ReplaceClass
    {


        public static string ReplaceName(string name)
        {
            FileStream fs = new FileStream("C:\\Users\\kakti\\Desktop\\Burak.txt", FileMode.Open);//Burada yollanacak mail şablonunun yolunu verip çalıştırmanız yeterli olacaktır.
            StreamReader sr = new StreamReader(fs);          
            string result = sr.ReadToEnd();
            fs.Close();
            return result.Replace("FFFFFFFF", name);

        }
       

    }
}
