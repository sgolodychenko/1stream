using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OneStream.Models;
using WebMatrix.WebData;

namespace OneStream.Controllers
{   
    public class ChannelsController : Controller
    {
        private OneStreamContext context = new OneStreamContext();

        //
        // GET: /Channels/

        public ViewResult Index()
        {
            return View(context.Channels.ToList());
        }

        //
        // GET: /Channels/Details/5

        public ViewResult Details(int id)
        {
            Channel channel = context.Channels.Single(x => x.ChannelId == id);
            return View(channel);
        }

        //
        // GET: /Channels/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Channels/Create

        [HttpPost]
        public ActionResult Create(Channel channel)
        {
            ModelState.Clear();
            channel.UserId = WebSecurity.GetUserId(User.Identity.Name);
            TryValidateModel(channel);

            if (ModelState.IsValid)
            {
                context.Channels.Add(channel);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(channel);
        }
        
        //
        // GET: /Channels/Edit/5
 
        public ActionResult Edit(int id)
        {
            Channel channel = context.Channels.Single(x => x.ChannelId == id);
            return View(channel);
        }

        //
        // POST: /Channels/Edit/5

        [HttpPost]
        public ActionResult Edit(Channel channel)
        {
            if (ModelState.IsValid)
            {
                context.Entry(channel).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(channel);
        }

        //
        // GET: /Channels/Delete/5
 
        public ActionResult Delete(int id)
        {
            Channel channel = context.Channels.Single(x => x.ChannelId == id);
            return View(channel);
        }

        //
        // POST: /Channels/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Channel channel = context.Channels.Single(x => x.ChannelId == id);
            context.Channels.Remove(channel);
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