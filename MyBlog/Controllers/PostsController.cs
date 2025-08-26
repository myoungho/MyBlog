using Microsoft.AspNetCore.Mvc;
using MyBlog.Core.Entities;
using MyBlog.Core.Interfaces;

namespace MyBlog.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPostRepository _repository;

        public PostsController(IPostRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            var posts = await _repository.GetAllAsync();
            return View(posts);
        }

        public async Task<IActionResult> Details(int id)
        {
            var post = await _repository.GetByIdAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Post post)
        {
            if (ModelState.IsValid)
            {
                await _repository.AddAsync(post);
                return RedirectToAction(nameof(Index));
            }
            return View(post);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var post = await _repository.GetByIdAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Post post)
        {
            if (id != post.Id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                await _repository.UpdateAsync(post);
                return RedirectToAction(nameof(Index));
            }
            return View(post);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var post = await _repository.GetByIdAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
