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

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace Project_try
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class test_b : Page
    {
        String[] ABCDcontent = { "没有或很少时间", "小部分时间", "相当多时间", "绝大部分时间" };

        String[] questionArray = { "1.我觉得闷闷不乐，情绪低沉；",
                                   "2.我觉得一天之中早晨最好；",
                                   "3.我一阵阵哭出来或觉得想哭；",
                                 "4.我晚上睡眠不好；",
                                 "5.我吃得跟平常一样多；",
                                 "6.我与异性亲密接触时和以往一样感到愉快； ",
                                 "7.我发觉我的体重在下降；",
                                 "8.我有便秘的苦恼；",
                                 "9.心跳比平常快；",
                                 "10.我无缘无故地感到疲乏；",
								 "11.我的头脑和平常一样清楚；",
                                 "12.我觉得经常做的事情并没有困难；",
                                 "13.我觉得不安而平静不下来； ",
                                 "14.我对未来抱有希望；",
                                 "15.我比平常容易生气激动；",
                                 "16.我觉得做出决定是容易的； ",
                                 "17.我觉得自己是个有用的人，有人需要我；",
                                 "18.我的生活过得很有意思；  ",
                                 "19.我认为如果我死了，别人会生活得更好；",
                                 "20.平常感兴趣的事我仍然感兴趣。 "};
     
      
        //List <bool> chooseList = new List<bool>();

        public int question_index;
        public test_b()
        {
            this.InitializeComponent();

            Init_UI();
        }

        public void Init_UI()
        {
            A.Content = ABCDcontent[0];
            B.Content = ABCDcontent[1];
            C.Content = ABCDcontent[2];
            D.Content = ABCDcontent[3];
            question_index = 0;
            question.Text = questionArray[question_index];
        }

        public void Update_UI()
        {
            if (question_index < 20)
            {
                question.Text = questionArray[question_index];
                //RYes.IsChecked = false;
                //RNo.IsChecked = false;
                A.IsChecked = false;
                B.IsChecked = false;
                C.IsChecked = false;
                D.IsChecked = false;
            }
            else
            {
                Result(1);
            }
        }

        private void A_Checked(object sender, RoutedEventArgs e)
        {
            question_index++;
            score += 4;
            Update_UI();
        }

        //
        //导航至结果页面 PopUp
        //
        private int score = 0;
        public void Result(int i)
        {
            chara_gene.Text = "得分为："+score;
            life_route.Text ="评价："+"要继续努力！";

            this.result_popup.IsOpen = true;
        }

        private void B_Checked(object sender, RoutedEventArgs e)
        {
            score += 3;
            question_index++;
            Update_UI();
        }
        private void C_Checked(object sender, RoutedEventArgs e)
        {
            score += 2;
            question_index++;
            Update_UI();
        }
        private void D_Checked(object sender, RoutedEventArgs e)
        {
            score += 1;
            question_index++;
            Update_UI();
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (Frame != null && Frame.CanGoBack) Frame.GoBack();
        }
    }
}
