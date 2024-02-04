using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pixiv.Cookie
{
    public class CookieParser
    {
        
        public string getCookieTxt(string cookieTxtPath)
        {
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                string[] cookieTxt = File.ReadAllLines(cookieTxtPath);
                if (cookieTxt.Length < 0)
                {
                    return "";
                }
                
                int cookieLen = cookieTxt.Length;
                for (int i = 0; i < cookieLen; i++)
                {
                    if (cookieTxt[i].Contains("#"))
                    {
                        continue;    
                    }
                    string txt= cookieTxt[i].Replace("\n", "");
                    if (txt.Equals(""))
                    {
                        continue;
                    }

                    string[] end = txt.Split('\t');
                    stringBuilder.Append(end[5] + "=" + end[6]);
                    stringBuilder.Append(";");
                }

                stringBuilder.Remove(stringBuilder.Length - 1, 1);

                return stringBuilder.ToString();
            }
            catch (Exception ex)
            {
                
            }


            return "";
        }
    }

    
    



}
