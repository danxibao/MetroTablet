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
        private int indexOfItemClick = 1;
        public void list_set()
        {
            test_list.Width = Window.Current.Bounds.Width*0.6;
            test_list.Height = Window.Current.Bounds.Height * 0.6;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.New || e.NavigationMode == NavigationMode.Back)
            {
                List<string> myList = new List<string>();
                myList.Add("①罗森伯格的自尊量表（SES）");
                myList.Add("②抑郁自评量表 (SDS)");
                myList.Add("③焦虑自评量表(SAS)");
                myList.Add("④压力测试");
                myList.Add("⑤孤独量表测验（UCLA）");
                test_list.ItemsSource = myList;

            }
        }

        private void item_Click(object sender, ItemClickEventArgs e)
        {
            /*
            MessageDialog msg = new MessageDialog(e.ClickedItem.ToString());
            msg.ShowAsync();*/

            String s = e.ClickedItem.ToString();
            if (s.Equals("①罗森伯格的自尊量表（SES）"))
            {
                indexOfItemClick = 1;
                this.pop_up_a.IsOpen = true;
                title_a.Text = s;
                content_a.Text = "自尊量表(self-esteem scale，SES)由5个正向计分和5个反向计分的条目组成。受试者直接报告这些描述是否符合他们自己。";
            }
            if (s.Equals("②抑郁自评量表 (SDS)"))
            {
                indexOfItemClick = 2;
                this.pop_up_a.IsOpen = true;
                title_a.Text = s;
                content_a.Text = "填表注意事项：下面有二十条文字，请根据你最近一星期的实际情况，在适当的方格里划，每一条文字后有四个格，表示：A没有或很少时间；B小部分时间；C相当多时间；D绝大部分或全部时间。";
            }
            if (s.Equals("③焦虑自评量表(SAS)"))
            {
                indexOfItemClick = 3;
                this.pop_up_a.IsOpen = true;
                title_a.Text = s;
                content_a.Text = "下面有二十条文字（括号中为症状名称），请仔细阅读每一条,把意思弄明白，每一条文字后有四级评分,表示:A没有或偶尔；B有时；C经常；D总是如此。然后根据您最近一星期的实际情况，在分数栏1～4分适当的分数下选择";
            }
            if (s.Equals("④压力测试"))
            {
                indexOfItemClick = 4;
                this.pop_up_a.IsOpen = true;
                title_a.Text = s;
                content_a.Text = "4：下面是压力测试题，请按照真实情况回答";
            }
            if (s.Equals("⑤孤独量表测验（UCLA）"))
            {
                indexOfItemClick = 5;
                this.pop_up_a.IsOpen = true;
                title_a.Text = s;
                content_a.Text = "下列是人们有时出现的一些感受。对每项描述，请你选择你具有该种感受的频度，点击相应的选项。举例如下：\n你常感觉幸福吗？"
    +"\n如你从未感到幸福，你应回答“从不”；\n如一直感到幸福，应回答“一直”";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(indexOfItemClick==1)
                Frame.Navigate(typeof(test_a));
            if (indexOfItemClick == 2)
                Frame.Navigate(typeof(test_b));
            if (indexOfItemClick == 3)
                Frame.Navigate(typeof(test_c));
            if (indexOfItemClick == 4)
                Frame.Navigate(typeof(test_d));
            if (indexOfItemClick == 5)
                Frame.Navigate(typeof(test_e));
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
