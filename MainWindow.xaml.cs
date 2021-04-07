using RockstarGameLauncherUI.CControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RockstarGameLauncherUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void home_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void MediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            ResIsLoaded = true;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void RestoreButton_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }



        public bool ResIsLoaded
        {
            get { return (bool)GetValue(ResIsLoadedProperty); }
            set { SetValue(ResIsLoadedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ResIsLoaded.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ResIsLoadedProperty =
            DependencyProperty.Register("ResIsLoaded", typeof(bool), typeof(MainWindow), new PropertyMetadata(false));



        public bool IsMenuExpanded
        {
            get { return (bool)GetValue(IsMenuExpandedProperty); }
            set { SetValue(IsMenuExpandedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsMenuExpanded.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsMenuExpandedProperty =
            DependencyProperty.Register("IsMenuExpanded", typeof(bool), typeof(MainWindow), new PropertyMetadata(true));

        private void navLeftBtn_Click(object sender, RoutedEventArgs e)
        {
            navLeftBtn.IsEnabled = false;
            navRightBtn.Visibility = Visibility.Visible;

            double offset = (double)scrollViewer.GetValue(CustomScrollViewer.MyOffsetProperty);
            DoubleAnimation goLeft = new DoubleAnimation(
                offset,
                offset - 246 - 20,
                new Duration(TimeSpan.FromSeconds(.5)))
            { AccelerationRatio = .2, DecelerationRatio = .8 };

            goLeft.Completed += GoLeft_Completed; ;
            scrollViewer.BeginAnimation(CustomScrollViewer.MyOffsetProperty, goLeft);
        }

        private void GoLeft_Completed(object sender, EventArgs e)
        {
            navLeftBtn.IsEnabled = true;
            if (Convert.ToInt32(scrollViewer.HorizontalOffset) == 0)
                navLeftBtn.Visibility = Visibility.Collapsed;
        }

        private void navRightBtn_Click(object sender, RoutedEventArgs e)
        {
            navRightBtn.IsEnabled = false;
            IsMenuExpanded = false;
            navLeftBtn.Visibility = Visibility.Visible;

            double offset = (double)scrollViewer.GetValue(CustomScrollViewer.MyOffsetProperty);
            DoubleAnimation goRight = new DoubleAnimation(
                offset,
                offset + 246 + 20,
                new Duration(TimeSpan.FromSeconds(.5)))
            { AccelerationRatio = .2, DecelerationRatio = .8 };

            goRight.Completed += GoRight_Completed;
            scrollViewer.BeginAnimation(CustomScrollViewer.MyOffsetProperty, goRight);
        }

        private void GoRight_Completed(object sender, EventArgs e)
        {
            navRightBtn.IsEnabled = true;
            if (Convert.ToInt32(scrollViewer.HorizontalOffset) == Convert.ToInt32(scrollViewer.ScrollableWidth))
                navRightBtn.Visibility = Visibility.Collapsed;
        }
    }
}