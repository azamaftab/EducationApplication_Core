using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Education.Data;
using Education.Domain;

namespace Education.Web.Controllers
{
    public class ClassTeachersController : Controller
    {
        private readonly EducationContext _context;

        public ClassTeachersController(EducationContext context)
        {
            _context = context;
        }

        // GET: ClassTeachers
        public async Task<IActionResult> Index()
        {
            var educationContext = _context.ClassTeachers.Include(c => c.Class).Include(c => c.Teachers);
            return View(await educationContext.ToListAsync());
        }

        // GET: ClassTeachers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classTeacher = await _context.ClassTeachers
                .Include(c => c.Class)
                .Include(c => c.Teachers)
                .FirstOrDefaultAsync(m => m.ClassTeacherID == id);
            if (classTeacher == null)
            {
                return NotFound();
            }

            return View(classTeacher);
        }

        // GET: ClassTeachers/Create
        public IActionResult Create()
        {
            ViewData["ClassID"] = new SelectList(_context.Classes, "ClassID", "ClassName");
            ViewData["TeacherID"] = new SelectList(_context.Teachers, "TeacherID", "TeacherName");
            return View();
        }

        // POST: ClassTeachers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClassTeacherID,ClassID,TeacherID")] ClassTeacher classTeacher)
        {
            if (ModelState.IsValid)
            {
                _context.Add(classTeacher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassID"] = new SelectList(_context.Classes, "ClassID", "ClassName", classTeacher.ClassID);
            ViewData["TeacherID"] = new SelectList(_context.Teachers, "TeacherID", "TeacherName", classTeacher.TeacherID);
            return View(classTeacher);
        }

        // GET: ClassTeachers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classTeacher = await _context.ClassTeachers.FindAsync(id);
            if (classTeacher == null)
            {
                return NotFound();
            }
            ViewData["ClassID"] = new SelectList(_context.Classes, "ClassID", "ClassName", classTeacher.ClassID);
            ViewData["TeacherID"] = new SelectList(_context.Teachers, "TeacherID", "TeacherName", classTeacher.TeacherID);
            return View(classTeacher);
        }

        // POST: ClassTeachers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClassTeacherID,ClassID,TeacherID")] ClassTeacher classTeacher)
        {
            if (id != classTeacher.ClassTeacherID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classTeacher);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassTeacherExists(classTeacher.ClassTeacherID))
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
            ViewData["ClassID"] = new SelectList(_context.Classes, "ClassID", "ClassID", classTeacher.ClassID);
            ViewData["TeacherID"] = new SelectList(_context.Teachers, "TeacherID", "TeacherID", classTeacher.TeacherID);
            return View(classTeacher);
        }

        // GET: ClassTeachers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classTeacher = await _context.ClassTeachers
                .Include(c => c.Class)
                .Include(c => c.Teachers)
                .FirstOrDefaultAsync(m => m.ClassTeacherID == id);
            if (classTeacher == null)
            {
                return NotFound();
            }

            return View(classTeacher);
        }

        // POST: ClassTeachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var classTeacher = await _context.ClassTeachers.FindAsync(id);
            _context.ClassTeachers.Remove(classTeacher);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassTeacherExists(int id)
        {
            return _context.ClassTeachers.Any(e => e.ClassTeacherID == id);
        }
    }
}
