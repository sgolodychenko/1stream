using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using OneStream.Models;
using WebMatrix.WebData;
using _1stream.Filters;

namespace OneStream.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class BroadcastsController : BaseController
    {
        //
        // GET: /Broadcasts/

        [Authorize(Roles = "Admin")]
        public ViewResult Index()
        {
            return View(Context.Broadcasts.Include(broadcast => broadcast.Channel).ToList());
        }

        [Authorize]
        public ViewResult IndexMy()
        {
            var userId = WebSecurity.GetUserId(User.Identity.Name);
            var broadcasts =
                Context.Broadcasts.Include(broadcast => broadcast.Channel).Where(b => b.Channel.UserId == userId);
            return View("Index", broadcasts.ToList());
        }

        //
        // GET: /Broadcasts/Details/5

        [Authorize]
        public ViewResult Details(int id)
        {
            Broadcast broadcast = Context.Broadcasts.Single(x => x.BroadcastId == id);
            return View(broadcast);
        }

        //
        // GET: /Broadcasts/Create

        [Authorize]
        public ActionResult Create()
        {
            var userId = WebSecurity.GetUserId(User.Identity.Name);
            ViewBag.PossibleChannels = Context.Channels.Where(c=> c.UserId == userId).ToList();
            var channel = Context.Channels.FirstOrDefault(c => c.UserId == WebSecurity.CurrentUserId);
            if (channel == null)
            {
                return RedirectToAction("Create", "Channels");
            }
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
            broadcast.StartDate = broadcast.StartDate.ToUniversalTime();
            broadcast.CreatedOn = DateTime.Now;
            broadcast.UpdatedOn = DateTime.Now;

            TryValidateModel(broadcast);

            if (ModelState.IsValid)
            {
                Context.Broadcasts.Add(broadcast);
                Context.SaveChanges();
                return Roles.IsUserInRole(UserRole.Admin) ? RedirectToAction("Index") : RedirectToAction("IndexMy");
            }

            var userId = WebSecurity.GetUserId(User.Identity.Name);
            ViewBag.PossibleChannels = Context.Channels.Where(c => c.UserId == userId).ToList();
            return View(broadcast);
        }
        
        //
        // GET: /Broadcasts/Edit/5

        [Authorize]
        public ActionResult Edit(int id)
        {
            Broadcast broadcast = Context.Broadcasts.Single(x => x.BroadcastId == id);
            var userId = WebSecurity.GetUserId(User.Identity.Name);
            ViewBag.PossibleChannels = Context.Channels.Where(c => c.UserId == userId).ToList();
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
                Context.Entry(broadcast).State = EntityState.Modified;
                Context.SaveChanges();
                return Roles.IsUserInRole(UserRole.Admin) ? RedirectToAction("Index") : RedirectToAction("IndexMy");
            }
            var userId = WebSecurity.GetUserId(User.Identity.Name);
            ViewBag.PossibleChannels = Context.Channels.Where(c => c.UserId == userId).ToList();
            return View(broadcast);
        }

        //
        // GET: /Broadcasts/Delete/5

        [Authorize]
        public ActionResult Delete(int id)
        {
            Broadcast broadcast = Context.Broadcasts.Single(x => x.BroadcastId == id);
            return View(broadcast);
        }

        //
        // POST: /Broadcasts/Delete/5

        [Authorize]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Broadcast broadcast = Context.Broadcasts.Single(x => x.BroadcastId == id);
            Context.Broadcasts.Remove(broadcast);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                Context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}