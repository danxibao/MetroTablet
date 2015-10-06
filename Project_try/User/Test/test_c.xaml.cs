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
    public sealed partial class test_c : Page
    {
        int score = 0;

        String[] ABCDcontent = { "没有或偶尔", "有时", "经常", "总是如" };
        String[] questionArray= { "1．我觉得比平时容易紧张和着急（焦虑）",
                                   "2. 我无缘无故地感到害怕（害怕）",
                                   "3．我容易心里烦乱或觉得惊恐（惊恐）",
                                 "4．我觉得我可能将要发疯 （发疯感）",
                                 "5．我觉得一切都很好，也不会发生什么不幸（不幸预感）",
                                 "6．我手脚发抖打颤（手足颤抖） ",
                                 "7．我因为头痛、颈痛和背痛而苦恼（躯体疼痛） ",
                                 "8．我感觉容易衰弱和疲乏 （乏力）",
                                 "9．我觉得心平气和，并且容易安静坐着 （静坐不能）",
                                 "10．我觉得心跳得快（心悸）",
								 "11．我因为一阵阵头晕而苦恼（头昏）",
                                 "12．我有过晕倒发作，或觉得要晕倒似的（晕厥感）",
                                 "13．我呼气吸气都感到很容易（呼吸困难）  ",
                                 "14．我手脚麻木和刺痛（手足刺痛）",
                                 "15．我因胃痛和消化不良而苦恼（胃痛或消化不良）",
                                 "16．我常常要小便（尿意频数） ",
                                 "17．我的手常常是干燥温暖的（多汗）",
                                 "18．我脸红发热 （面部潮红)",
                                 "19．我容易入睡并且一夜睡得很好（睡眠障碍）",
                                 "20．我做恶梦（恶梦） "};
   


        //List <bool> chooseList = new List<bool>();

        public int question_index;
        public test_c()
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
