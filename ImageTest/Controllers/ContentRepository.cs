using ImageTest.Models;
using System;
using System.IO;
using System.Web;

namespace ImageTest.Controllers
{
    internal class ContentRepository
    {
        private readonly ImageDbEntities2 db = new ImageDbEntities2();
        public int UploadImageInDataBase(HttpPostedFileBase file, Image image)
        {
                image.Data = ConvertToBytes(file);
                var Content = new Image
                {
                    //id = image.id,
                    Name = image.Name,
                    ContentType = image.ContentType,
                    Data = image.Data
                };
                db.Images.Add(Content);
                int i = db.SaveChanges();
                if (i == 1)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
        
        }
        public byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
        }
    }
}