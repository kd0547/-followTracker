using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Shapes;

namespace pixiv.user
{
    public class UserillustsSection : ScrollViewer
    {

        private StackPanel illustsPanel;


        public UserillustsSection() 
        {
            this.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
            this.VerticalScrollBarVisibility = ScrollBarVisibility.Disabled;
            this.Margin = new Thickness(10);
            
            illustsPanel = new StackPanel();
            illustsPanel.Orientation = Orientation.Horizontal;

            Style newScrollBarStyle = new Style(typeof(ScrollBar));
            Style basedStyle = (Style)Application.Current.Resources["HorizontalScrollBarStyle"];
            newScrollBarStyle.BasedOn = basedStyle;
            this.Resources.Add(typeof(ScrollBar), newScrollBarStyle);

        }

        public void Addillusts(UIElement element)
        {
            illustsPanel.Children.Add(element);
        }

        public void Create(ImageSource image)
        {
            Grid grid = new Grid();
            Rectangle rectangle = new Rectangle();
            ImageBrush imageBrush = new ImageBrush(image);
            imageBrush.Stretch = Stretch.UniformToFill;
            rectangle.Fill = imageBrush;

            rectangle.RadiusX = 20;
            rectangle.RadiusY = 20;
        }
    }
}
