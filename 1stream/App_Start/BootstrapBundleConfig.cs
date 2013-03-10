using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;

namespace BootstrapSupport
{
    public class BootstrapBundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/js").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery-migrate-{version}.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/jquery.validate.js",
                "~/scripts/jquery.validate.unobtrusive.js",
                "~/Scripts/jquery.validate.unobtrusive-custom-for-bootstrap.js"
                ));

            //bundles.Add(new StyleBundle("~/content/css").Include(
            //"~/Content/bootstrap.css",
            //"~/Content/body.css",
            //"~/Content/bootstrap-responsive.css",
            //"~/Content/bootstrap-mvc-validation.css"
            //));

            bundles.Add(new StyleBundle("~/content/css").Include(
                "~/Content/themes/measure/css/*.css"
                ));

            //bundles.Add(new StyleBundle("~/content/css").Include(
            //    "~/Content/themes/measure/css/animate.css",
            //    "~/Content/themes/measure/css/blog.css",
            //    "~/Content/themes/measure/css/bootstrup.css",
            //    "~/Content/themes/measure/css/bootstrup.min.css",
            //    "~/Content/themes/measure/css/external-pages.css",
            //    "~/Content/themes/measure/css/reset.css",
            //    "~/Content/themes/measure/css/signin.css",
            //    "~/Content/themes/measure/css/signup.css",
            //    "~/Content/themes/measure/css/theme.css"
            //    ));
        }
    }
}