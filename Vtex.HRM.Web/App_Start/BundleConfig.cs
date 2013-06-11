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
                    bootstrap = "//cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/2.3.1/js/bootstrap.min.js",
                    underscore = "//cdnjs.cloudflare.com/ajax/libs/underscore.js/1.4.4/underscore-min.js"
                };
            
            bundles.Add(new ScriptBundle("~/bundles/jquery", cdn.jquery)
                .Include("~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/json")
                .Include("~/Scripts/json2.js")
                .Include("~/Sc"));

            bundles.Add(new ScriptBundle("~/bundles/angular", cdn.angular)
                .Include("~/Scripts/angular.js")
                .Include("~/Scripts/angular-resource.js")
                .Include("~/Scripts/angular-strap.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap", cdn.bootstrap)
                .Include("~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/underscore", cdn.underscore)
                .Include("~/Scripts/underscore.js"));

            bundles.Add(new ScriptBundle("~/bundles/services")
                .Include("~/App/services.js"));

            bundles.Add(new ScriptBundle("~/bundles/directives")
                .Include("~/App/directives.js"));

            bundles.Add(new ScriptBundle("~/bundles/filters")
                .Include("~/App/filters.js"));

            bundles.Add(new ScriptBundle("~/bundles/controllers")
                .Include("~/App/controllers.js")
                .Include("~/App/controllers/checks.js")
                .Include("~/App/controllers/analysis.js"));

            BundleTable.EnableOptimizations = false;
        }
    }
}