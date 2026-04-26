using Microsoft.AspNetCore.Mvc;
using FitCore.Models;
using System.Linq;

namespace FitCore.Controllers
{
    public class MembersController : Controller
    {
        private readonly AppDbContext _context;

        public MembersController(AppDbContext context)
        {
            _context = context;
        }

        
        public IActionResult Index()
        {
           
            var memberList = _context.Members
                                     .OrderBy(m => m.FullName)
                                     .ToList();

            return View(memberList);
        }

        
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        public IActionResult Create(Member member)
        {
            if (ModelState.IsValid)
            {
                _context.Members.Add(member);
                _context.SaveChanges();
                return RedirectToAction("Index"); // Kayıttan sonra listeye geri dön
            }
            return View(member);
        }
    }
}