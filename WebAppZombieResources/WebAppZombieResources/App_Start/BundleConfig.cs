using System.Web;
using System.Web.Optimization;

namespace WebAppZombieResources
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                   "~/Scripts/angular.min.js", "~/Scripts/angular-route.min"));

            bundles.Add(new ScriptBundle("~/bundles/modulos").Include(
                 "~/Ng-Controllers/Module.js"));

            bundles.Add(new ScriptBundle("~/bundles/services").Include(
                "~/Ng-Controllers/Service.js"));

            bundles.Add(new ScriptBundle("~/bundles/controllers").Include(
               "~/Ng-Controllers/Controller.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                       "~/Content/reset.css", "~/Content/layout.css", "~/Content/style.css"));


            //bundles.Add(new StyleBundle("~/Content/images").Include(
            //        "~/Content/images/logo.png"));
        }
    }
}
