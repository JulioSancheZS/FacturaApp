using System.Web;
using System.Web.Optimization;

namespace FacturaApp
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
 

     

            //bundles.Add(new ScriptBundle("~/bundles/bulma").Include(
            //          "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bulma.min.css",
                      "~/Content/site.css"));
        }
    }
}
