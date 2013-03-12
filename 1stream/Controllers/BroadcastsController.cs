using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OneStream.Models;
using WebMatrix.WebData;
using _1stream.Filters;

namespace OneStream.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class BroadcastsController : Controller
    {
        private OneStreamContext context = new OneStreamContext();

        //
        // GET: /Broadcasts/

        [Authorize]
        public ViewResult Index()
        {
            return View(context.Broadcasts.Include(broadcast => broadcast.Channel).ToList());
        }

        //
        // GET: /Broadcasts/Details/5

        [Authorize]
        public ViewResult Details(int id)
        {
            Broadcast broadcast = context.Broadcasts.Single(x => x.BroadcastId == id);
            return View(broadcast);
        }

        //
        // GET: /Broadcasts/Create

        [Authorize]
        public ActionResult Create()
        {
            ViewBag.PossibleChannels = context.Channels;
            var channel = context.Channels.FirstOrDefault(c => c.UserId == WebSecurity.CurrentUserId);
            var broadcast = new Broadcast()
                {
                    CostOfLive = channel.CostOfLive,
                    CostOfStorage = channel.CostOfStorage,
                    WatchersCount = channel.WatchersCount,
                    ChatEnable = channel.ChatEnable,
                    FeedbackBroadcaster = channel.FeedbackBroadcaster,
                    FeedbackSms = channel.FeedbackSms,
                    FeedbackMail = channel.FeedbackMail,
                    FeedbackCabinet = channel.FeedbackCabinet,
                    CustomLogo = channel.CustomLogo,
                    FreeStreming = channel.FreeStreming,
                    StartDate = DateTime.Now
                };
            return View(broadcast);
        } 

        //
        // POST: /Broadcasts/Create

        [HttpPost]
        [Authorize]
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

        [Authorize]
        public ActionResult Edit(int id)
        {
            Broadcast broadcast = context.Broadcasts.Single(x => x.BroadcastId == id);
            ViewBag.PossibleChannels = context.Channels;
            return View(broadcast);
        }

        //
        // POST: /Broadcasts/Edit/5

        [HttpPost]
        [Authorize]
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

        [Authorize]
        public ActionResult Delete(int id)
        {
            Broadcast broadcast = context.Broadcasts.Single(x => x.BroadcastId == id);
            return View(broadcast);
        }

        //
        // POST: /Broadcasts/Delete/5

        [Authorize]
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