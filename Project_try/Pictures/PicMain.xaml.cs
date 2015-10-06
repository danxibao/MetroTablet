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

namespace Project_try.Pictures
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PicMain : Page
    {
        public PicMain()
        {
            this.InitializeComponent();
        }

        private void self_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Grid position = (Grid)sender;
            switch (position.Name)
            {
                case "Nature":
                    Frame.Navigate(typeof(Nature));
                    break;
                case "Pun":
                    Frame.Navigate(typeof(Pun));
                    break;
                case "Illusion":
                    Frame.Navigate(typeof(Illusion));
                    break;
            }

        }

        private void self_Entered(object sender, PointerRoutedEventArgs e)
        {
            Grid position = (Grid)sender;
            switch (position.Name)
            {

                case "Nature":
                    R1.Opacity = 0;
                    break;
                case "Pun":
                    R2.Opacity = 0;
                    break;
                case "Illusion":
                    R3.Opacity = 0;
                    break;
            }
        }

        private void self_Exited(object sender, PointerRoutedEventArgs e)
        {
            Grid position = (Grid)sender;
            switch (position.Name)
            {

                case "Nature":
                    R1.Opacity = 0.3;

                    break;
                case "Pun":
                    R2.Opacity = 0.3;

                    break;
                case "Illusion":
                    R3.Opacity = 0.3;

                    break;
            }
        }
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            if (Frame != null && Frame.CanGoBack) Frame.GoBack();
        }


    }
}
