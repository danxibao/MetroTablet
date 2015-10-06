using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Project_try
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Main : Page
    {
        public Main()
        {
            this.InitializeComponent();
        }


        private void self_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Grid position = (Grid)sender;
            switch (position.Name)
            {
                case "Media":
                    Frame.Navigate(typeof(AudioVisualMain));
                    break;
                case "Pic":
                    Frame.Navigate(typeof(Pictures.PicMain));
                    break;
                case "Music":
                    Frame.Navigate(typeof(Music.MusicMain));
                    break;
                case "Game":

                    break;
                case "Test":
                    Frame.Navigate(typeof(Login));
                    break;
                case "BrainWave":
                    
                    break;
                case "Grip":
                    
                    break;
                case "Scream":
                    
                    break;


            }

        }

        private void self_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            Grid position = (Grid)sender;
            switch (position.Name)
            {

                case "Media":
                    MediaRectangle.Height = 184;
                    MediaRectangle.Width = 252;
                    MediaBackground.Height = 204;
                    MediaBackground.Width = 272;
                    MediaText.FontSize = 55;
                    break;
                case "Music":
                    MusicRectangle.Height = 184;
                    MusicRectangle.Width = 252;
                    MusicBackground.Height = 204;
                    MusicBackground.Width = 272;
                    MusicText.FontSize = 55;
                    break;
                case "Game":
                    GameRectangle.Height = 184;
                    GameRectangle.Width = 252;
                    GameBackground.Height = 204;
                    GameBackground.Width = 272;
                    GameText.FontSize = 55;
                    break;
                case "Test":
                    TestRectangle.Height = 184;
                    TestRectangle.Width = 252;
                    TestBackground.Height = 204;
                    TestBackground.Width = 272;
                    TestText.FontSize = 55;
                    break;
                case "Pic":
                    PicRectangle.Height = 184;
                    PicRectangle.Width = 252;
                    PicBackground.Height = 204;
                    PicBackground.Width = 272;
                    PicText.FontSize = 55;
                    break;
                case "BrainWave":
                    BrainWaveRectangle.Height = 184;
                    BrainWaveRectangle.Width = 252;
                    BrainWaveBackground.Height = 204;
                    BrainWaveBackground.Width = 272;
                    BrainWaveText.FontSize = 55;
                    break;
                case "Grip":
                    GripRectangle.Height = 438;
                    GripRectangle.Width = 115;
                    GripBackground.Height = 458;
                    GripBackground.Width = 135;
                    GripText.FontSize = 55;
                    break;
                case "Scream":
                    ScreamRectangle.Height = 438;
                    ScreamRectangle.Width = 115;
                    ScreamBackground.Height = 458;
                    ScreamBackground.Width = 135;
                    ScreamText.FontSize = 55;
                    break;
            }
        }

        private void self_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            Grid position = (Grid)sender;
            switch (position.Name)
            {
                case "Media":
                    MediaRectangle.Height = 204;
                    MediaRectangle.Width = 272;
                    MediaBackground.Height = 224;
                    MediaBackground.Width = 292;
                    MediaText.FontSize = 60;
                    //Frame.Navigate(typeof(AudioVisualMain));
                    break;
                case "Music":
                    MusicRectangle.Height = 204;
                    MusicRectangle.Width = 272;
                    MusicBackground.Height = 224;
                    MusicBackground.Width = 292;
                    MusicText.FontSize = 60;
                    //Frame.Navigate(typeof(Music.MusicMain));
                    break;
                case "Game":
                    GameRectangle.Height = 204;
                    GameRectangle.Width = 272;
                    GameBackground.Height = 224;
                    GameBackground.Width = 292;
                    GameText.FontSize = 60;
                    break;
                case "Test":
                    TestRectangle.Height = 204;
                    TestRectangle.Width = 272;
                    TestBackground.Height = 224;
                    TestBackground.Width = 292;
                    TestText.FontSize = 60;
                    break;
                case "Pic":
                    PicRectangle.Height = 204;
                    PicRectangle.Width = 272;
                    PicBackground.Height = 224;
                    PicBackground.Width = 292;
                    PicText.FontSize = 60;
                    //Frame.Navigate(typeof(Pictures.PicMain));
                    break;
                case "BrainWave":
                    BrainWaveRectangle.Height = 204;
                    BrainWaveRectangle.Width = 272;
                    BrainWaveBackground.Height = 224;
                    BrainWaveBackground.Width = 292;
                    BrainWaveText.FontSize = 60;
                    break;
                case "Grip":
                    GripRectangle.Height = 438;
                    GripRectangle.Width = 115;
                    GripBackground.Height = 458;
                    GripBackground.Width = 135;
                    GripText.FontSize = 60;
                    break;
                case "Scream":
                    ScreamRectangle.Height = 438;
                    ScreamRectangle.Width = 115;
                    ScreamBackground.Height = 458;
                    ScreamBackground.Width = 135;
                    ScreamText.FontSize = 60;
                    break;
            }
        }

        private void self_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            Grid position = (Grid)sender;
            switch (position.Name)
            {

                case "Media":
                    MediaBackground.Opacity = 0.31;
                    break;
                case "Music":
                    MusicBackground.Opacity = 0.31;
                    break;
                case "Game":
                    GameBackground.Opacity = 0.31;
                    break;
                case "Test":
                    TestBackground.Opacity = 0.31;
                    break;
                case "Pic":
                    PicBackground.Opacity = 0.31;
                    break;
                case "BrainWave":
                    BrainWaveBackground.Opacity = 0.31;
                    break;
                case "Grip":
                    GripBackground.Opacity = 0.31;
                    break;
                case "Scream":
                    ScreamBackground.Opacity = 0.31;
                    break;
            }
        }

        private void self_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            Grid position = (Grid)sender;
            switch (position.Name)
            {
                case "Media":
                    MediaRectangle.Height = 204;
                    MediaRectangle.Width = 272;
                    MediaBackground.Height = 224;
                    MediaBackground.Width = 292;
                    MediaBackground.Opacity = 0;
                    MediaText.FontSize = 60;
                    break;
                case "Music":
                    MusicRectangle.Height = 204;
                    MusicRectangle.Width = 272;
                    MusicBackground.Height = 224;
                    MusicBackground.Width = 292;
                    MusicBackground.Opacity = 0;
                    MusicText.FontSize = 60;
                    break;
                case "Game":
                    GameRectangle.Height = 204;
                    GameRectangle.Width = 272;
                    GameBackground.Height = 224;
                    GameBackground.Width = 292;
                    GameBackground.Opacity = 0;
                    GameText.FontSize = 60;
                    break;
                case "Test":
                    TestRectangle.Height = 204;
                    TestRectangle.Width = 272;
                    TestBackground.Height = 224;
                    TestBackground.Width = 292;
                    TestBackground.Opacity = 0;
                    TestText.FontSize = 60;
                    break;
                case "Pic":
                    PicRectangle.Height = 204;
                    PicRectangle.Width = 272;
                    PicBackground.Height = 224;
                    PicBackground.Width = 292;
                    PicBackground.Opacity = 0;
                    PicText.FontSize = 60;
                    break;
                case "BrainWave":
                    BrainWaveRectangle.Height = 204;
                    BrainWaveRectangle.Width = 272;
                    BrainWaveBackground.Height = 224;
                    BrainWaveBackground.Width = 292;
                    BrainWaveBackground.Opacity = 0;
                    BrainWaveText.FontSize = 60;
                    break;
                case "Grip":
                    GripRectangle.Height = 458;
                    GripRectangle.Width = 135;
                    GripBackground.Height = 478;
                    GripBackground.Width = 155;
                    GripBackground.Opacity = 0;
                    GripText.FontSize = 60;
                    break;
                case "Scream":
                    ScreamRectangle.Height = 458;
                    ScreamRectangle.Width = 135;
                    ScreamBackground.Height = 478;
                    ScreamBackground.Width = 155;
                    ScreamBackground.Opacity = 0;
                    ScreamText.FontSize = 60;
                    break;
            }
        }

    }
}
