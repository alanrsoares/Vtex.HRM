using System.Web;
using System.Web.Optimization;

namespace Vtex.HRM.Web
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            var cdn = new
                {
                    jquery = "//ajax.googleapis.com/ajax/libs/jquery/2.0.2/jquery.min.js",
                    angular = "//ajax.googleapis.com/ajax/libs/angularjs/1.0.6/angular.js",
                    angularStrap = "//cdnjs.cloudflare.com/ajax/libs/angular-strap/0.7.4/angular-strap.min.js",
                    bootstrap = "//cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/2.3.1/js/bootstrap.min.js",
                    underscore = "//cdnjs.cloudflare.com/ajax/libs/underscore.js/1.4.4/underscore-min.js",
                    moment = "//cdnjs.cloudflare.com/ajax/libs/moment.js/2.0.0/moment.min.js"
                };

            bundles.Add(new ScriptBundle("~/bundles/jquery", cdn.jquery)
                .Include("~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular", cdn.angular)
                .Include("~/Scripts/angular.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular-extras")
                .Include("~/Scripts/angular-resource.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular-strap", cdn.angularStrap)
                .Include("~/Scripts/angular-strap.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap", cdn.bootstrap)
                .Include("~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/underscore", cdn.underscore)
                .Include("~/Scripts/underscore.js"));

            bundles.Add(new ScriptBundle("~/bundles/moment", cdn.moment)
                .Include("~/Scripts/moment.js"));

            bundles.Add(new ScriptBundle("~/bundles/json")
                .Include("~/Scripts/json2.js",
                        "~/Scripts/jsonlint.js"));

            bundles.Add(new ScriptBundle("~/bundles/app")
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