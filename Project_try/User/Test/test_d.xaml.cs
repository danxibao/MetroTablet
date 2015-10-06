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
    public sealed partial class test_d : Page
    {
        int score = 0;
        int questionNumber = 40;
        String[] ABCDcontent = { "是", "否", "两者之间", "不想回答" };

        
      
        String[] questionArray = { "1.曾感到眼前一片黑暗，突然看不清楚。",
                                 "2.常常感到肩、颈部酸痛。",
                                 "3.曾有心悸现象。",
                                 "4.一爬楼梯就气喘不已。",
                                 "5.即使是在夏天，手脚依然冰凉。",
                                 "6.食欲不佳，吃什么都觉得不合胃口。",
                                 "7.饭后感到心窝处疼痛，且有想呕吐现象。",
                                 "8.精神一紧张，就易拉肚子。",
                                 "9.经常便秘。",
                                 "10.皮肤粗糙。",
                                 "11.每晚不易入睡，常失眠。",
                                 "12.经常感到头重，且有严重头疼。",
                                 "13.身体会突然发烫或怕冷。",
                                 "14.坐在拥挤的公共汽车上，常出现眩晕。",
                                 "15.身体有某种过敏症状。",
                                 "16.身体常感到发麻和疼痛。",
                                 "17.每逢月经时痛得要请病假。",
                                 "18.曾患过膀胱炎。",
                                 "19.手脚或全身感到松软无力。",
                                 "20.工作时容易疲劳，以致工作效率不高。",
                                 "21.上司在旁盯看，就无法自在地做好事情。",
                                 "22.很怕在众人面前讲话。",
                                 "23.必须立刻办妥的事，一急就忙得不知所措。",
                                 "24.常常歪曲他人的话。",
                                 "25.每当要做出选择时，常常无法做出决定。",
                                 "26.给人的印象是迟钝，不够灵活。",
                                 "27.即使和大伙在一起，仍觉得很孤独。",
                                 "28.容易计较小事，常常弄得心情郁闷。",
                                 "29.常把事情往坏处想。",
                                 "30.容易因小事生气。",
                                 "31.非常在乎他人对自己的评价。",
                                 "32.置身于陌生的人群中，就会紧张害怕。",
                                 "33.常常焦虑不安。",
                                 "34.精神常处于紧张状态。",
                                 "35.没什么朋友。",
                                 "36.不易感动，感情变得冷漠。",
                                 "37.早上不易起床。",
                                 "38.常被人误解。",
                                 "39.无故地陷入不安。",
								 "40.常常感到自己“很差劲”，甚至会自我厌恶。"};
        
        

        public int question_index;
        public test_d()
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
            if (question_index < questionNumber)
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
