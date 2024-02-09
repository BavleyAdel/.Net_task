using Microsoft.AspNetCore.Mvc;
using Shop_App.Models;

namespace Shop_App.Controllers
{
    public class DashBoardController : Controller
    {
        private static List<Blog> _blogs = new List<Blog>();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddBlog()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBlog(Blog blog)
        {
            int id;
            if(_blogs.Count == 0)
            {
                id = 1;
            }
            else
            {
                id = _blogs.Max(b => b.Id) + 1;
            }
            blog.Id = id;
            _blogs.Add(blog);
            return RedirectToAction("index");
        }

        public IActionResult DisplayAllBlogs()
        {
            return View(_blogs);
        }


        public IActionResult Delete(int id)
        {
            Blog blog = _blogs.FirstOrDefault(x => x.Id == id);
            _blogs.Remove(blog);

            return RedirectToAction("DisplayAllBlogs");
        }

        public IActionResult EditBlog(int id)
        {
            Blog blog = _blogs.FirstOrDefault(x=>x.Id == id);
            return View(blog);
        }

        [HttpPost]
        public IActionResult Edit(Blog blog)
        {
            Blog blg = _blogs.FirstOrDefault(x=> x.Id == blog.Id);

            blg.Title = blog.Title;
            blg.Description = blog.Description;
            blg.Date = blog.Date;
            blg.category.Name = blog.category.Name;
            blg.category.Id = blog.category.Id;

            return RedirectToAction("index");
        }
    }
}
