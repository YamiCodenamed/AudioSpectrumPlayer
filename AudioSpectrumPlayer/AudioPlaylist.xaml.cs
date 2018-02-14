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
    /// Interaction logic for AudioPlaylist.xaml
    /// </summary>
    public partial class AudioPlaylist : UserControl, System.ComponentModel.INotifyPropertyChanged
    {
        public static readonly DependencyProperty FirstColorProperty = DependencyProperty.Register("FirstColor", typeof(System.Windows.Media.Brush), typeof(AudioPlayer), new PropertyMetadata(null));
        public static readonly DependencyProperty SecondColorProperty = DependencyProperty.Register("SecondColor", typeof(System.Windows.Media.Brush), typeof(AudioPlayer), new PropertyMetadata(null));
        public static readonly DependencyProperty OpacityColorProperty = DependencyProperty.Register("OpacityColor", typeof(double), typeof(AudioPlayer), new PropertyMetadata(null));
        public static readonly DependencyProperty PlayListProperty = DependencyProperty.Register("PlayList", typeof(List<string>), typeof(AudioPlayer), new PropertyMetadata(null));

        private System.Windows.Media.Brush firstColor = System.Windows.Media.Brushes.Black;
        private System.Windows.Media.Brush secondColor = System.Windows.Media.Brushes.Wheat;
        private double opacityColor = 0.7;
        private List<string> playList;

        public event PropertyChangedEventHandler PropertyChanged;

        public System.Windows.Media.Brush FirstColor
        {
            get => firstColor; set
            {
                firstColor = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FirstColor"));
            }
        }
        public System.Windows.Media.Brush SecondColor
        {
            get => secondColor; set
            {
                secondColor = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SecondColor"));
            }
        }
        public double OpacityColor
        {
            get => opacityColor; set
            {
                opacityColor = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("OpacityColor"));
            }
        }

        public List<string> PlayList
        {
            get => playList; set
            {
                PlayList = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PlayList"));
            }
        }

        public AudioPlaylist()
        {
            InitializeComponent();
        }

        private void changeVisibility(object sender, RoutedEventArgs e)
        {
            var temp = sender as Button;
            if (temp.Name=="buttonHide")
            {
                buttonShow.Visibility = Visibility.Visible;
                buttonHide.Visibility = Visibility.Collapsed;
                return;
            }
            buttonShow.Visibility = Visibility.Collapsed;
            buttonHide.Visibility = Visibility.Visible;
        }
    }
}
