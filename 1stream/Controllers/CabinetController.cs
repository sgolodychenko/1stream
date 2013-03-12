using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using OneStream.Models;
using WebMatrix.WebData;
using _1stream.Filters;

namespace OneStream.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class CabinetController : Controller
    {
        private OneStreamContext context = new OneStreamContext();
        //
        // GET: /Cabinet/

        public ActionResult Index()
        {
            
            var cabinet = new PersonalCabinet();
            var channels = context.Channels.Where(c => c.UserId == WebSecurity.CurrentUserId);
            //cabinet.MonthBroadcasts = channels.Where(c => c.Broadcasts.Where(b => b.StartDate > DateTime.Now.AddDays(-2) && b.StartDate < DateTime.Now.AddMonths(1)));
            ValueType i = channels.Count();
            cabinet.ArchivedBroadcasts =
                context.Broadcasts.Where(
                    b => b.Channel.UserId == WebSecurity.CurrentUserId && b.StartDate < DateTime.Now);

            return View(cabinet);
        }

    }
}
