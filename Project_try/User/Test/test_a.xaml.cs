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
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace Project_try
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class test_a : Page
    {
        List<Problem> problem_list;
        long paper_id_current=-1;
        int score = 0;
        int questionNumber = 10;
        String[] ABCDcontent = { "非常同意", "同意", "不同意", "非常不同意" };
        int[] isOppsiteScore={3,5,8,9,10};
		bool oppsiteSocreOrder(int x){
			for(int i=0;i<isOppsiteScore.Length;i++){
                if (x==isOppsiteScore[i])
                    return true;
            }
           return false;
		}

        String[] questionArray = { "1.我认为自己是个有价值的人，至少与别人不相上下。",
                                   "2.我觉得我有许多优点。",
                                   "3.总的来说，我倾向于认为自己是一个失败者。",
                                 "4.我做事可以做得和大多数人一样好。",
                                 "5.我觉得自己没有什么值得自豪的地方。",
                                 "6.我对自己持有一种肯定的态度。",
                                 "7.整体而言，我对自己觉得很满意。",
                                 "8.我要是能更看得起自己就好了。",
                                 "9.有时我的确感到自己很没用。",
                                 "10.有时我觉得自己一无是处。"};
 

        public int question_index=0;
        public test_a()
        {
            this.InitializeComponent();

            
        }

         async public void Init_UI()
        {
            
            //new HttpClient().PostAsync();

            if (null != problem_list)
            {
                return;
            }
            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("paper_id", "" + paper_id_current);
            /*
              
           var jsonWriter = new JsonTextWriter(new StringWriter());
           jsonWriter.StringEscapeHandling = StringEscapeHandling.EscapeHtml;
           new JsonSerializer().Serialize(jsonWriter, d);
             */
            //string req_body  = jsonWriter.ToString();
             var x = new JsonSerializerSettings();
             x.StringEscapeHandling = StringEscapeHandling.EscapeHtml;
            string req_body = JsonConvert.SerializeObject(d,   x);
            HttpResponseMessage resp = await new HttpClient().PostAsync(
                Config.service_url + "/PaperService/selectProblemListByPaperId",
                new StringContent(req_body));
            resp.EnsureSuccessStatusCode();
            string resp_body = await resp.Content.ReadAsStringAsync();
            List<Problem> problem_list0 = JsonConvert.DeserializeObject<List<Problem>>(resp_body);
            problem_list = problem_list0;

            A.Content = problem_list[question_index].option1;
            B.Content = problem_list[question_index].option2;
            C.Content = problem_list[question_index].option3;
            D.Content = problem_list[question_index].option4;
            question.Text = problem_list[question_index].title;
        }

        public void Update_UI()
        {
            if (question_index < problem_list.Count)
            {

                A.Content = problem_list[question_index].option1;
                B.Content = problem_list[question_index].option2;
                C.Content = problem_list[question_index].option3;
                D.Content = problem_list[question_index].option4;
                question.Text = problem_list[question_index].title;

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
            if (oppsiteSocreOrder(question_index)) { score += 1; }
            else { score += 4; }
            question_index++;
            
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
            if (oppsiteSocreOrder(question_index)) { score += 2; }
            else { score += 3; }
            question_index++;
            Update_UI();
        }
        private void C_Checked(object sender, RoutedEventArgs e)
        {
            if (oppsiteSocreOrder(question_index)) { score += 3; }
            else { score += 2; }
            question_index++;
            Update_UI();
        }
        private void D_Checked(object sender, RoutedEventArgs e)
        {
            if (oppsiteSocreOrder(question_index)) { score +=4; }
            else { score += 1; }
            question_index++;
            Update_UI();
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (Frame != null && Frame.CanGoBack) Frame.GoBack();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            this.paper_id_current = (long)e.Parameter;
            Init_UI();
        }
    }
}
