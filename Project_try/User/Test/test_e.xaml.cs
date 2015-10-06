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
    public sealed partial class test_e : Page
    {
        int score = 0;
        int questionNumber = 20;
        String[] ABCDcontent = { "从不", "很少", "有时", "一直" };

   
        String[] questionArray = { "1、你常感到与周围人的关系和谐吗？",
                                   "2、你常感到缺少伙伴吗？",
                                   "3、你常感到没人可以信赖吗？",
                                 "4、你常感到寂寞吗？",
                                 "5、你常感到属于朋友们中的一员吗？",
                                 "6、你常感到与周围的人有许多共同点吗？ ",
                                 "7、你常感到与任何人都不亲密了吗?",
                                 "8、你常感到你的兴趣与想法与周围的人不一样吗？",
                                 "9、你常感到想要与人来往、结交朋友吗？",
                                 "10、你常感到与人亲近吗？",
								 "11、你常感到被人冷落吗？",
                                 "12、你常感到你与别人来往毫无意义吗？",
                                 "13、你常感到没有人很了解你吗？",
                                 "14、你常感到与别人隔开了吗？",
                                 "15、你常感到当你愿意时就能找到伙伴吗？",
                                 "16、你常感到有人真正了解你吗？",
                                 "17、你常感到羞怯吗？",
                                 "18、你常感到有人围着你但并不关心你吗？",
                                 "19、你常感到有人愿意与你交谈吗？",
                                 "20、你常感到有人值得你信赖吗？"};
        

        //List <bool> chooseList = new List<bool>();

        public int question_index;
        public test_e()
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
