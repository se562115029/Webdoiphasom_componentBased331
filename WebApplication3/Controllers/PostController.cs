using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models.EF;
using WebApplication3.Models.Entities;
using WebApplication3.Models.Repository;

namespace WebApplication3.Controllers
{
    public class PostController : Controller
    {
        IPostRepository repository;
        public PostController(IPostRepository post)
        {
            this.repository = post;
        }
        public ActionResult Index()
        {
            return View(repository.GetAllPost());
        }
        [HttpPost]
        public ActionResult Index(Post o)
        {
            repository.AddPost(o);
            return RedirectToAction("Index");
        }
        public ActionResult IndexAdmin()
        {
            return View(repository.GetAllPost());
        }
        [HttpPost]
        public ActionResult IndexAdmin
            (Post o)
        {
            repository.AddPost(o);
            return RedirectToAction("indexAdmin");
        }


        // GET: Post/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Post/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Post postsobj = new Post();
                EfDbContext _context = new EfDbContext();
                int count = 0;
                foreach (Post p in _context.Posts)
                {
                    count = int.Parse(p.PostID);

                }
                count++;
                
                var title = collection["Title"];
                var Conten = collection["Content"];
                postsobj.PostID = count.ToString();
                postsobj.DataPost = DateTime.Now.ToString(); ;
                postsobj.Title = title;
                postsobj.content = Conten;
                repository.AddPost(postsobj);

                return RedirectToAction("IndexAdmin");
            }
            catch
            {
                return View();
            }
        }

        // GET: Post/Edit/5
        public ActionResult Edit(string id)
        {
            Post p = repository.GetPostByID(id);

            return View(p);
        }

        // POST: Post/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                Post postsobj = new Post();
                EfDbContext _context = new EfDbContext();
                int count = 0;
                foreach (Post p in _context.Posts)
                {
                    count = int.Parse(p.PostID);

                }
                count++;
                
                var title = collection["Title"];
                var Conten = collection["Content"];
                postsobj.PostID = count.ToString();
                postsobj.DataPost = DateTime.Now.ToString(); ;
                postsobj.Title = title;
                postsobj.content = Conten;
                repository.EditPost(postsobj);


                return RedirectToAction("IndexAdmin");
            }
            catch
            {
                return View();
            }
        }

        // GET: Post/Delete/5
        public ActionResult Delete(string id)
        {
            Post p = repository.GetPostByID(id);
            return View(p);
        }

        // POST: Post/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                repository.DeletePost(id);

                return RedirectToAction("IndexAdmin");
            }
            catch
            {
                return View();
            }
        }
    }
}
