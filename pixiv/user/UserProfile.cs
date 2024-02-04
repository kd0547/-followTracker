using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace pixiv.a
{
    public class UserProfile : StackPanel
    {
        private long UserId;
        private TextBlock UserName;
        private string profileImageUrl;
        private TextBlock userComment;

        

        public bool following;
        public bool followed;
        public bool isBlocking;
        public bool isMypixiv;

        public UserProfile()
        {
            this.Orientation = Orientation.Horizontal;
            this.Margin = new Thickness(10);
        }
    }
}
