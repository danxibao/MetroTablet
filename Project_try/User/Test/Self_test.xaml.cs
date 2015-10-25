using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
 
// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace Project_try
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class Self_test : Page
    {
        public Self_test()
        {
            this.InitializeComponent();

            list_set();
        }
        private long paper_id_clicked = -1;
        public void list_set()
        {
            test_list.Width = Window.Current.Bounds.Width*0.6;
            test_list.Height = Window.Current.Bounds.Height * 0.6;
        }

        async protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //if (e.NavigationMode == NavigationMode.New || e.NavigationMode == NavigationMode.Back)
            //{
                string resp_body=await new HttpClient().GetStringAsync(Config.service_url+"/PaperService/list");
                List<Paper> paper_list = JsonConvert.DeserializeObject<List<Paper>>(resp_body);
                test_list.ItemsSource = paper_list;

           // }
        }

        private void item_Click(object sender, ItemClickEventArgs e)
        {
            /*
            MessageDialog msg = new MessageDialog(e.ClickedItem.ToString());
            msg.ShowAsync();*/
            Paper paper = (Paper)e.ClickedItem;
            String s = e.ClickedItem.ToString();
            paper_id_clicked = paper.id;
            this.pop_up_a.IsOpen = true;
            title_a.Text = paper.ToString();
            content_a.Text = paper.desc;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(test_a), paper_id_clicked);

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (Frame != null && Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }

        private async void User_info_Click(object sender, RoutedEventArgs e)
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
                () =>
                {
                    Frame.Navigate(typeof(User_info));
                });
        }

        private async void ChangePasswordButton_Click(object sender, RoutedEventArgs e)
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
                () =>
                {
                    Frame.Navigate(typeof(ChangePassword));
                });
        }
    }
}
