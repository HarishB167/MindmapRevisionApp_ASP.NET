using MindmapRevisionApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MindmapRevisionApp.Controllers
{
    public class MindmapController : Controller
    {
        private ApplicationDbContext _context;

        public MindmapController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        
        public ActionResult Index()
        {
            var mindmaps = _context.Mindmaps;
            
            return View(mindmaps);
        }
        
        public ActionResult New()
        {
            return View("MindmapForm", new Mindmap());
        }

        [HttpPost]
        public ActionResult Save(Mindmap mindmap)
        {
            if (!ModelState.IsValid)
                return View("MindmapForm", mindmap);

            if (mindmap.Id == 0)
                _context.Mindmaps.Add(mindmap);
            else
            {
                var mindmapInDb = _context.Mindmaps.Single(c => c.Id == mindmap.Id);
                mindmapInDb.Title = mindmap.Title;
                mindmapInDb.Topic = mindmap.Topic;
                mindmapInDb.Content = mindmap.Content;
                mindmapInDb.RevisionsCount = mindmap.RevisionsCount;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Mindmap");
        }

        public ActionResult Edit(int id)
        {
            var mindmap = _context.Mindmaps.SingleOrDefault(c => c.Id == id);
            if (mindmap == null)
                return HttpNotFound();
            return View("MindmapForm", mindmap);
        }

        public ActionResult View(int id)
        {
            var mindmap = _context.Mindmaps.SingleOrDefault(c => c.Id == id);
            if (mindmap == null)
                return HttpNotFound();
            return View(mindmap);
        }

        public ActionResult IncrementRevisions(int id)
        {
            var mindmap = _context.Mindmaps.SingleOrDefault(c => c.Id == id);
            if (mindmap == null)
                return HttpNotFound();
            mindmap.RevisionsCount++;
            _context.SaveChanges();
            return RedirectToAction("View", "Mindmap", new { id = id } );
        }
    }
}
