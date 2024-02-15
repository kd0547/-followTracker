using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace pixiv.user
{

    public class FollowingPart : DockPanel
    {
        private Button followingButton;
        private Rectangle rectangle;
        public FollowingPart()
        {
            followingButton = CreateFollowingButton();
            rectangle = CreateRectangle();

            this.Children.Add(this.followingButton);
            this.Children.Add(this.rectangle);
        }

        private Button CreateFollowingButton()
        {
            Button button = new Button();

            button.Content = "팔로우 중";
            Margin = new Thickness(60, 0, 0, 0);
            button.Height = 35;
            button.Width = 85;
            button.Style = (Style)Application.Current.FindResource("FollowingButtonStyle");

            SetDock(button, Dock.Left); // DockPanel.Dock="Left" 설정

            return button;
        }

      
        private Rectangle CreateRectangle()
        {
            Rectangle rectangle = new Rectangle()
            {
                Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF949494")),
                Width = 25,
                Height = 25,
                Margin = new Thickness(-110, 0, 0, 0)
            };
            
            SetDock(rectangle, Dock.Left); // DockPanel.Dock="Left" 설정

            // ImageBrush를 사용하여 OpacityMask 설정
            ImageBrush opacityMask = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri(@"D:\free-icon-dots-3426508.png", UriKind.Absolute))
            };
            rectangle.OpacityMask = opacityMask;



            return rectangle;
        }


    }
}
