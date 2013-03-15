using System.Data;
using System.Linq;
using System.Web.Mvc;
using OneStream.Models;
using WebMatrix.WebData;
using _1stream.Filters;

namespace OneStream.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class UserInfoesController : BaseController
    {
        //
        // GET: /UserInfoes/

        public ViewResult Index()
        {
            return View(Context.UserInfoes.ToList());
        }

        //
        // GET: /UserInfoes/Details/5

        public ViewResult Details(int id)
        {
            var userInfo = Context.UserInfoes.FirstOrDefault(x => x.UserId == id);
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
                Context.UserInfoes.Add(userinfo);
                Context.SaveChanges();
                return View("Details", userinfo);
            }

            return View(userinfo);
        }

        //
        // GET: /UserInfoes/Edit/5

        public ActionResult Edit(int id)
        {
            var userinfo = Context.UserInfoes.FirstOrDefault(x => x.UserId == id) ?? new UserInfo { UserId = id };
            return View(userinfo);
        }

        //
        // POST: /UserInfoes/Edit/5

        [HttpPost]
        public ActionResult Edit([Bind(Exclude = "Balance")] UserInfo userinfo)
        {
            if (ModelState.IsValid)
            {
                //Context.Entry(userinfo).State = EntityState.Modified;
                var curUserInfo = Context.UserInfoes.Find(userinfo.UserId);
                Context.Entry(curUserInfo).CurrentValues.SetValues(userinfo);

                Context.SaveChanges();
                return RedirectToAction("Details", new {id = userinfo.UserId});
            }
            return View(userinfo);
        }

        //
        // GET: /UserInfoes/Delete/5

        public ActionResult Delete(int id)
        {
            UserInfo userinfo = Context.UserInfoes.Single(x => x.UserId == id);
            return View(userinfo);
        }

        //
        // POST: /UserInfoes/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            UserInfo userinfo = Context.UserInfoes.Single(x => x.UserId == id);
            Context.UserInfoes.Remove(userinfo);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}