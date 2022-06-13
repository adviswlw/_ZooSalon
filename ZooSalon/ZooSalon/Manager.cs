using System;
using System.Collections.Generic; 
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ZooSalon
{
    public class Manager
    {
        public static Frame frameContent { get; set; }

        public static User loginedUser;
        public static BitmapImage LoadImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }
        public static byte[] BitmapToByteArray(BitmapImage image)
        {
            byte[] data;
            PngBitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(image));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                data = ms.ToArray();
            }
            return data;
        }

        //internal static ImageSource LoadImage(string v)
        //{
        //    throw new NotImplementedException();
        //}

        public static bool IsValidEmail(string email)
        {
            try
            {
                var mail = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }


}


//// написать
    //public static ZooSalonEntities1 _context;
    ////-----------------------------

    //public ZooSalonEntities1()
    //    : base("name=ZooSalonEntities1")
    //{
    //}

    ////написать 
    //public static ZooSalonEntities1 GetContext()
    //{
    //    if (_context == null)
    //        _context = new ZooSalonEntities1();

    //    return _context;
    //}
    ////-------------------------------