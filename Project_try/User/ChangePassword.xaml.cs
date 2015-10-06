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

namespace Project_try
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ChangePassword : Page
    {
        public ChangePassword()
        {
            this.InitializeComponent();
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            passWord.BorderBrush = new SolidColorBrush(Colors.White);
            passWordChange.BorderBrush = new SolidColorBrush(Colors.White);
            passWordConfirm.BorderBrush = new SolidColorBrush(Colors.White);
            if(passWord.Password=="")
            {
                passWord.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            else if (passWord.Password == User.Password)
            {
                if (passWordChange.Password == "")
                {
                    passWordChange.BorderBrush = new SolidColorBrush(Colors.Red);
                }
                else
                {
                    if(passWordChange.Password == passWordConfirm.Password)
                    {
                        User.Password = passWordChange.Password;
                        MemberInfo data = new MemberInfo();
                        data.Build(User.num);
                        data.Updata();
                        if (Frame != null && Frame.CanGoBack) Frame.GoBack();
                    }
                    else
                        passWordConfirm.BorderBrush = new SolidColorBrush(Colors.Red);
                }
            }
            else
            {
                passWord.BorderBrush = new SolidColorBrush(Colors.Red);
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            if (Frame != null && Frame.CanGoBack) Frame.GoBack();
        }
    }
}
