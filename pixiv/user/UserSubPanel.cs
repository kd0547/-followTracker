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

    public class UserSubPanel : DockPanel
    {
        private Button followingButton;
        private Rectangle rectangle;
        public UserSubPanel()
        {
            this.Margin = new Thickness(0);


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
            button.Style = this.ButtonStyle();

            SetDock(button, Dock.Left); // DockPanel.Dock="Left" 설정

            return button;
        }

        private Style ButtonStyle()
        {
            Style followingButtonStyle = new Style { TargetType = typeof(Button) };
            followingButtonStyle.Setters.Add(new Setter(Button.BackgroundProperty, new SolidColorBrush((Color)ColorConverter.ConvertFromString("#f5f5f5"))));
            followingButtonStyle.Setters.Add(new Setter(Button.BorderBrushProperty, new SolidColorBrush((Color)ColorConverter.ConvertFromString("#f5f5f5"))));
            followingButtonStyle.Setters.Add(new Setter(Button.ForegroundProperty, new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF555555"))));
            followingButtonStyle.Setters.Add(new Setter(Button.FontSizeProperty, 12.0));
            followingButtonStyle.Setters.Add(new Setter(Button.FontWeightProperty, FontWeights.Bold));
            followingButtonStyle.Setters.Add(new Setter(Button.PaddingProperty, new Thickness(10, 3, 10, 3)));
            followingButtonStyle.Setters.Add(new Setter(Button.BorderThicknessProperty, new Thickness(1)));
            followingButtonStyle.Setters.Add(new Setter(Button.HorizontalContentAlignmentProperty, HorizontalAlignment.Center));
            followingButtonStyle.Setters.Add(new Setter(Button.VerticalContentAlignmentProperty, VerticalAlignment.Center));
            followingButtonStyle.Setters.Add(new Setter(Button.CursorProperty, Cursors.Hand));

            ControlTemplate buttonTemplate = new ControlTemplate(typeof(Button));
            FrameworkElementFactory borderFactory = new FrameworkElementFactory(typeof(Border));
            borderFactory.SetValue(Border.BackgroundProperty, new TemplateBindingExtension(Button.BackgroundProperty));
            borderFactory.SetValue(Border.BorderBrushProperty, new TemplateBindingExtension(Button.BorderBrushProperty));
            borderFactory.SetValue(Border.BorderThicknessProperty, new TemplateBindingExtension(Button.BorderThicknessProperty));
            borderFactory.SetValue(Border.CornerRadiusProperty, new CornerRadius(15));

            FrameworkElementFactory contentPresenterFactory = new FrameworkElementFactory(typeof(ContentPresenter));
            contentPresenterFactory.SetValue(ContentPresenter.HorizontalAlignmentProperty, new TemplateBindingExtension(Button.HorizontalContentAlignmentProperty));
            contentPresenterFactory.SetValue(ContentPresenter.VerticalAlignmentProperty, new TemplateBindingExtension(Button.VerticalContentAlignmentProperty));
            contentPresenterFactory.SetValue(TextElement.ForegroundProperty, new TemplateBindingExtension(Button.ForegroundProperty));
            contentPresenterFactory.SetValue(TextElement.FontSizeProperty, new TemplateBindingExtension(Button.FontSizeProperty));
            contentPresenterFactory.SetValue(TextElement.FontWeightProperty, new TemplateBindingExtension(Button.FontWeightProperty));

            borderFactory.AppendChild(contentPresenterFactory);
            buttonTemplate.VisualTree = borderFactory;
            followingButtonStyle.Setters.Add(new Setter(Button.TemplateProperty, buttonTemplate));

            return followingButtonStyle;
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
