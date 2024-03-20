using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace pixiv.user
{
    public  class Unit : DockPanel
    {

        private UserProfileSection userProfileSection;
        private UserillustsSection userillustsSection;

        public Unit() 
        {
            init();
        }

        public Unit (UserProfileSection userProfileSection, UserillustsSection userillustsSection)
        {
            init();
            this.userProfileSection = userProfileSection;
            this.userillustsSection = userillustsSection;

            SetDock(userProfileSection, Dock.Left);

            this.Children.Add(this.userProfileSection);
            //this.Children.Add(this.userillustsSection);
        }

        private void init()
        {
            this.LastChildFill = true;
            this.Height = 210;
            this.VerticalAlignment = VerticalAlignment.Top;


        }

    }
}
