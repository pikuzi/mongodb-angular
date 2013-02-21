using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Web.App_Start
{
    public class AngularBundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                //"~/Scripts/angular-bootstrap-prettify.js",
                //"~/Scripts/angular-bootstrap.js",
                //"~/Scripts/angular-cookies.js",
                //"~/Scripts/angular-loader.js",
                //"~/scripts/angular-resource.js",
                //"~/Scripts/angular-sanitize.js",
                //"~/Scripts/angular-scenario.js",
                "~/Scripts/angular.js",
                "~/Scripts/angular/controller.js"
                ));
        }
    }
}