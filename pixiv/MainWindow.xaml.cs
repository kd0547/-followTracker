using Newtonsoft.Json.Linq;
using pixiv.Cookie;
using pixiv.PixivTracker;
using System;

namespace pixiv
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            CookieParser caParser = new CookieParser();
            SiteRequest siteRequest = new SiteRequest();
            
            string cookie = caParser.getCookieTxt("E:\\www.pixiv.net_cookies.txt");
            string responseJson = siteRequest.AjaxRequest("user/17018512/following?offset=0&limit=24&rest=show&tag=&acceptingRequests=0&lang=ko&version=32969157decc4eef43313f7a0a92eea8550aca46",cookie);
            
            JObject json = JObject.Parse(responseJson);
            JToken users = json["body"]["users"];

            foreach (JToken user in users) 
            {
                string userId = user["userId"].ToString();
                string userName = user["userName"].ToString();
                string profileImageUrl = user["profileImageUrl"].ToString();
                string userComment = user["userComment"].ToString();
                
                JToken illusts = user["illusts"];



            }




            Console.WriteLine();
        }
    }
}