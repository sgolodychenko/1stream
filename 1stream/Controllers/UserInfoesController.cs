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
    public class UserInfoesController : Controller
    {
        private OneStreamContext context = new OneStreamContext();

        //
        // GET: /UserInfoes/

        public ViewResult Index()
        {
            return View(context.UserInfoes.ToList());
        }

        //
        // GET: /UserInfoes/Details/5

        public ViewResult Details()
        {
            var userInfo = context.UserInfoes.FirstOrDefault(x => x.UserId == WebSecurity.CurrentUserId);
            if (userInfo == null)
                return View("Create");
            return View(userInfo);
        }

        //
        // GET: /UserInfoes/Create

        public ActionResult Create()
        {
            return View("Create");
        }

        //
        // POST: /UserInfoes/Create

        [HttpPost]
        public ActionResult Create(UserInfo userinfo)
        {
            if (ModelState.IsValid)
            {
                userinfo.UserId = WebSecurity.CurrentUserId;
                context.UserInfoes.Add(userinfo);
                context.SaveChanges();
                return View("Details", userinfo);
            }

            return View(userinfo);
        }

        //
        // GET: /UserInfoes/Edit/5

        public ActionResult Edit(int id)
        {
            var userinfo = context.UserInfoes.FirstOrDefault(x => x.UserId == id) ?? new UserInfo { UserId = id };
            return View(userinfo);
        }

        //
        // POST: /UserInfoes/Edit/5

        [HttpPost]
        public ActionResult Edit([Bind(Exclude = "Balance")] UserInfo userinfo)
        {
            if (ModelState.IsValid)
            {
                context.Entry(userinfo).State = EntityState.Modified;

                context.SaveChanges();
                return RedirectToAction("Details", new {id = userinfo.UserId});
            }
            return View(userinfo);
        }

        //
        // GET: /UserInfoes/Delete/5

        public ActionResult Delete(int id)
        {
            UserInfo userinfo = context.UserInfoes.Single(x => x.UserId == id);
            return View(userinfo);
        }

        //
        // POST: /UserInfoes/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            UserInfo userinfo = context.UserInfoes.Single(x => x.UserId == id);
            context.UserInfoes.Remove(userinfo);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}