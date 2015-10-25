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

using Windows.UI.Popups;

using System.Collections.ObjectModel;


// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍


//
//主页面，登陆界面。
//

namespace Project_try
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class Login : Page
    {
        public Login()
        {
            this.InitializeComponent();
        }

        private async void LogIn_Click(object sender, RoutedEventArgs e)
        {
            //PopMsgNull();

            
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
                () =>
                {
                    
                    userName.BorderBrush = new SolidColorBrush(Colors.White);
                    passWord.BorderBrush = new SolidColorBrush(Colors.White);
                    Msg.Text = "";
                    Msg2.Text = "";
                    Frame.Navigate(typeof(Self_test));
                    //用户名
                    if (userName.Text == "")
                    {
                        Msg.Text = "用户名不能为空";
                        userName.BorderBrush = new SolidColorBrush(Colors.Red);
                    }
                    else
                    {

                        MemberInfo data = new MemberInfo();
                        data.Create();
                        data = data.Select(userName.Text);
                        if (data == null)
                        {
                            Msg.Text = "用户不存在"; 
                            userName.BorderBrush = new SolidColorBrush(Colors.Red);
                        }
                        else
                        {
                            data.Export();
                            
                            if (passWord.Password == User.Password)
                                Frame.Navigate(typeof(Self_test));
                            else  
                            {
                                passWord.BorderBrush = new SolidColorBrush(Colors.Red);
                                Msg2.Text = "密码不正确";
                            }
                        }
                        
                    }

                });
        }

        private async void Register_Click(object sender, RoutedEventArgs e)
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
               () =>
               {
                   Frame.Navigate(typeof(Register));

               });
        }

        private void PasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        //
        //PasswordChanged 方法可以实时监控用户输入的密码
        //
      /*  private async void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {

            PasswordBox pb = (PasswordBox) sender;

            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
                () =>
                {
                    welcome.Text = pb.Password;
                }
                    );
        }*/

        public async void PopMsgNull()
        {

            
            MemberInfo a=new MemberInfo();
            ObservableCollection<MemberInfo> list = a.SelectAll();
            a = list[0];
            
            MessageDialog msg = new MessageDialog(a.userName);
            

            msg.Commands.Add(new UICommand("确定"));
            await msg.ShowAsync();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            if (Frame != null && Frame.CanGoBack) Frame.GoBack();
        }
    }
}
