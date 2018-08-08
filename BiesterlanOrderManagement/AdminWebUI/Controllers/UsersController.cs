using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BiesterlanOrders.Models;
using Data;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace AdminWebUI.Controllers
{
    public class UsersController :ContextController
    {
        private readonly BiesterlanDbContext _context;
        public UsersController(BiesterlanDbContext context,IConfiguration configuration) :base(context,configuration)
        {
           

          
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.ID == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,ID,Active,ImageName")] User user)
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


                        byte[] imagebytes = null;
                        using (Stream fs1 = file.OpenReadStream())
                        {
                            using (MemoryStream ms1 = new MemoryStream())
                            {
                               await fs1.CopyToAsync(ms1);
                                imagebytes = ms1.ToArray();
                            }
                        }


                        user.Image = imagebytes;
                        
                        user.ImageName = filename;
                    }
                }

                user.ID = Guid.NewGuid();
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,ID,Active,ImageName")] User user)
        {
            if (id != user.ID)
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


                            byte[] imagebytes = null;
                            using (Stream fs1 = file.OpenReadStream())
                            {
                                using (MemoryStream ms1 = new MemoryStream())
                                {
                                    await fs1.CopyToAsync(ms1);
                                    imagebytes = ms1.ToArray();
                                }
                            }

                            user.ImageName = filename;
                            user.Image = imagebytes;
                        }
                    }


                            _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.ID))
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
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.ID == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(Guid id)
        {
            return _context.Users.Any(e => e.ID == id);
        }
    }
}
