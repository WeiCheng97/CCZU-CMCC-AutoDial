using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices;
using System.Net.NetworkInformation;
using System.IO;
using System.Diagnostics;

namespace ConsoleApp1
{
    public class main
    {
        public static string MakeEncodeUserName()
        {
            string s = Guid.NewGuid().ToString().Replace("-", "");
            byte[] bytes = Encoding.Default.GetBytes(s);
            string text = "你的账号"+"@internet";
            byte[] buffer2 = Encoding.Default.GetBytes(text);
            int num = ((((bytes[0] + bytes[1]) + bytes[2]) + bytes[3]) + bytes[4]) + bytes[5];
            if (text.Length >= 3)
            {
                num = ((((bytes[0] + bytes[1]) + bytes[2]) + buffer2[0]) + buffer2[1]) + buffer2[2];
            }
            int num2 = ((177 * num) + 5166) % 10000;
            return (s + num2.ToString("0000") + "01" + text);
        }


        static void Main(string[] args)
        {
            Random ran = new Random();
            int RandKey = ran.Next(100, 999);
            string a = main.MakeEncodeUserName();
            string bat = "rasdial 宽带连接 " +a+ " 你的密码";
            File.WriteAllText("test.bat", bat, Encoding.GetEncoding(936));
            Process.Start("test.bat");
        }
    }
}
