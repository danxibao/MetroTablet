using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Project_try.Music
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MusicMain : Page
    {
        
        public MusicMain()
        {
            this.InitializeComponent();

            MainPageItemData data=new MainPageItemData();
            data.Build();
            MainFrame.ItemsSource = data.Collection;
        }


        private void MainFrame_ItemClick(object sender, ItemClickEventArgs e)
        {
            MainPageItem position = (MainPageItem)e.ClickedItem;
            switch (position.Name)
            {
                case "催眠":
                    Frame.Navigate(typeof(MusicHypnosis));
                    break;
                case "减压\n放松":
                    Frame.Navigate(typeof(MusicDestress));
                    break;
                case "励志":
                    Frame.Navigate(typeof(Motivation));
                    break;
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            if (Frame != null && Frame.CanGoBack) Frame.GoBack();
        }
       
    }

    public class MainPageItem
    {
        public string Name { get; set; }
        public SolidColorBrush BackGroundBrush { get; set; }
    }

    public class MainPageItemData
    {
        public List<MainPageItem> Collection = new List<MainPageItem>();
        MainPageItem item = null;
        public void Build()
        {
            item = new MainPageItem();
            item.Name = "催眠";
            item.BackGroundBrush = new SolidColorBrush(Color.FromArgb(255,255,150,45));
            Collection.Add(item);

            item = new MainPageItem();
            item.Name = "减压\n放松";
            item.BackGroundBrush = new SolidColorBrush(Color.FromArgb(255, 50, 163, 192));
            Collection.Add(item);

            item = new MainPageItem();
            item.Name = "励志";
            item.BackGroundBrush = new SolidColorBrush(Color.FromArgb(255, 74, 225, 43));
            Collection.Add(item);
        }

        
    }
    
     
    
}
