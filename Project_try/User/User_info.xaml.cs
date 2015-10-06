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
    public sealed partial class User_info : Page
    {
        public User_info()
        {
            this.InitializeComponent();
            Load_User_info();
        }

        private void Load_User_info()
        {
            userName.Text = User.userName;
            Name.Text = User.Name;

            if (User.Sex) Sex.Text = "男";
            else Sex.Text = "女";

            Age.Text = User.Age.ToString();
            Rank.Text = User.Rank;
            Unit.Text = User.Unit;
            ID.Text = User.ID;
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            bool Register_OK = true;

            //用户名
            userName.BorderBrush = new SolidColorBrush(Colors.White);
            userNameMsg.Text = "";
            if (string.IsNullOrWhiteSpace(userName.Text))
            {
                userName.BorderBrush = new SolidColorBrush(Colors.Red);
                userNameMsg.Text = "用户名不能为空";
                Register_OK = false;
            }
            else
            {
                MemberInfo temp = new MemberInfo();
                temp = temp.Select(userName.Text);
                if (temp == null)
                {
                    User.userName = userName.Text;
                }
                else if(temp.num==User.num)
                {
                    User.userName = userName.Text;
                }
                else
                {
                    userName.BorderBrush = new SolidColorBrush(Colors.Red);
                    userNameMsg.Text = "用户已存在";
                    Register_OK = false;
                }
            }


            //姓名
            Name.BorderBrush = new SolidColorBrush(Colors.White);
            if (!string.IsNullOrWhiteSpace(Name.Text))
            {
                User.Name = Name.Text;

            }
            else
            {
                Name.BorderBrush = new SolidColorBrush(Colors.Red);
                Register_OK = false;
            }

            //性别
            Sex.BorderBrush = new SolidColorBrush(Colors.White);
            if (Sex.Text == "男")
            {
                User.Sex = true;
            }
            else if (Sex.Text == "女")
            {
                User.Sex = false;
            }
            else
            {
                Sex.BorderBrush = new SolidColorBrush(Colors.Red);
                Register_OK = false;
            }

            //年龄
            Age.BorderBrush = new SolidColorBrush(Colors.White);
            if (int.TryParse(Age.Text, out User.Age) && User.Age > 0)
            {
            }
            else
            {
                Age.BorderBrush = new SolidColorBrush(Colors.Red);
                Register_OK = false;
            }


            //职级
            Rank.BorderBrush = new SolidColorBrush(Colors.White);
            if (!string.IsNullOrWhiteSpace(Rank.Text))
            {
                User.Rank = Rank.Text;
            }
            else
            {
                Rank.BorderBrush = new SolidColorBrush(Colors.Red);
                Register_OK = false;
            }

            //单位
            Unit.BorderBrush = new SolidColorBrush(Colors.White);
            if (!string.IsNullOrWhiteSpace(Unit.Text))
            {
                User.Unit = Unit.Text;
            }
            else
            {
                Unit.BorderBrush = new SolidColorBrush(Colors.Red);
                Register_OK = false;
            }

            //证件号
            ID.BorderBrush = new SolidColorBrush(Colors.White);
            if (!string.IsNullOrWhiteSpace(ID.Text) && ID.Text.Length == 7)
            {
                User.ID = ID.Text;

            }
            else
            {
                ID.BorderBrush = new SolidColorBrush(Colors.Red);
                Register_OK = false;
            }

            //密码
            passWord.BorderBrush = new SolidColorBrush(Colors.White);
            if (string.IsNullOrWhiteSpace(passWord.Password))
            {
                passWord.BorderBrush = new SolidColorBrush(Colors.Red);
                Register_OK = false;
            }
            else if (passWord.Password == User.Password)
            {

            }
            else
            {
                passWord.BorderBrush = new SolidColorBrush(Colors.Red);
                Register_OK = false;
            }


            if (Register_OK)
            {
                MemberInfo data = new MemberInfo();
                data.Build(User.num);
                data.Updata();
                if (Frame != null && Frame.CanGoBack) Frame.GoBack();
            }


        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            if (Frame != null && Frame.CanGoBack) Frame.GoBack();
        }
    }
}
