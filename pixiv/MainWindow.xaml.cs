using Newtonsoft.Json.Linq;
using pixiv.a;
using pixiv.Cookie;
using pixiv.PixivTracker;
using pixiv.user;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
            this.Loaded += WindowLoad;

        }


        public void WindowLoad(object sender, EventArgs e)
        {
            CookieParser caParser = new CookieParser();
            SiteRequest siteRequest = new SiteRequest();

            string cookie = caParser.getCookieTxt("E:\\www.pixiv.net_cookies.txt");
            string responseJson = siteRequest.AjaxRequest("user/17018512/following?offset=0&limit=24&rest=show&tag=&acceptingRequests=0&lang=ko&version=32969157decc4eef43313f7a0a92eea8550aca46", cookie);

            JObject json = JObject.Parse(responseJson);
            JToken users = json["body"]["users"];

            foreach (JToken user in users)
            {
                string userId = user["userId"].ToString();
                string userName = user["userName"].ToString();
                string profileImageUrl = user["profileImageUrl"].ToString();
                string userComment = user["userComment"].ToString();
                bool isFollow = (bool)user["following"];

                JToken illusts = user["illusts"];

                ImageSource bitmapImage = siteRequest.RequestImage(profileImageUrl);


                UserProfilePart userProfilePart = new UserProfilePart(bitmapImage, userName, userComment);
                FollowingPart followingPart = new FollowingPart(isFollow);

                UserProfileSection userProfileSection = new UserProfileSection(userProfilePart, followingPart);
                UserillustsSection userillustsSection = new UserillustsSection();
                Unit unit = new Unit(userProfileSection, userillustsSection);

                MainContent.Children.Add(unit);

            }
        }


    }
}