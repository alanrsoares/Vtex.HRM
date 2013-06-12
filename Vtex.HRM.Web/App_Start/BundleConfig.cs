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
                    scripts = new
                    {
                        jquery = "//ajax.googleapis.com/ajax/libs/jquery/2.0.2/jquery.min.js",
                        angular = "//ajax.googleapis.com/ajax/libs/angularjs/1.0.6/angular.js",
                        angularStrap = "//cdnjs.cloudflare.com/ajax/libs/angular-strap/0.7.4/angular-strap.min.js",
                        bootstrap = "//cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/2.3.1/js/bootstrap.min.js",
                        underscore = "//cdnjs.cloudflare.com/ajax/libs/underscore.js/1.4.4/underscore-min.js",
                        moment = "//cdnjs.cloudflare.com/ajax/libs/moment.js/2.0.0/moment.min.js",
                        json2 = "//cdnjs.cloudflare.com/ajax/libs/json2/20121008/json2.js"
                    },
                    styles = new
                        {
                            bootstrapCombined = "//netdna.bootstrapcdn.com/twitter-bootstrap/2.3.1/css/bootstrap-combined.min.css"
                        }
                };

            bundles.Add(new StyleBundle("~/bundles/css/bootstrap-combined", cdn.styles.bootstrapCombined)
                .Include("~/Content/bootstrap.css",
                         "~/Content/bootstrap-responsive.css"));

            bundles.Add(new ScriptBundle("~/bundles/js/jquery", cdn.scripts.jquery)
                .Include("~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/js/angular", cdn.scripts.angular)
                .Include("~/Scripts/angular.js"));

            bundles.Add(new ScriptBundle("~/bundles/js/angular-extras")
                .Include("~/Scripts/angular-resource.js"));

            bundles.Add(new ScriptBundle("~/bundles/js/angular-strap", cdn.scripts.angularStrap)
                .Include("~/Scripts/angular-strap.js"));

            bundles.Add(new ScriptBundle("~/bundles/js/bootstrap", cdn.scripts.bootstrap)
                .Include("~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/js/underscore", cdn.scripts.underscore)
                .Include("~/Scripts/underscore.js"));

            bundles.Add(new ScriptBundle("~/bundles/js/moment", cdn.scripts.moment)
                .Include("~/Scripts/moment.js"));

            bundles.Add(new ScriptBundle("~/bundles/js/json2", cdn.scripts.json2)
                .Include("~/Scripts/json2.js"));

            bundles.Add(new ScriptBundle("~/bundles/js/jsonlint")
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