using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_try
{
    using System;
    using Windows.UI.Xaml.Data;
    using Windows.UI.Xaml.Media;
    using Windows.UI.Xaml.Media.Imaging;
    using Windows.Storage;
    public class ImagePath
    {
        public string ImgPath { get; set; }
        public string aviPath { get; set; }
    }

    public class ImagePathData
    {
        public List<ImagePath> ImagePathList = new List<ImagePath>();
        string BaseGIFPath = "ms-appx:///Assets/Images/Nature/GIF/";
        string BaseJPEGPath = "ms-appx:///Assets/Images/Nature/JPEG/";
        string BaseAVIPath = "ms-appx:///Assets/Images/Nature/AVI/";
        public String[] gifPathArray = {
                                "1",
                                "10",
                                "13",
                                "14",
                                "17",
                                "18",
                                "2",
                                "25",
                                "3",
                                "32",
                                "34",
                                "35",
                                "38",
                                "4",
                                "46",
                                "56",
                                "7",
                                "8",
                                "84",
                                "87",
                                "88",
                                "95",
                                };
        public String[] jpgPathArray ={
                                         "爱恋花-1",
                                         "爱恋花-2",
                                         "蝴蝶树-10",
                                         "魅力春夏-8",
                                         "群鸟-12",
                                         "诗情画意-3",
                                         "桃源春色",
                                         "雪域-9",
                                         "中国水墨画-4",
                                         "中国水墨画-5",
                                         "中国水墨画-6",
                                         "中国水墨画-7"
                                     };
        public ImagePathData()
        {
            for (int num = 0; num < gifPathArray.Length; num++)
            {
                ImagePathList.Add(new ImagePath { ImgPath = BaseGIFPath + gifPathArray[num] + ".gif",
                aviPath = BaseAVIPath + gifPathArray[num] + ".avi"});
            }

            for (int num = 0; num < jpgPathArray.Length; num++)
            {
                ImagePathList.Add(new ImagePath { ImgPath = BaseJPEGPath + jpgPathArray[num] + ".jpg",
                aviPath = BaseAVIPath + jpgPathArray[num] + ".avi"});
            }
        }

    }
    public class PunPathData
    {
        public List<ImagePath> ImagePathList = new List<ImagePath>();
        string BasePath = "ms-appx:///Assets/Images/PunPic/";
        public String[] jpgPathArray ={
                                         "01",
                                         "02",
                                         "035",
                                         "04",
                                         "05",
                                         "06",
                                         "081",
                                         "084",
                                         "086",
                                         "097",
                                         "098"
                                     };
        public PunPathData()
        {
            for (int num = 0; num < jpgPathArray.Length; num++)
            {
                ImagePathList.Add(new ImagePath { ImgPath = BasePath + jpgPathArray[num] + ".jpg"
                });
            }
         }
    }
    public class IllusionPathData
    {
        public List<ImagePath> ImagePathList = new List<ImagePath>();
        string BasePath = "ms-appx:///Assets/Images/IllusionPic/";
        public String[] jpgPathArray ={
                                         "01.jpg",
                                         "02.png",
                                         "03.jpg",
                                         "04-.png",
                                         "05-.png",
                                         "06-.png",
                                         "07-.png",
                                         "1.png",
                                         "2.png",
                                         "3.png",
                                         "4.png",
                                         "5.png"
                                     };
        public IllusionPathData()
        {
            for (int num = 0; num < jpgPathArray.Length; num++)
            {
                ImagePathList.Add(new ImagePath
                {
                    ImgPath = BasePath + jpgPathArray[num]
                });
            }
        }
    }

}
