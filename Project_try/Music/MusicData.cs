using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_try.Music
{
    using System;
    using Windows.UI.Xaml.Data;
    using Windows.UI.Xaml.Media;
    using Windows.UI.Xaml.Media.Imaging;
    using Windows.Storage;


    #if DISABLE_SAMPLE_DATA
	internal class SampleDataSource { }
#else

    public class MediaItem : System.ComponentModel.INotifyPropertyChanged
    {
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }

        private string _Title = string.Empty;
        public string Title
        {
            get
            {
                return this._Title;
            }

            set
            {
                if (this._Title != value)
                {
                    this._Title = value;
                    this.OnPropertyChanged("Title");
                }
            }
        }

        private string _Subtitle = string.Empty;
        public string Subtitle
        {
            get
            {
                return this._Subtitle;
            }

            set
            {
                if (this._Subtitle != value)
                {
                    this._Subtitle = value;
                    this.OnPropertyChanged("Subtitle");
                }
            }
        }

        private ImageSource _Image = null;
        public ImageSource Image
        {
            get
            {
                return this._Image;
            }

            set
            {
                if (this._Image != value)
                {
                    this._Image = value;
                    this.OnPropertyChanged("Image");
                }
            }
        }

        public void SetImage(Uri baseUri, String path)
        {
            Image = new BitmapImage(new Uri(baseUri, path));
        }

        private Uri _MP4Source = null;
        public Uri MP4Source
        {
            get
            {
                return this._MP4Source;
            }

            set
            {
                if (this._MP4Source != value)
                {
                    this._MP4Source = value;
                    this.OnPropertyChanged("MP4Source");
                }
            }
        }

        private Uri _Source = null;
        public Uri Source
        {
            get
            {
                return this._Source;
            }

            set
            {
                if (this._Source != value)
                {
                    this._Source = value;
                    this.OnPropertyChanged("Source");
                }
            }
        }
    }
        public class HypnosisMusicData
        {
            Uri _baseUriPic = new Uri("ms-appx:///Assets/Music/Hypnosis/");
            Uri _baseUriContent = new Uri("ms-appx:///Assets/Music/Hypnosis/");
            public HypnosisMusicData()
        {
            MediaItem item = null;

            item = new MediaItem();
            item.Title = "海浪之梦";
            item.Subtitle = "";
            item.SetImage(_baseUriPic, "01.gif");
            item.MP4Source = new Uri(_baseUriContent, "01.mp4");
            item.Source=new Uri(_baseUriContent,"01海浪之梦.mp3");
            Collection.Add(item);

            item = new MediaItem();
            item.Title = "草原之梦";
            item.Subtitle = "";
            item.SetImage(_baseUriPic, "02.gif");
            item.MP4Source = new Uri(_baseUriContent, "02.mp4");
            item.Source = new Uri(_baseUriContent, "02草原之梦.mp3");
            Collection.Add(item);

            item = new MediaItem();
            item.Title = "鸟语之梦";
            item.Subtitle = "";
            item.SetImage(_baseUriPic, "03.gif");
            item.MP4Source = new Uri(_baseUriContent, "03.mp4");
            item.Source = new Uri(_baseUriContent, "03鸟语之梦.mp3");
            Collection.Add(item);

            item = new MediaItem();
            item.Title = "月夜之梦";
            item.Subtitle = "";
            item.SetImage(_baseUriPic, "04.gif");
            item.MP4Source = new Uri(_baseUriContent, "04.mp4");
            item.Source = new Uri(_baseUriContent, "04月夜之梦.mp3");
            Collection.Add(item);
            }

            private MediaItemCollection _Collection = new MediaItemCollection();

            public MediaItemCollection Collection
            {
                get
                {
                    return this._Collection;
                }
            }
        }

        public class DestressMusicData
        {
            Uri _baseUriPic = new Uri("ms-appx:///Assets/Music/Destress/");
            Uri _baseUriContent = new Uri("ms-appx:///Assets/Music/Destress/");
            public DestressMusicData()
            {
                MediaItem item = null;

                item = new MediaItem();
                item.Title = "平静制怒";
                item.Subtitle = "1";
                item.SetImage(_baseUriPic, "01.gif");
                item.MP4Source = new Uri(_baseUriContent, "01.mp4");
                item.Source = new Uri(_baseUriContent, "A.平静制怒1.mp3");
                Collection.Add(item);

                item = new MediaItem();
                item.Title = "平静制怒";
                item.Subtitle = "2";
                item.SetImage(_baseUriPic, "01.gif");
                item.MP4Source = new Uri(_baseUriContent, "01.mp4");
                item.Source = new Uri(_baseUriContent, "A.平静制怒2.mp3");
                Collection.Add(item);

                item = new MediaItem();
                item.Title = "自我放松";
                item.Subtitle = "";
                item.SetImage(_baseUriPic, "02.gif");
                item.MP4Source = new Uri(_baseUriContent, "02.mp4");
                item.Source = new Uri(_baseUriContent, "02.自我放松术(有指导语）.mp3");
                Collection.Add(item);

                item = new MediaItem();
                item.Title = "山水情";
                item.Subtitle = "1";
                item.SetImage(_baseUriPic, "03.gif");
                item.MP4Source = new Uri(_baseUriContent, "03.mp4");
                item.Source = new Uri(_baseUriContent, "11.mp3");
                Collection.Add(item);

                item = new MediaItem();
                item.Title = "山水情";
                item.Subtitle = "2";
                item.SetImage(_baseUriPic, "03.gif");
                item.MP4Source = new Uri(_baseUriContent, "03.mp4");
                item.Source = new Uri(_baseUriContent, "12.mp3");
                Collection.Add(item);

                item = new MediaItem();
                item.Title = "羽毛孔雀月色-恬然入梦";
                item.Subtitle = "";
                item.SetImage(_baseUriPic, "04.png");
                item.Source = new Uri(_baseUriContent, "04.羽毛孔雀月色-恬然入梦（曲）.avi");
                Collection.Add(item);

                item = new MediaItem();
                item.Title = "唯美夜晚月亮-随想";
                item.Subtitle = "";
                item.SetImage(_baseUriPic, "05.png");
                item.Source = new Uri(_baseUriContent, "05. 唯美夜晚月亮-随想.avi");
                Collection.Add(item);
            }

            private MediaItemCollection _Collection = new MediaItemCollection();

            public MediaItemCollection Collection
            {
                get
                {
                    return this._Collection;
                }
            }
        }

        public class AdmirationData
        {
            Uri _baseUriPic = new Uri("ms-appx:///Assets/Music/Admiration/Pic/");
            Uri _baseUriContent = new Uri("ms-appx:///Assets/Music/Admiration/Music/");
            public AdmirationData()
            {
                MediaItem item = null;

                item = new MediaItem();
                item.Title = "我爱祖国的蓝天";
                item.Subtitle = "";
                item.SetImage(_baseUriPic, "1.jpg");
                item.Source = new Uri(_baseUriContent, "1我爱祖国的蓝天.mp3");
                Collection.Add(item);


                item = new MediaItem();
                item.Title = "军港之夜";
                item.Subtitle = "";
                item.SetImage(_baseUriPic, "2.jpg");
                item.Source = new Uri(_baseUriContent, "2军港之夜.mp3");
                Collection.Add(item);

                item = new MediaItem();
                item.Title = "忠诚卫士歌";
                item.Subtitle = "";
                item.SetImage(_baseUriPic, "3.jpg");
                item.Source = new Uri(_baseUriContent, "3忠诚卫士歌.mp3");
                Collection.Add(item);

                item = new MediaItem();
                item.Title = "爱在远方";
                item.Subtitle = "";
                item.SetImage(_baseUriPic, "4.jpg");
                item.Source = new Uri(_baseUriContent, "4爱在远方.mp3");
                Collection.Add(item);

                item = new MediaItem();
                item.Title = "飞翔的刺刀";
                item.Subtitle = "";
                item.SetImage(_baseUriPic, "5.jpg");
                item.Source = new Uri(_baseUriContent, "5飞翔的刺刀.mp3");
                Collection.Add(item);

                item = new MediaItem();
                item.Title = "中国人民解放军军歌";
                item.Subtitle = "";
                item.SetImage(_baseUriPic, "6.jpg");
                item.Source = new Uri(_baseUriContent, "6中国人民解放军军歌.mp3");
                Collection.Add(item);

                item = new MediaItem();
                item.Title = "当那一天来临";
                item.Subtitle = "";
                item.SetImage(_baseUriPic, "7.jpg");
                item.Source = new Uri(_baseUriContent, "7当那一天来临.mp3");
                Collection.Add(item);

                item = new MediaItem();
                item.Title = "爱国奉献歌";
                item.Subtitle = "";
                item.SetImage(_baseUriPic, "8.jpg");
                item.Source = new Uri(_baseUriContent, "8爱国奉献歌.mp3");
                Collection.Add(item);

                item = new MediaItem();
                item.Title = "军中绿花";
                item.Subtitle = "";
                item.SetImage(_baseUriPic, "9.png");
                item.Source = new Uri(_baseUriContent, "9军中绿花.mp3");
                Collection.Add(item);

                item = new MediaItem();
                item.Title = "绿军装的梦";
                item.Subtitle = "";
                item.SetImage(_baseUriPic, "10.jpg");
                item.Source = new Uri(_baseUriContent, "10绿军装的梦.mp3");
                Collection.Add(item);

                item = new MediaItem();
                item.Title = "说句心里话";
                item.Subtitle = "";
                item.SetImage(_baseUriPic, "11.jpg");
                item.Source = new Uri(_baseUriContent, "11说句心里话.mp3");
                Collection.Add(item);

                item = new MediaItem();
                item.Title = "当你的秀发拂过我的钢枪";
                item.Subtitle = "";
                item.SetImage(_baseUriPic, "12.jpg");
                item.Source = new Uri(_baseUriContent, "12当你的秀发拂过我的钢枪.mp3");
                Collection.Add(item);

                item = new MediaItem();
                item.Title = "好姑娘等着我";
                item.Subtitle = "";
                item.SetImage(_baseUriPic, "13.jpg");
                item.Source = new Uri(_baseUriContent, "13好姑娘等着我.mp3");
                Collection.Add(item);

                item = new MediaItem();
                item.Title = "女兵谣";
                item.Subtitle = "";
                item.SetImage(_baseUriPic, "14.jpg");
                item.Source = new Uri(_baseUriContent, "14女兵谣.mp3");
                Collection.Add(item);

                item = new MediaItem();
                item.Title = "男子汉去飞行";
                item.Subtitle = "";
                item.SetImage(_baseUriPic, "15.jpg");
                item.Source = new Uri(_baseUriContent, "15男子汉去飞行.mp3");
                Collection.Add(item);

                item = new MediaItem();
                item.Title = "战友还记得么";
                item.Subtitle = "";
                item.SetImage(_baseUriPic, "16.jpg");
                item.Source = new Uri(_baseUriContent, "16战友还记得么.mp3");
                Collection.Add(item);

                item = new MediaItem();
                item.Title = "我若牺牲在沙场";
                item.Subtitle = "";
                item.SetImage(_baseUriPic, "17.jpg");
                item.Source = new Uri(_baseUriContent, "17我若牺牲在沙场.mp3");
                Collection.Add(item);

                item = new MediaItem();
                item.Title = "新兵日记";
                item.Subtitle = "";
                item.SetImage(_baseUriPic, "18.jpg");
                item.Source = new Uri(_baseUriContent, "18新兵日记.mp3");
                Collection.Add(item);

                item = new MediaItem();
                item.Title = "好男儿就是要当兵";
                item.Subtitle = "";
                item.SetImage(_baseUriPic, "19.png");
                item.Source = new Uri(_baseUriContent, "19好男儿就是要当兵.mp3");
                Collection.Add(item);

                item = new MediaItem();
                item.Title = "从汶川回来的排长";
                item.Subtitle = "";
                item.SetImage(_baseUriPic, "20.jpg");
                item.Source = new Uri(_baseUriContent, "20从汶川回来的排长.mp3");
                Collection.Add(item);

                item = new MediaItem();
                item.Title = "激情燃烧的岁月";
                item.Subtitle = "avi";
                item.SetImage(_baseUriPic, "MovieLogo.png");
                item.Source = new Uri(_baseUriContent, "21激情燃烧的岁月.avi");
                Collection.Add(item);
            }

            private MediaItemCollection _Collection = new MediaItemCollection();

            public MediaItemCollection Collection
            {
                get
                {
                    return this._Collection;
                }
            }
        }
        public class SingAloudData
        {
            Uri _baseUriPic = new Uri("ms-appx:///Assets/Music/SingAloud/");
            Uri _baseUriContent = new Uri("ms-appx:///Assets/Music/SingAloud/");
            public SingAloudData()
            {
                MediaItem item = null;

                item = new MediaItem();
                item.Title = "好姑娘等着我";
                item.Subtitle = "刘一鸣";
                item.SetImage(_baseUriPic, "MovieLogo.png");
                item.Source = new Uri(_baseUriContent, "10好姑娘等着我_刘一鸣.avi");
                Collection.Add(item);

                item = new MediaItem();
                item.Title = "战友还记得吗";
                item.Subtitle = "小曾";
                item.SetImage(_baseUriPic, "MovieLogo.png");
                item.Source = new Uri(_baseUriContent, "11战友还记得吗_小曾.avi");
                Collection.Add(item);

                item = new MediaItem();
                item.Title = "好男儿就是要当兵";
                item.Subtitle = "刘和刚";
                item.SetImage(_baseUriPic, "MovieLogo.png");
                item.Source = new Uri(_baseUriContent, "12好男儿就是要当兵_刘和刚.avi");
                Collection.Add(item);

                item = new MediaItem();
                item.Title = "东西南北兵";
                item.Subtitle = "宋祖英";
                item.SetImage(_baseUriPic, "MovieLogo.png");
                item.Source = new Uri(_baseUriContent, "13东西南北兵_宋祖英.avi");
                Collection.Add(item);

                item = new MediaItem();
                item.Title = "小白杨";
                item.Subtitle = "";
                item.SetImage(_baseUriPic, "MovieLogo.png");
                item.Source = new Uri(_baseUriContent, "14小白杨.avi");
                Collection.Add(item);

                item = new MediaItem();
                item.Title = "军中姐妹";
                item.Subtitle = "张莉莉&张薇薇";
                item.SetImage(_baseUriPic, "MovieLogo.png");
                item.Source = new Uri(_baseUriContent, "15军中姐妹_张莉莉&张薇薇.avi");
                Collection.Add(item);

                item = new MediaItem();
                item.Title = "女兵十八";
                item.Subtitle = "白雪";
                item.SetImage(_baseUriPic, "MovieLogo.png");
                item.Source = new Uri(_baseUriContent, "16女兵十八_白雪.avi");
                Collection.Add(item);

                item = new MediaItem();
                item.Title = "青藏高原";
                item.Subtitle = "李娜";
                item.SetImage(_baseUriPic, "MovieLogo.png");
                item.Source = new Uri(_baseUriContent, "17青藏高原_李娜.avi");
                Collection.Add(item);

                item = new MediaItem();
                item.Title = "十五的月亮";
                item.Subtitle = "";
                item.SetImage(_baseUriPic, "MovieLogo.png");
                item.Source = new Uri(_baseUriContent, "18十五的月亮.avi");
                Collection.Add(item);

                item = new MediaItem();
                item.Title = "天路";
                item.Subtitle = "韩红";
                item.SetImage(_baseUriPic, "MovieLogo.png");
                item.Source = new Uri(_baseUriContent, "19天路_韩红.avi");
                Collection.Add(item);

                item = new MediaItem();
                item.Title = "我爱祖国的蓝天";
                item.Subtitle = "佚名";
                item.SetImage(_baseUriPic, "MovieLogo.png");
                item.Source = new Uri(_baseUriContent, "1我爱祖国的蓝天_佚名.avi");
                Collection.Add(item);

                item = new MediaItem();
                item.Title = "潇洒女兵";
                item.Subtitle = "女兵三人组";
                item.SetImage(_baseUriPic, "MovieLogo.png");
                item.Source = new Uri(_baseUriContent, "20潇洒女兵_女兵三人组.avi");
                Collection.Add(item);

                item = new MediaItem();
                item.Title = "咱当兵的人";
                item.Subtitle = "佚名";
                item.SetImage(_baseUriPic, "MovieLogo.png");
                item.Source = new Uri(_baseUriContent, "21咱当兵的人_佚名.avi");
                Collection.Add(item);

                item = new MediaItem();
                item.Title = "战士第二故乡";
                item.Subtitle = "李双江";
                item.SetImage(_baseUriPic, "MovieLogo.png");
                item.Source = new Uri(_baseUriContent, "22战士第二故乡_李双江.avi");
                Collection.Add(item);

                item = new MediaItem();
                item.Title = "军港之夜";
                item.Subtitle = "苏小明";
                item.SetImage(_baseUriPic, "MovieLogo.png");
                item.Source = new Uri(_baseUriContent, "2军港之夜_苏小明.avi");
                Collection.Add(item);

                item = new MediaItem();
                item.Title = "中国人民解放军进行曲";
                item.Subtitle = "佚名";
                item.SetImage(_baseUriPic, "MovieLogo.png");
                item.Source = new Uri(_baseUriContent, "3中国人民解放军进行曲_佚名.avi");
                Collection.Add(item);

                item = new MediaItem();
                item.Title = "当那一天来临";
                item.Subtitle = "陈小涛";
                item.SetImage(_baseUriPic, "MovieLogo.png");
                item.Source = new Uri(_baseUriContent, "4当那一天来临_陈小涛.avi");
                Collection.Add(item);

                item = new MediaItem();
                item.Title = "爱国奉献歌";
                item.Subtitle = "";
                item.SetImage(_baseUriPic, "MovieLogo.png");
                item.Source = new Uri(_baseUriContent, "5爱国奉献歌.avi");
                Collection.Add(item);

                item = new MediaItem();
                item.Title = "军中绿花";
                item.Subtitle = "小曾";
                item.SetImage(_baseUriPic, "MovieLogo.png");
                item.Source = new Uri(_baseUriContent, "6军中绿花_小曾.avi");
                Collection.Add(item);

                item = new MediaItem();
                item.Title = "绿军装的梦";
                item.Subtitle = "";
                item.SetImage(_baseUriPic, "MovieLogo.png");
                item.Source = new Uri(_baseUriContent, "7绿军装的梦.avi");
                Collection.Add(item);

                item = new MediaItem();
                item.Title = "说句心里话";
                item.Subtitle = "";
                item.SetImage(_baseUriPic, "MovieLogo.png");
                item.Source = new Uri(_baseUriContent, "8说句心里话.avi");
                Collection.Add(item);

                item = new MediaItem();
                item.Title = "当你的秀发拂过我的钢枪";
                item.Subtitle = "高歌";
                item.SetImage(_baseUriPic, "MovieLogo.png");
                item.Source = new Uri(_baseUriContent, "9当你的秀发拂过我的钢枪_高歌.avi");
                Collection.Add(item);
            }

            private MediaItemCollection _Collection = new MediaItemCollection();

            public MediaItemCollection Collection
            {
                get
                {
                    return this._Collection;
                }
            }
        }

        public class MediaItemCollection : IEnumerable<Object>
        {
            private System.Collections.ObjectModel.ObservableCollection<MediaItem> mediaItemCollection = new System.Collections.ObjectModel.ObservableCollection<MediaItem>();

            public IEnumerator<Object> GetEnumerator()
            {
                return mediaItemCollection.GetEnumerator();
            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public void Add(MediaItem mediaItem)
            {
                mediaItemCollection.Add(mediaItem);
            }
        }
    #endif
    }

