using System.Data;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using OneStream.Models;
using WebMatrix.WebData;
using _1stream.Filters;

namespace OneStream.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class ChannelsController : BaseController
    {
        //
        // GET: /Channels/

        [Authorize(Roles = "Admin")]
        public ViewResult Index()
        {
            return View(Context.Channels.ToList());
        }

        //
        // GET: /Channels/Details/5

        [Authorize]
        public ViewResult Details(int id)
        {
            Channel channel = Context.Channels.Single(x => x.ChannelId == id);
            return View(channel);
        }

        //
        // GET: /Channels/Create
        
        [Authorize]
        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Channels/Create

        [HttpPost]
        [Authorize]
        public ActionResult Create(Channel channel)
        {
            ModelState.Clear();
            channel.UserId = WebSecurity.GetUserId(User.Identity.Name);
            TryValidateModel(channel);

            if (ModelState.IsValid)
            {
                Context.Channels.Add(channel);
                Context.SaveChanges();

                return Roles.IsUserInRole(UserRole.Admin) ? RedirectToAction("Index") : RedirectToAction("IndexMy", "Broadcasts");
            }

            return View(channel);
        }
        
        //
        // GET: /Channels/Edit/5

        [Authorize]
        public ActionResult Edit(int id)
        {
            Channel channel = Context.Channels.Single(x => x.ChannelId == id);
            return View(channel);
        }

        //
        // POST: /Channels/Edit/5

        [HttpPost]
        [Authorize]
        public ActionResult Edit(Channel channel)
        {
            if (ModelState.IsValid)
            {
                Context.Entry(channel).State = EntityState.Modified;
                Context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(channel);
        }

        //
        // GET: /Channels/Delete/5
 
        public ActionResult Delete(int id)
        {
            Channel channel = Context.Channels.Single(x => x.ChannelId == id);
            return View(channel);
        }

        //
        // POST: /Channels/Delete/5

        [Authorize]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Channel channel = Context.Channels.Single(x => x.ChannelId == id);
            Context.Channels.Remove(channel);
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