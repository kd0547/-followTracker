using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace pixiv.a
{
    public class UserProfilePart : StackPanel
    {
        private long UserId;
        private TextBlock UserName;
        private string profileImageUrl;
        private TextBlock userComment;

        private Grid grid;
        

        public bool following;
        public bool followed;
        public bool isBlocking;
        public bool isMypixiv;

        public UserProfilePart()
        {
            init();
        }
        public UserProfilePart(ImageSource image,string userName, string comment)
        {
            init();
            userImage(image);
            createUserProfile(userName, comment);
        }

        private void init()
        {
            this.Orientation = Orientation.Horizontal;
            this.Margin = new Thickness(10);
        }


        public void userImage(ImageSource imageSource)
        {
            Grid grid = new Grid();
            grid.Children.Add(createRectangle(imageSource));
            this.grid = grid;

            this.Children.Add(grid);
        }

        private Rectangle createRectangle(ImageSource imageSource)
        {
            Rectangle rectangle = new Rectangle();
            rectangle.Fill = new ImageBrush(imageSource);

            rectangle.Width = 50;
            rectangle.Height = 50;

            rectangle.Margin = new Thickness(0,14,0,0);
            rectangle.VerticalAlignment = VerticalAlignment.Top;

            rectangle.RadiusX = 50;
            rectangle.RadiusY = 50;

            return rectangle;
        }


        private void createUserProfile(string userName,string comment)
        {
            StackPanel stackPanel = new StackPanel();
            stackPanel.Margin = new Thickness(10);
            stackPanel.Width = 200;
            stackPanel.Height = 98;
            stackPanel.ClipToBounds = true;
            stackPanel.Children.Add(userNameStyle(userName));
            stackPanel.Children.Add(commentStyle(comment));
            this.Children.Add(stackPanel);

        }

        private TextBlock userNameStyle(string userName)
        {

            TextBlock userNameBlock = new TextBlock();
            userNameBlock.Text = userName;
            userNameBlock.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF555555")); // 전경색 설정
            userNameBlock.FontWeight = FontWeights.Bold;
            UserName = userNameBlock;

            return userNameBlock;
        }

        private TextBlock commentStyle(string comment)
        {
            TextBlock commentBlock = new TextBlock();
            commentBlock.Text = comment;
            commentBlock.FontSize = 12; // 글꼴 크기 설정
            commentBlock.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF555555")); // 전경색 설정
            commentBlock.TextDecorations = TextDecorations.Underline; // 텍스트 밑줄 장식 추가
            commentBlock.TextWrapping = TextWrapping.Wrap; // 텍스트 래핑 활성화
            userComment = commentBlock;

            return commentBlock;
        }


    }
}
