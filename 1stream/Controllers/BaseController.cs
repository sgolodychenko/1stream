using System.Linq;
using System.Web.Mvc;
using OneStream.Models;
using _1stream.Filters;

namespace OneStream.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class BaseController : Controller
    {
        public OneStreamContext Context = new OneStreamContext();

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (!Request.IsAuthenticated) return;

            var info = Context.UserInfoes.FirstOrDefault(x => x.UserProfile.UserName == User.Identity.Name);
            
            ViewBag.UserFullName = info != null ? string.Format("{0} {1}", info.FirstName, info.LastName) : User.Identity.Name;
        }
    }
}