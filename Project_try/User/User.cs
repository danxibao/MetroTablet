using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using SQLite;
using System.Collections.ObjectModel;

namespace Project_try
{
    public static class User
    {
        public static int num;
        public static string userName;
        public static string Name;
        public static bool Sex;//true为男，false为女
        public static int Age;
        public static string Rank;
        public static string Unit;
        public static string ID;
        public static string Password;

    }

    //创建数据库
    //声明一个MemberInfo类也就是表主键自动增长
    public class MemberInfo
    {
        [SQLite.AutoIncrement, SQLite.PrimaryKey]
        public int num { set; get; }
        public string userName { set; get; }
        public string Name { set; get; }
        public bool Sex{ set; get; }
        public int Age { set; get; }
        public string Rank { set; get; }
        public string Unit { set; get; }
        public string ID { set; get; }
        public string Password { set; get; }

        public void Build()//num数据库主键值未设定，自动增长
        {
            userName = User.userName;
            Name = User.Name;
            Sex = User.Sex;
            Age = User.Age;
            Rank = User.Rank;
            Unit = User.Unit;
            ID = User.ID;
            Password = User.Password;
        }
        public void Build(int temp)
        {
            num = temp;
            userName = User.userName;
            Name = User.Name;
            Sex = User.Sex;
            Age = User.Age;
            Rank = User.Rank;
            Unit = User.Unit;
            ID = User.ID;
            Password = User.Password;
        }
        public void Export()
        {
            User.num = num;
            User.userName = userName;
            User.Name = Name;
            User.Sex = Sex;
            User.Age = Age;
            User.Rank = Rank;
            User.Unit = Unit;
            User.ID = ID;
            User.Password = Password;
        }

        string path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "Member.sqlite");    //数据文件保存的位置  


        //写一个方法用于创建数据库Member.sqlite和表MemberInfo

        public void Create()
        {
              
            using (var db = new SQLiteConnection(path))  //打开创建数据库和表
            {
                db.CreateTable<MemberInfo>();
            }
        }
       
        //简单的操作sqlite数据库（增，删，改，查询）
        public void Insert()
        {
            try
            {
                using (var db = new SQLiteConnection(path))
                {
                    db.Insert(this);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void Insert(MemberInfo data)
        {
            try
            {
                using (var db = new SQLiteConnection(path))
                {
                    db.Insert(data);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void Delete(int num)
        {
            try
            {
                MemberInfo data = Select(num);
                using (var db = new SQLiteConnection(path))
                {
                    db.Delete(data);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public MemberInfo Select(int num)
        {
            try
            {
                MemberInfo data = null;
                using (var db = new SQLiteConnection(path))
                {
                    List<object> obj = db.Query(new TableMapping(typeof(MemberInfo)), string.Format("Select * from MemberInfo where num={0}",num));
                    if (obj != null && obj.Count > 0)
                    {
                        data = obj[0] as MemberInfo;
                    }
                }
                return data;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public MemberInfo Select(string userName)
        {
            try
            {
                MemberInfo data = null;
                using (var db = new SQLiteConnection(path))
                {
                    List<object> obj = db.Query(new TableMapping(typeof(MemberInfo)), "Select * from MemberInfo where userName="+"'"+userName+"'");
                    if (obj != null && obj.Count > 0)
                    {
                        data = obj[0] as MemberInfo;
                    }
                }
                return data;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Updata()
        {
            try
            {
                using (var db = new SQLiteConnection(path))
                {
                    db.Update(this);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void Updata(MemberInfo data)
        {
            try
            {
                using (var db = new SQLiteConnection(path))
                {
                    db.Update(data);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public ObservableCollection<MemberInfo> SelectAll()
        {
   　　　　ObservableCollection<MemberInfo> list = new ObservableCollection<MemberInfo>();
  　　　　using (var db =new SQLiteConnection(path))
            {
   　　　　　　List<object> query = db.Query(new TableMapping(typeof(MemberInfo)), "select * from MemberInfo");
　　　　　　   foreach (var mem in query)
                   {
   　　　　　　　　　　MemberInfo info = mem as MemberInfo;
                    　　　　list.Add(info);
                 }
            }
　　　　return list;   
        }

    }

    


}
