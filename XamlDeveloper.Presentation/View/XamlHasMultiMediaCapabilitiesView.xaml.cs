namespace XamlDeveloper.Presentation.View {
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using Prism.Regions;
    using Wpf.Common.Unity;

    [RegionMemberLifetime(KeepAlive = false)]
    [ViewContainerInitializer]
    public partial class XamlHasMultiMediaCapabilitiesView : UserControl {

        public XamlHasMultiMediaCapabilitiesView() {
            InitializeComponent();
            SetPlayerStatus(false);
        }

        void btnMoveBack_Click(Object sender, RoutedEventArgs e) {
            this.MediaPlayer.Position -= TimeSpan.FromSeconds(10);
        }

        void btnMoveForward_Click(Object sender, RoutedEventArgs e) {
            this.MediaPlayer.Position += TimeSpan.FromSeconds(10);
        }

        void btnPause_Click(Object sender, RoutedEventArgs e) {
            SetPlayerStatus(false);
            this.MediaPlayer.Pause();
        }

        void btnPlay_Click(Object sender, RoutedEventArgs e) {
            SetPlayerStatus(true);
            this.MediaPlayer.Play();
        }

        void btnStop_Click(Object sender, RoutedEventArgs e) {
            this.MediaPlayer.Stop();
            this.MediaPlayer.Position = new TimeSpan(0);
            SetPlayerStatus(false);
        }

        void SetPlayerStatus(Boolean isPlaying) {
            this.btnStop.IsEnabled = isPlaying;
            this.btnMoveBack.IsEnabled = isPlaying;
            this.btnMoveForward.IsEnabled = isPlaying;
            if (isPlaying) {
                this.btnPlay.Visibility = Visibility.Collapsed;
                this.btnPause.Visibility = Visibility.Visible;
                this.btnPause.IsEnabled = true;
            } else {
                this.btnPlay.Visibility = Visibility.Visible;
                this.btnPause.Visibility = Visibility.Collapsed;
                this.btnPlay.IsEnabled = true;
            }
        }

    }
}
