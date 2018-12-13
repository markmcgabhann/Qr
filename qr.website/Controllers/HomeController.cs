using System.Drawing;
using System.IO;
using System.Web.Mvc;
using qr.service;
using qr.website.Models;
//using qr.website.service;

namespace qr.website.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View(new CodeViewModel{ CodeValue = "01234567890012345678900123456789001234567890012345678900123456789001234567890012345678900123456789001234567890 *** done " });
        }


        [HttpGet]
        public ActionResult Report(string model)
        {
            var qrService = new QrService();
            var bitmap = qrService.EncodeToBitmap("this value");
            var bitmapBytes = BitmapToBytes(bitmap); //Convert bitmap into a byte array
            return File(bitmapBytes, "image/jpeg"); //Return as file result
        }


        private static byte[] BitmapToBytes(Bitmap img)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }


    }
}
