using System.Web;
using System.Web.Optimization;

namespace CLIMB
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/themes/rs-theme/css").Include(
                        "~/Content/themes/rs-theme/jquery.ui.core.css",
                        "~/Content/themes/rs-theme/jquery.ui.resizable.css",
                        "~/Content/themes/rs-theme/jquery.ui.selectable.css",
                        "~/Content/themes/rs-theme/jquery.ui.accordion.css",
                        "~/Content/themes/rs-theme/jquery.ui.autocomplete.css",
                        "~/Content/themes/rs-theme/jquery.ui.button.css",
                        "~/Content/themes/rs-theme/jquery.ui.dialog.css",
                        "~/Content/themes/rs-theme/jquery.ui.slider.css",
                        "~/Content/themes/rs-theme/jquery.ui.tabs.css",
                        "~/Content/themes/rs-theme/jquery.ui.datepicker.css",
                        "~/Content/themes/rs-theme/jquery.ui.progressbar.css",
                        "~/Content/themes/rs-theme/jquery.ui.theme.css"));
        }
    }
}