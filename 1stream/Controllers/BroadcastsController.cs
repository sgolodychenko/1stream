using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OneStream.Models;

namespace OneStream.Controllers
{   
    public class BroadcastsController : Controller
    {
        private OneStreamContext context = new OneStreamContext();

        //
        // GET: /Broadcasts/

        public ViewResult Index()
        {
            return View(context.Broadcasts.Include(broadcast => broadcast.Channel).ToList());
        }

        //
        // GET: /Broadcasts/Details/5

        public ViewResult Details(int id)
        {
            Broadcast broadcast = context.Broadcasts.Single(x => x.BroadcastId == id);
            return View(broadcast);
        }

        //
        // GET: /Broadcasts/Create

        public ActionResult Create()
        {
            ViewBag.PossibleChannels = context.Channels;
            return View();
        } 

        //
        // POST: /Broadcasts/Create

        [HttpPost]
        public ActionResult Create(Broadcast broadcast)
        {
            ModelState.Clear();
            broadcast.StartDate = DateTime.Now;
            broadcast.CreatedOn = DateTime.Now;
            broadcast.UpdatedOn = DateTime.Now;

            TryValidateModel(broadcast);

            if (ModelState.IsValid)
            {
                context.Broadcasts.Add(broadcast);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.PossibleChannels = context.Channels;
            return View(broadcast);
        }
        
        //
        // GET: /Broadcasts/Edit/5
 
        public ActionResult Edit(int id)
        {
            Broadcast broadcast = context.Broadcasts.Single(x => x.BroadcastId == id);
            ViewBag.PossibleChannels = context.Channels;
            return View(broadcast);
        }

        //
        // POST: /Broadcasts/Edit/5

        [HttpPost]
        public ActionResult Edit(Broadcast broadcast)
        {
            broadcast.UpdatedOn = DateTime.Now;

            if (ModelState.IsValid)
            {
                context.Entry(broadcast).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PossibleChannels = context.Channels;
            return View(broadcast);
        }

        //
        // GET: /Broadcasts/Delete/5
 
        public ActionResult Delete(int id)
        {
            Broadcast broadcast = context.Broadcasts.Single(x => x.BroadcastId == id);
            return View(broadcast);
        }

        //
        // POST: /Broadcasts/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Broadcast broadcast = context.Broadcasts.Single(x => x.BroadcastId == id);
            context.Broadcasts.Remove(broadcast);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}