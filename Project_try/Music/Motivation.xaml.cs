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
using Windows.UI.Xaml.Media.Imaging;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Project_try.Music
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Motivation : Page
    {

        public Motivation()
        {
            this.InitializeComponent();

            MotivationItemData data = new MotivationItemData();
            data.Build();
            MainFrame.ItemsSource = data.Collection;
        }


        private void MainFrame_ItemClick(object sender, ItemClickEventArgs e)
        {
            MotivationItem position = (MotivationItem)e.ClickedItem;
            switch (position.Name)
            {
                case "请您欣赏":
                    Frame.Navigate(typeof(Admiration));
                    break;
                case "引吭高歌":
                    Frame.Navigate(typeof(SingAloud));
                    break;
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            if (Frame != null && Frame.CanGoBack) Frame.GoBack();
        }
       
    }

    public class MotivationItem
    {
        public string Name { get; set; }
        public BitmapImage BackGroundBrush { get; set; }
    }

    public class MotivationItemData
    {
        public List<MotivationItem> Collection = new List<MotivationItem>();
        MotivationItem item = null;
        public void Build()
        {
            item = new MotivationItem();
            item.Name = "请您欣赏";
            item.BackGroundBrush = new BitmapImage(new Uri("ms-appx:///Assets/Music/Motivation/请您欣赏.png"));
            Collection.Add(item);

            item = new MotivationItem();
            item.Name = "引吭高歌";
            item.BackGroundBrush = new BitmapImage(new Uri("ms-appx:///Assets/Music/Motivation/引吭高歌.png"));
            Collection.Add(item);

        }

        
    }
    
     
    
}
