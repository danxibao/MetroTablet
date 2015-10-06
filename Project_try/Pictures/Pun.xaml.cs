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
using Windows.UI.Xaml.Media.Imaging;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Project_try.Pictures
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Pun : Page
    {
        PunPathData data = new PunPathData();
        public Pun()
        {
            this.InitializeComponent();

            photo_Pun.ItemsSource = data.ImagePathList;
        }
        private void photo_ItemClick(object sender, ItemClickEventArgs e)
        {
            ImagePath SelectedImage = (ImagePath)e.ClickedItem;
            dImage.Source = new BitmapImage(new Uri(SelectedImage.ImgPath));

            PhotoDetail.IsOpen = true;
        }


        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (Frame != null && Frame.CanGoBack) Frame.GoBack();
        }
    }
}
