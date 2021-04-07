using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace RockstarGameLauncherUI.CControl
{
    public class CustomScrollViewer: ScrollViewer
    {
        public double MyOffset
        {
            get { return (double)GetValue(ScrollViewer.HorizontalOffsetProperty); }
            set { this.ScrollToHorizontalOffset(value); }
        }

        // Using a DependencyProperty as the backing store for MyOffset.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyOffsetProperty =
            DependencyProperty.Register("MyOffset", typeof(double), typeof(CustomScrollViewer), new PropertyMetadata(new PropertyChangedCallback(Onchanged)));

        private static void Onchanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((CustomScrollViewer)d).MyOffset = (double)e.NewValue;
        }
    }
}
