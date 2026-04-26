using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FitCore.Models;
using System.Linq;

namespace FitCore.Controllers
{
    public class SubscriptionsController : Controller
    {
        private readonly AppDbContext _context;

        public SubscriptionsController(AppDbContext context)
        {
            _context = context;
        }

        
        public IActionResult Index()
        {
            
            var subscriptions = _context.Subscriptions
                                        .Include(s => s.Member)
                                        .OrderByDescending(s => s.StartDate)
                                        .ToList();
            return View(subscriptions);
        }

        
        public IActionResult Create()
        {
            
            ViewBag.Members = new SelectList(_context.Members, "MemberId", "FullName");
            return View();
        }

       
        [HttpPost]
        public IActionResult Create(Subscription subscription)
        {
            _context.Subscriptions.Add(subscription);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}