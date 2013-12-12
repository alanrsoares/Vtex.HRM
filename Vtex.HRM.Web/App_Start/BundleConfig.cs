using System.Web.Optimization;

namespace Vtex.HRM.Web
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/css/all")
                .Include("~/Content/bootstrap.css",
                         "~/Content/bootstrap-responsive.css",
                         "~/Content/font-awesome.css",
                         "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/js/third-party-scripts")
                .Include("~/Scripts/jquery-{version}.js")
                .Include("~/Scripts/angular.js")
                .Include("~/Scripts/angular-resource.js")
                .Include("~/Scripts/angular-strap.js")
                .Include("~/Scripts/bootstrap.js")
                .Include("~/Scripts/underscore.js")
                .Include("~/Scripts/moment.js")
                .Include("~/Scripts/json2.js")
                .Include("~/Scripts/jsonlint.js"));

            bundles.Add(new ScriptBundle("~/bundles/js/app")
                // App
                .Include("~/App/app.js")
                // Services
                .Include("~/App/services.js")
                // Directives
                .Include("~/App/directives.js")
                // Filters
                .Include("~/App/filters.js")
                // Controllers
                .Include("~/App/controllers.js",
                         "~/App/controllers/checks.js",
                         "~/App/controllers/analysis.js"));
        }
    }
}