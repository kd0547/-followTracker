using pixiv.a;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace pixiv.user
{
    public class UserProfileSection : StackPanel
    {
        private UserProfilePart userProfile;
        private FollowingPart followingPart;

        public UserProfileSection() 
        {
            init();
        }

        public UserProfileSection(UserProfilePart userProfile,FollowingPart userSubPanel)
        {
            init();

            this.userProfile = userProfile;
            this.followingPart = userSubPanel;

            Children.Add(this.userProfile);
            Children.Add(this.followingPart);
        }



        public void init()
        {
            this.Width = 300;

        }
    }
}
