using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace IEMS.WPF.Controls
{
    public enum ToastType
    {
        Success,
        Error,
        Warning,
        Info
    }

    public partial class ToastNotification : UserControl
    {
        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof(string), typeof(ToastNotification), new PropertyMetadata(""));

        public static readonly DependencyProperty ToastTypeProperty =
            DependencyProperty.Register("ToastType", typeof(ToastType), typeof(ToastNotification),
                new PropertyMetadata(ToastType.Info, OnToastTypeChanged));

        public static readonly DependencyProperty ToastBackgroundProperty =
            DependencyProperty.Register("ToastBackground", typeof(Brush), typeof(ToastNotification));

        public static readonly DependencyProperty ToastIconProperty =
            DependencyProperty.Register("ToastIcon", typeof(string), typeof(ToastNotification));

        private DispatcherTimer? _hideTimer;

        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        public ToastType ToastType
        {
            get { return (ToastType)GetValue(ToastTypeProperty); }
            set { SetValue(ToastTypeProperty, value); }
        }

        public Brush ToastBackground
        {
            get { return (Brush)GetValue(ToastBackgroundProperty); }
            set { SetValue(ToastBackgroundProperty, value); }
        }

        public string ToastIcon
        {
            get { return (string)GetValue(ToastIconProperty); }
            set { SetValue(ToastIconProperty, value); }
        }

        public ToastNotification()
        {
            InitializeComponent();
            UpdateToastStyle();
        }

        private static void OnToastTypeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var toast = (ToastNotification)d;
            toast.UpdateToastStyle();
        }

        private void UpdateToastStyle()
        {
            switch (ToastType)
            {
                case ToastType.Success:
                    ToastBackground = new SolidColorBrush(Color.FromRgb(16, 185, 129)); // Green
                    ToastIcon = "✓";
                    break;
                case ToastType.Error:
                    ToastBackground = new SolidColorBrush(Color.FromRgb(239, 68, 68)); // Red
                    ToastIcon = "✗";
                    break;
                case ToastType.Warning:
                    ToastBackground = new SolidColorBrush(Color.FromRgb(245, 158, 11)); // Amber
                    ToastIcon = "⚠";
                    break;
                case ToastType.Info:
                default:
                    ToastBackground = new SolidColorBrush(Color.FromRgb(59, 130, 246)); // Blue
                    ToastIcon = "ℹ";
                    break;
            }
        }

        public void Show(int durationMs = 3000)
        {
            var showStoryboard = (Storyboard)Resources["ShowToast"];
            showStoryboard.Begin(this);

            _hideTimer = new DispatcherTimer();
            _hideTimer.Interval = TimeSpan.FromMilliseconds(durationMs);
            _hideTimer.Tick += (s, e) => Hide();
            _hideTimer.Start();
        }

        public void Hide()
        {
            _hideTimer?.Stop();
            var hideStoryboard = (Storyboard)Resources["HideToast"];
            hideStoryboard.Completed += (s, e) => { Visibility = Visibility.Collapsed; };
            hideStoryboard.Begin(this);
        }
    }
}