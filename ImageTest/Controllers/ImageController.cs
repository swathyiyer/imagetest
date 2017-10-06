using ImageTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImageTest.Controllers
{
    public class ImageController : Controller
    {
        // GET: Image

        public ActionResult Create()
        {
            return View();
        }
        [Route("Create")]
        [HttpPost]
        public ActionResult Create(Image model)
        {
            if (ModelState.IsValid)
            {
                HttpPostedFileBase file = Request.Files["ImageData"];
                ContentRepository service = new ContentRepository();
                int i = service.UploadImageInDataBase(file, model);
                if (i == 1)
                {
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            return View();
        }

        public ActionResult Index()
        {
        ImageDbEntities2 db = new ImageDbEntities2();
            List<Image> showimage = db.Images.ToList();
            return View(showimage);
        }
        
        public ActionResult Details(int id)
        {

            byte[] cover = GetImageFromDataBase(id);
            if (cover != null)
            {
                return File(cover, "image/jpg");
            }
            else
            {
                return null;
            }
        }

        public byte[] GetImageFromDataBase(int Id)
        {
            ImageDbEntities2 db = new ImageDbEntities2();

            var q = from temp in db.Images where temp.id == Id select temp.Data;
            byte[] cover = q.First();
            return cover;
        }


    }
}