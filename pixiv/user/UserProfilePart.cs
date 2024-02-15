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

        private Ellipse ellipse;
        

        public bool following;
        public bool followed;
        public bool isBlocking;
        public bool isMypixiv;

        public UserProfilePart()
        {
            this.Orientation = Orientation.Horizontal;
            this.Margin = new Thickness(10);

            createEl();
            testProfile();

        }

        public void createEl()
        {
            Ellipse ellipse = new Ellipse();
            ellipse.Width = 50;
            ellipse.Height = 50;
            ellipse.Fill = new SolidColorBrush(Colors.Pink);
            ellipse.Stroke = new SolidColorBrush(Colors.Black);
            ellipse.StrokeThickness = 2;
            this.Children.Add(ellipse);
        }

        public void testProfile()
        {
            StackPanel stackPanel = new StackPanel();
            stackPanel.Margin = new Thickness(10);
            stackPanel.Width = 200;

            string userName = "美和野らぐ";
            string Comment = "◼︎ Do not repost.無断転載禁止 ◼︎質問、ご依頼等ございましたら、HP記載のアドレスまでご連絡ください。(ブラウザ版で開いてください） pixivのメッセージからのご依頼、質…\r\n";


            TextBlock userNameBlock = new TextBlock();
            userNameBlock.Text = userName;
            userNameBlock.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF555555")); // 전경색 설정
            userNameBlock.FontWeight = FontWeights.Bold;
            UserName = userNameBlock;

            TextBlock comment = new TextBlock();
            comment.Text = Comment;
            comment.FontSize = 12; // 글꼴 크기 설정
            comment.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF555555")); // 전경색 설정
            comment.TextDecorations = TextDecorations.Underline; // 텍스트 밑줄 장식 추가
            comment.TextWrapping = TextWrapping.Wrap; // 텍스트 래핑 활성화
            userComment = comment;

            stackPanel.Children.Add(userNameBlock);
            stackPanel.Children.Add(comment);
            this.Children.Add(stackPanel);
        }
    }
}
