using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windows.UI.Xaml.Media;

namespace Project_try.ArticleItem
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

    public class Item : System.ComponentModel.INotifyPropertyChanged
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

        private string _Content = string.Empty;
        public string Content
        {
            get
            {
                return this._Content;
            }

            set
            {
                if (this._Content != value)
                {
                    this._Content = value;
                    this.OnPropertyChanged("Content");
                }
            }
        }
        public async void SetContent(Uri baseUri, String path)
        {
            StorageFile Contentfile = await StorageFile.GetFileFromApplicationUriAsync(new Uri(baseUri, path));
            Content = await FileIO.ReadTextAsync(Contentfile);
            
        }

        private uint _StartPage = 0;
        public uint StartPage
        {
            get
            {
                return this._StartPage;
            }

            set
            {
                if (this._StartPage != value)
                {
                    this._StartPage = value;
                    this.OnPropertyChanged("StartPage");
                }
            }
        }

        private uint _PageNum = 0;
        public uint PageNum
        {
            get
            {
                return this._PageNum;
            }

            set
            {
                if (this._PageNum != value)
                {
                    this._PageNum = value;
                    this.OnPropertyChanged("PageNum");
                }
            }
        }


    }


    public class MessageData
    {
        Uri _baseUriPic = new Uri("ms-appx:///SampleData/Images/");
        Uri _baseUriContent = new Uri("ms-appx:///Assets/Article/心里文章.pdf");
        public MessageData()
        {
        }
        private ItemCollection _Collection = new ItemCollection();

        public ItemCollection Collection
        {
            get
            {
                return this._Collection;
            }
        }
    }

    // Workaround: data binding works best with an enumeration of objects that does not implement IList
    public class ItemCollection : IEnumerable<Object>
    {
        private System.Collections.ObjectModel.ObservableCollection<Item> itemCollection = new System.Collections.ObjectModel.ObservableCollection<Item>();

        public IEnumerator<Object> GetEnumerator()
        {
            return itemCollection.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(Item item)
        {
            itemCollection.Add(item);
        }
    }
#endif
}
