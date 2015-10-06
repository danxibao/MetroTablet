using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windows.UI.Xaml.Media;

namespace Project_try.InterviewItem
{
    using System;
    using Windows.UI.Xaml.Data;
    using Windows.UI.Xaml.Media;
    using Windows.UI.Xaml.Media.Imaging;
    using Windows.Storage;
    // To significantly reduce the sample data footprint in your production application, you can set
    // the DISABLE_SAMPLE_DATA conditional compilation constant and disable sample data at runtime.
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


    public class MediaData
    {
        Uri _baseUriPic = new Uri("ms-appx:///Assets/AudioVisual/");
        Uri _baseUriContent = new Uri("ms-appx:///Assets/Interview/");
        public MediaData()
        {
            MediaItem item = null;

            item = new MediaItem();
            item.Title = "为什么不理我";
            item.Subtitle = "06.01.09";
            item.SetImage(_baseUriPic, "（2）心理访谈.png");
            item.Source=new Uri(_baseUriContent,"06.01.09.为什么不理我.avi");
            Collection.Add(item);

            item = new MediaItem();
            item.Title = "我的肚子怕考试";
            item.Subtitle = "06.01.27";
            item.SetImage(_baseUriPic, "（2）心理访谈.png");
            item.Source = new Uri(_baseUriContent, "06.01.27.我的肚子怕考试.avi");
            Collection.Add(item);

            item = new MediaItem();
            item.Title = "我被贴了“傻”标签";
            item.Subtitle = "06.02.14";
            item.SetImage(_baseUriPic, "（2）心理访谈.png");
            item.Source = new Uri(_baseUriContent, "06.02.14.我被贴了“傻”标签.avi");
            Collection.Add(item);

            item = new MediaItem();
            item.Title = "直面妒嫉";
            item.Subtitle = "06.03.03";
            item.SetImage(_baseUriPic, "（2）心理访谈.png");
            item.Source = new Uri(_baseUriContent, "06.03.03.直面妒嫉.avi");
            Collection.Add(item);

            item = new MediaItem();
            item.Title = "如何灭掉心中的火";
            item.Subtitle = "06.03.23";
            item.SetImage(_baseUriPic, "（2）心理访谈.png");
            item.Source = new Uri(_baseUriContent, "06.03.23.如何灭掉心中的火.avi");
            Collection.Add(item);

            item = new MediaItem();
            item.Title = "惧怕领导的背后";
            item.Subtitle = "06.05.11";
            item.SetImage(_baseUriPic, "（2）心理访谈.png");
            item.Source = new Uri(_baseUriContent, "06.05.11.惧怕领导的背后.avi");
            Collection.Add(item);

            item = new MediaItem();
            item.Title = "挑战疲劳期";
            item.Subtitle = "06.05.16";
            item.SetImage(_baseUriPic, "（2）心理访谈.png");
            item.Source = new Uri(_baseUriContent, "06.05.16.挑战疲劳期.avi");
            Collection.Add(item);

            item = new MediaItem();
            item.Title = "从心开始";
            item.Subtitle = "06.10.01";
            item.SetImage(_baseUriPic, "（2）心理访谈.png");
            item.Source = new Uri(_baseUriContent, "06.10.01.从心开始.avi");
            Collection.Add(item);

            item = new MediaItem();
            item.Title = "发现快乐";
            item.Subtitle = "06.10.02";
            item.SetImage(_baseUriPic, "（2）心理访谈.png");
            item.Source = new Uri(_baseUriContent, "06.10.02.发现快乐.avi");
            Collection.Add(item);

            item = new MediaItem();
            item.Title = "重拾自信";
            item.Subtitle = "07.07.01";
            item.SetImage(_baseUriPic, "（2）心理访谈.png");
            item.Source = new Uri(_baseUriContent, "07.07.01.重拾自信.avi");
            Collection.Add(item);

            item = new MediaItem();
            item.Title = "冲突不可怕";
            item.Subtitle = "07.10.02";
            item.SetImage(_baseUriPic, "（2）心理访谈.png");
            item.Source = new Uri(_baseUriContent, "07.10.02.冲突不可怕.avi");
            Collection.Add(item);

            item = new MediaItem();
            item.Title = "心理访谈.俞敏洪：不一样的选择（上）";
            item.Subtitle = "09.08.26";
            item.SetImage(_baseUriPic, "（2）心理访谈.png");
            item.Source = new Uri(_baseUriContent, "09.08.26.心理访谈.俞敏洪：不一样的选择（上）.avi");
            Collection.Add(item);

            item = new MediaItem();
            item.Title = "心理访谈.俞敏洪：不一样的选择（下）";
            item.Subtitle = "09.08.27";
            item.SetImage(_baseUriPic, "（2）心理访谈.png");
            item.Source = new Uri(_baseUriContent, "09.08.27.心理访谈.俞敏洪：不一样的选择（下）.avi");
            Collection.Add(item);

            item = new MediaItem();
            item.Title = "心理访谈.袁岳：坚持做对的事（上）";
            item.Subtitle = "09.09.01";
            item.SetImage(_baseUriPic, "（2）心理访谈.png");
            item.Source = new Uri(_baseUriContent, "09.09.01.心理访谈.袁岳：坚持做对的事（上）.avi");
            Collection.Add(item);

            item = new MediaItem();
            item.Title = "心理访谈.袁岳：坚持做对的事（下）";
            item.Subtitle = "09.09.02";
            item.SetImage(_baseUriPic, "（2）心理访谈.png");
            item.Source = new Uri(_baseUriContent, "09.09.02.心理访谈.袁岳：坚持做对的事（下）.avi");
            Collection.Add(item);

            item = new MediaItem();
            item.Title = "冲突不可怕";
            item.Subtitle = "07.10.02";
            item.SetImage(_baseUriPic, "（2）心理访谈.png");
            item.Source = new Uri(_baseUriContent, "07.10.02.冲突不可怕.avi");
            Collection.Add(item);

            item = new MediaItem();
            item.Title = "心理访谈.他是谁.和他一起寻找性格的秘密.雷敏.侠女柔情";
            item.Subtitle = "10.02.20";
            item.SetImage(_baseUriPic, "（2）心理访谈.png");
            item.Source = new Uri(_baseUriContent, "10.02.20.心理访谈.他是谁.和他一起寻找性格的秘密.雷敏.侠女柔情.avi");
            Collection.Add(item);

            item = new MediaItem();
            item.Title = "心理访谈.他是谁.和他一起寻找性格的秘密.雷敏.英雄本色";
            item.Subtitle = "10.02.21";
            item.SetImage(_baseUriPic, "（2）心理访谈.png");
            item.Source = new Uri(_baseUriContent, "10.02.21.心理访谈.他是谁.和他一起寻找性格的秘密.雷敏.英雄本色.avi");
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

    public class VideoData
    {
        Uri _baseUriPic = new Uri("ms-appx:///Assets/AudioVisual/");
        Uri _baseUriContent = new Uri("ms-appx:///Assets/Video/");
        public VideoData()
        {
            MediaItem item = new MediaItem();

            item = new MediaItem();
            item.Title = "压力管理与军人心理健康";
            item.Subtitle = "";
            item.SetImage(_baseUriPic, "（3）心理视频.png");
            item.Source = new Uri(_baseUriContent, "压力管理与军人心理健康.avi");
            Collection.Add(item);

            item = new MediaItem();
            item.Title = "有效调节压力的方法";
            item.Subtitle = "";
            item.SetImage(_baseUriPic, "（3）心理视频.png");
            item.Source = new Uri(_baseUriContent, "有效调节压力的方法.avi");
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

    public class MovieData
    {
        Uri _baseUriPic = new Uri("ms-appx:///Assets/AudioVisual/");
        Uri _baseUriContent = new Uri("ms-appx:///Assets/Movie/");
        public MovieData()
        {
            MediaItem item = new MediaItem();

            item = new MediaItem();
            item.Title = "战马";
            item.Subtitle = "";
            item.SetImage(_baseUriPic, "MovieLogo.png");
            item.Source = new Uri(_baseUriContent, "战马.avi");
            Collection.Add(item);

            item = new MediaItem();
            item.Title = "阿甘正传（上）";
            item.Subtitle = "";
            item.SetImage(_baseUriPic, "MovieLogo.png");
            item.Source = new Uri(_baseUriContent, "阿甘正传/阿甘正传1.avi");
            Collection.Add(item);

            item = new MediaItem();
            item.Title = "阿甘正传（中）";
            item.Subtitle = "";
            item.SetImage(_baseUriPic, "MovieLogo.png");
            item.Source = new Uri(_baseUriContent, "阿甘正传/阿甘正传2.avi");
            Collection.Add(item);

            item = new MediaItem();
            item.Title = "阿甘正传（下）";
            item.Subtitle = "";
            item.SetImage(_baseUriPic, "MovieLogo.png");
            item.Source = new Uri(_baseUriContent, "阿甘正传/阿甘正传3.avi");
            Collection.Add(item);

            item = new MediaItem();
            item.Title = "冲出亚马逊";
            item.Subtitle = "";
            item.SetImage(_baseUriPic, "MovieLogo.png");
            item.Source = new Uri(_baseUriContent, "冲出亚马逊-压缩.avi");
            Collection.Add(item);

            item = new MediaItem();
            item.Title = "怒海潜将";
            item.Subtitle = "";
            item.SetImage(_baseUriPic, "MovieLogo.png");
            item.Source = new Uri(_baseUriContent, "怒海潜将.avi");
            Collection.Add(item);

            item = new MediaItem();
            item.Title = "请让我用左手敬礼";
            item.Subtitle = "";
            item.SetImage(_baseUriPic, "MovieLogo.png");
            item.Source = new Uri(_baseUriContent, "丁晓兵：我的左手-压缩.avi");
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
    // Workaround: data binding works best with an enumeration of objects that does not implement IList
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
