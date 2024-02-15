using Newtonsoft.Json.Linq;
using pixiv.a;
using pixiv.Cookie;
using pixiv.PixivTracker;
using pixiv.user;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
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

            this.Test();
            
        
        }

        public void Test()
        {
            UserProfilePart userProfile = new UserProfilePart();
            FollowingPart userSubPanel = new FollowingPart();

            UserProfileSection userProfileSection = new UserProfileSection(userProfile,userSubPanel);
            UserillustsSection userillustsSection = new UserillustsSection();


            Unit userPanel = new Unit(userProfileSection, userillustsSection);
            this.MainContent.Children.Add(userPanel);

            Border border = new Border();
            border.Margin = new Thickness(20,10,20,10);

            Rectangle rectangle = new Rectangle()
            {
                Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFCACACA")),
                Height = 1,
                Margin = new Thickness(20, 10, 20, 10),
                HorizontalAlignment = HorizontalAlignment.Stretch
            };
            border.Child = rectangle;


            this.MainContent.Children.Add(border);
        }
    }
}