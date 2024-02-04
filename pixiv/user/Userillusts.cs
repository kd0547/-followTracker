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
    public class Userillusts : ScrollViewer
    {

        private StackPanel illustsPanel;


        public Userillusts() 
        {
            this.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
            this.VerticalScrollBarVisibility = ScrollBarVisibility.Disabled;
            this.Margin = new Thickness(10);
            
            illustsPanel = new StackPanel();
            illustsPanel.Orientation = Orientation.Horizontal;

            this.Style = style();
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


        private Style style()
        {
            Style style = new Style { TargetType = typeof(ScrollBar) };
            style.Setters.Add(new Setter(Control.BackgroundProperty, Brushes.Transparent));
            ControlTemplate template = new ControlTemplate(typeof(ScrollBar));

            var grid = new FrameworkElementFactory(typeof(Grid));
            var track = new FrameworkElementFactory(typeof(Track), "PART_Track");
            track.SetValue(Track.IsDirectionReversedProperty, false);
            track.SetValue(Track.OrientationProperty, Orientation.Horizontal);

            var thumb = new FrameworkElementFactory(typeof(Thumb));
            ControlTemplate thumbTemplate = new ControlTemplate(typeof(Thumb));
            
            var thumbBorder = new FrameworkElementFactory(typeof(Border));
            thumbBorder.SetValue(Border.BackgroundProperty, new SolidColorBrush(Color.FromRgb(192, 192, 192)));
            thumbBorder.SetValue(Border.HeightProperty, 4.0);
            thumbBorder.SetValue(Border.WidthProperty, 80.0);
            thumbBorder.SetValue(Border.CornerRadiusProperty, new CornerRadius(2));

            thumbTemplate.VisualTree = thumbBorder;
            thumb.SetValue(Thumb.TemplateProperty, thumbTemplate);
            track.AppendChild(thumb);
            grid.AppendChild(track);

            template.VisualTree = grid;
            style.Setters.Add(new Setter(Control.TemplateProperty, template));

            Trigger trigger = new Trigger { Property = ScrollBar.OrientationProperty, Value = Orientation.Horizontal };
            trigger.Setters.Add(new Setter(ScrollBar.HeightProperty, 4.0));
            trigger.Setters.Add(new Setter(ScrollBar.WidthProperty, 80.0));
            trigger.Setters.Add(new Setter(ScrollBar.MarginProperty, new Thickness(0, 0, 0, -20)));
            style.Triggers.Add(trigger);


            return style;
        }
    }
}
