using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrudOperations.Models;

namespace CrudOperations.Controllers
{
    public class StudentsController : Controller
    {
        private readonly Studentcontext _context;

        public StudentsController(Studentcontext context)
        {
            _context = context;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            return View(await _context.Students.ToListAsync());
        }



        // GET: Students/Create
        public IActionResult AddorEdit(int id=0)
        {
            if(id==0)
            return View(new Student());
            else
                return View(_context.Students.Find(id));
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddorEdit([Bind("StudentId,FullName,Rollno,Email,Address")] Student student)
        {
            if (ModelState.IsValid)
            {
                if(student.StudentId ==0)
                _context.Add(student);
                else
                    _context.Update(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

      
        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var student = await _context.Students.FindAsync(id);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

   
    }
}
