using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace pixiv.PixivTracker
{
    internal class SiteRequest
    {

        private const string pixiv = "https://www.pixiv.net";

        private const string ajax = "/ajax/";
        
        

        public string AjaxRequest(string userPath,string cookie)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(pixiv + ajax + userPath);
                request.Method = WebRequestMethods.Http.Get;
                request.ContentType = "application/json";
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/121.0.0.0 Safari/537.36";
                request.Headers.Add("Cookie", cookie);

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    Stream stream = response.GetResponseStream();

                    using (StreamReader reader = new StreamReader(stream))
                    {
                        return reader.ReadToEnd();
                    }

                }
            } catch (WebException web)
            {
                Console.WriteLine(web.Message);
            }

            return "";
        }
    }
}
