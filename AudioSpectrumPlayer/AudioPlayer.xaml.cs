using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AudioSpectrumPlayer
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class AudioPlayer : UserControl, INotifyPropertyChanged
    {

        public static readonly DependencyProperty FirstColorProperty = DependencyProperty.Register("FirstColor", typeof(System.Windows.Media.Brush), typeof(AudioPlayer), new PropertyMetadata(null));
        public static readonly DependencyProperty SecondColorProperty = DependencyProperty.Register("SecondColor", typeof(System.Windows.Media.Brush), typeof(AudioPlayer), new PropertyMetadata(null));
        public static readonly DependencyProperty OpacityColorProperty = DependencyProperty.Register("OpacityColor", typeof(double), typeof(AudioPlayer), new PropertyMetadata(null));
        public static readonly DependencyProperty SongProperty = DependencyProperty.Register("Song", typeof(double), typeof(AudioPlayer), new PropertyMetadata(null));
        public static readonly DependencyProperty PlayListProperty = DependencyProperty.Register("PlayList", typeof(List<string>), typeof(AudioPlayer), new PropertyMetadata(null));

        private Audion.OutputSource currentTrack = new Audion.OutputSource();
        
        public event PropertyChangedEventHandler PropertyChanged;

        private System.Windows.Media.Brush firstColor = System.Windows.Media.Brushes.Black;
        private System.Windows.Media.Brush secondColor = System.Windows.Media.Brushes.Wheat;
        private double opacityColor = 0.7;
        private string song;
        private List<string> playList = new List<string>();

        public System.Windows.Media.Brush FirstColor { get => firstColor; set {
                firstColor = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FirstColor"));
            } }
        public System.Windows.Media.Brush SecondColor { get => secondColor; set {
                secondColor = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SecondColor"));
            } }
        public double OpacityColor { get => opacityColor; set {
                opacityColor = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("OpacityColor"));
            } }

        public string Song { get => song; set {
                if (currentTrack.IsPlaying) audioStop( this, new RoutedEventArgs());
                song = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Song"));
            }
        }
        public double SpectrumHeight => spectrum.ActualHeight;

        public List<string> PlayList { get => playList; set {
                PlayList = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PlayList"));
            } }

        public AudioPlayer()
        {
            InitializeComponent();
            spectrum.Source = currentTrack;
        }

        public void adjustFrequencies(int a, int b)
        {
            spectrum.adjustFrequency(a, b);
        }

        private void setTBS(string loadingSong)
        {
            var file = TagLib.File.Create(loadingSong);
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(loadingSong);
            TagLib.IPicture picture;
            switch (fileInfo.Extension)
            {
                case ".flac":
                    textSub.Text = file.GetTag(TagLib.TagTypes.FlacMetadata).AlbumArtists[0];
                    textMain.Text = file.GetTag(TagLib.TagTypes.FlacMetadata).Title;
                    try
                    {
                        picture = file.GetTag(TagLib.TagTypes.FlacMetadata).Pictures[0];
                    }
                    catch (Exception e) { picture = null; }
                    break;
                case ".mp3":
                    textSub.Text = file.GetTag(TagLib.TagTypes.Id3v2).AlbumArtists[0];
                    textMain.Text = file.GetTag(TagLib.TagTypes.Id3v2).Title;
                    try
                    {
                        picture = file.GetTag(TagLib.TagTypes.Id3v2).Pictures[0];
                    }
                    catch (Exception e) { picture = null; }
                    break;
                default:
                    textSub.Text = "Song Artist";
                    textMain.Text = "Song Name";
                    picture = null;
                    songAlbumArt.Source = null;
                    songAlbumArtFiller.Visibility = Visibility.Visible;
                    songAlbumArt.Visibility = Visibility.Collapsed;
                    break;
            }
            if (picture != null)
            {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(picture.Data.Data);
                    ms.Seek(0, System.IO.SeekOrigin.Begin);

                    // ImageSource for System.Windows.Controls.Image
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.StreamSource = ms;
                    bitmap.EndInit();

                    // Create a System.Windows.Controls.Image control
                    songAlbumArt.Source = bitmap;
                    songAlbumArtFiller.Visibility = Visibility.Collapsed;
                    songAlbumArt.Visibility = Visibility.Visible;
            }
        }

        private void audioPlay(object sender, RoutedEventArgs e)
        {
            if (currentTrack.Paused) currentTrack.Resume();
            else
            {
                if (PlayList.Count > 0) Song = PlayList[0];
                if (new System.IO.FileInfo(song).Exists == false) return;
                currentTrack.Load(Song);
                setTBS(Song);
                currentTrack.Play();
                currentTrack.Volume = (float)(buttonVolume.Value / 100f);
                buttonVolume.IsEnabled = true;
            }
            buttonPlay.Visibility = Visibility.Collapsed;
            buttonPause.Visibility = Visibility.Visible;
        }

        private void audioPause(object sender, RoutedEventArgs e)
        {
            currentTrack.Pause();
            buttonPlay.Visibility = Visibility.Visible;
            buttonPause.Visibility = Visibility.Collapsed;
        }

        private void audioStop(object sender, RoutedEventArgs e)
        {
            currentTrack.Stop();
            currentTrack.Dispose();
            buttonVolume.IsEnabled = false;
            buttonPlay.Visibility = Visibility.Visible;
            buttonPause.Visibility = Visibility.Collapsed;
            textSub.Text = "Song Artist";
            textMain.Text = "Song Name";
            songAlbumArt.Source = null;
            songAlbumArtFiller.Visibility = Visibility.Visible;
            songAlbumArt.Visibility = Visibility.Collapsed;
        }

        private void audioTrackPrevious(object sender, RoutedEventArgs e)
        {
            var index = PlayList.IndexOf(Song);
            if (index <= 0) return;
            audioStop(sender, e);
            Song = PlayList[index - 1];
            audioPlay(sender, e);
        }

        private void audioTrackNext(object sender, RoutedEventArgs e)
        {
            var index = PlayList.IndexOf(Song);
            if (index >= PlayList.Count-1) return;
            audioStop(sender, e);
            Song = PlayList[index + 1];
            audioPlay(sender, e);
        }

        private void audioVolumChange(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            currentTrack.Volume = (float)(buttonVolume.Value/100f);
        }

        private void audioUnloaded(object sender, RoutedEventArgs e)
        {
            audioStop(sender, e);
        }
    }

}
