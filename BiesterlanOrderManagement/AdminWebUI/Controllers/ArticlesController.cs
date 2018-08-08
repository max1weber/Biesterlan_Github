using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BiesterlanOrders.Models;
using Data;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace AdminWebUI.Controllers
{
    public class ArticlesController : ContextController

    {
        private string imagepath;
        public ArticlesController(BiesterlanDbContext context, IConfiguration configuration) :base( context,configuration)
        {
          var imgpath=  base.Configuration["ImageStore:Path"];
            if (!Directory.Exists(imgpath))
                Directory.CreateDirectory(imgpath);

            imagepath = imgpath;
        }

        // GET: Articles
        public async Task<IActionResult> Index()
        {
            return View(await _context.Articles.ToListAsync());
        }

        // GET: Articles/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Articles
                .FirstOrDefaultAsync(m => m.ID == id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // GET: Articles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Articles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,ID,SalesPrice,IsActive,ArticleGroup, ImageName")] Article article)
        {
            if (ModelState.IsValid)
            {

                var files = HttpContext.Request.Form.Files;

                if (files.Count > 0)
                {
                    var file = files[0];

                    if (file != null && file.Length > 0)
                    {
                        var filename = file.FileName;
                        var newfilepath = Path.Combine(imagepath, filename);
                        using (var fileStream = new FileStream(Path.Combine(imagepath, filename), FileMode.Create))
                        {
                            await file.CopyToAsync(fileStream);

                        }
                        
                        article.ImageName = filename;
                    }
                }

                article.ID = Guid.NewGuid();
                _context.Add(article);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(article);
        }

        // GET: Articles/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Articles.FindAsync(id);
            if (article == null)
            {
                return NotFound();
            }
            return View(article);
        }

        // POST: Articles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,ID,SalesPrice,IsActive,ArticleGroup,ImageName")] Article article)
        {
            if (id != article.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    var files = HttpContext.Request.Form.Files;

                    if (files.Count > 0)
                    {
                        var file = files[0];

                        if (file != null && file.Length > 0)
                        {
                            var filename = file.FileName;
                            var newfilepath = Path.Combine(imagepath, filename);
                            using (var fileStream = new FileStream(Path.Combine(imagepath, filename), FileMode.Create))
                            {
                                await file.CopyToAsync(fileStream);
                                
                            }
                            
                            article.ImageName = filename;
                        }
                    }
                    _context.Update(article);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticleExists(article.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(article);
        }

        // GET: Articles/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Articles
                .FirstOrDefaultAsync(m => m.ID == id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var article = await _context.Articles.FindAsync(id);
            _context.Articles.Remove(article);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticleExists(Guid id)
        {
            return _context.Articles.Any(e => e.ID == id);
        }
    }
}
