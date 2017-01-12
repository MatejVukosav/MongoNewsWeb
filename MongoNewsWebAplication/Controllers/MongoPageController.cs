using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MongoNewsWebAplication.Models;
using MongoNewsWebAplication.Repositories;

namespace MongoNewsWebAplication.Controllers
{
    public class MongoPageController : Controller
    {
        // GET: MongoPage
        public ActionResult News()
        {
            ViewBag.Message = "Today news";

            List<News> news = DataRepository.getInstance().getNews();


            return View(news);
        }

        public ActionResult Comment(Comment comment)
        {
            return View();
        }
        public ActionResult CreateNews()
        {
            return View(new News());
        }
        [HttpPost]
        public ActionResult CreateNews(HttpPostedFileBase upload, [Bind(Include = "title,text,author,image")] News news)
        {
            if (upload != null && upload.ContentLength > 0)
            {
                using (var reader = new System.IO.BinaryReader(upload.InputStream))
                {
                    news.image = reader.ReadBytes(upload.ContentLength);
                }
            }
            DataRepository.getInstance().addNews(news);
            return RedirectToAction("News", "MongoPage");
        }
     

        //[HttpPost]
        //public void AddImage(HttpPostedFileBase upload)
        //{

        //    if (upload != null && upload.ContentLength > 0)
        //    {
        //        using (var reader = new System.IO.BinaryReader(upload.InputStream))
        //        {

        //        }
        //    }

            //  DataRepository.getInstance().addNews(news);
            // return RedirectToAction("News", "MongoPage");
       // }

        //public ActionResult CreateComment(int newsId)
        //{
           
        //    return View(new Comment());
        //}
    
        public ActionResult CreateComment(Guid newsId, string text)
        {
            //async Task<ActionResult>
            Comment comment = new Comment();
            comment.text = text;
            
           DataRepository.getInstance().addComment(comment, newsId);
           return RedirectToAction("News", "MongoPage");
        }
    }
}