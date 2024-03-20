using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace pixiv.PixivTracker
{
    internal class SiteRequest
    {

        private const string pixiv = "https://www.pixiv.net";

        private const string ajax = "/ajax/";
        
        public ImageSource RequestImage(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = WebRequestMethods.Http.Get;
                request.Referer = "https://www.pixiv.net/";
                request.Accept = "image/avif,image/webp,image/apng,image/svg+xml,image/*,*/*;q=0.8";
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/121.0.0.0 Safari/537.36";

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            stream.CopyTo(memoryStream);
                            byte[] imageData = memoryStream.ToArray();

                            // 바이트 배열에서 BitmapImage 생성
                            BitmapImage bitmapImage = new BitmapImage();
                            bitmapImage.BeginInit();
                            bitmapImage.StreamSource = new MemoryStream(imageData);
                            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                            bitmapImage.EndInit();

                            return bitmapImage;
                        }
                    }

                }

            }
            catch (WebException web)
            {
                Console.WriteLine(web.Message);
            }

            return null;
        }

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
