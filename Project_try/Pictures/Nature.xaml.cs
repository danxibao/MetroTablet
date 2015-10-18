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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace Project_try.Pictures
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class Nature : Page
    {
        ImagePathData imgpatharray = new ImagePathData();

        public Nature()
        {
            this.InitializeComponent();

            photo_Nature.ItemsSource = imgpatharray.ImagePathList;
        }


        private void photo_ItemClick(object sender, ItemClickEventArgs e)
        {
            //int index = (((GridView)sender).Items.IndexOf(e.ClickedItem));
            ImagePath SelectedImage = (ImagePath)e.ClickedItem;
            media.Source = new Uri(SelectedImage.aviPath);

            PhotoDetail.IsOpen = true;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (Frame != null && Frame.CanGoBack) Frame.GoBack();
        }

        bool IsFullScreen = false;
        private void FullScreen_Click(object sender, RoutedEventArgs e)
        {
            if (IsFullScreen)
            {
                PhotoDetail.Height = 500;
                PhotoDetail.Width = 800;
                PopGrid.Height = 500;
                PopGrid.Width = 800;
                FullScreenButton.Icon = new SymbolIcon(Symbol.FullScreen);
            }
            else
            {
                PhotoDetail.Height = 900;
                PhotoDetail.Width = 1440;
                PopGrid.Height = 900;
                PopGrid.Width = 1440;
                FullScreenButton.Icon = new SymbolIcon(Symbol.BackToWindow);
            }
            IsFullScreen = !IsFullScreen;
        }

    }


}
