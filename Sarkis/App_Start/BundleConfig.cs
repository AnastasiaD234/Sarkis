using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;


namespace Sarkis.Web

{
	public class BundleConfig
	{
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new StyleBundle("~/bundles/style/css").Include(
                    "~/Content/css/style.css", new CssRewriteUrlTransform()));
               bundles.Add(new StyleBundle("~/bundles/animate/css").Include(
                    "~/Content/animate/animate.min.css", new CssRewriteUrlTransform()));
               bundles.Add(new StyleBundle("~/bundles/aos/css").Include(
                "~/Content/aos/aos.css", new CssRewriteUrlTransform()));
               bundles.Add(new StyleBundle("~/bundles/bootstrap/css").Include(
                "~/Content/bootstrap/css/bootstrap.min.css", new CssRewriteUrlTransform()));
               bundles.Add(new StyleBundle("~/bundles/bootstrap-icons/css").Include(
                "~/Content/bootstrap-icons/bootstrap-icons.css", new CssRewriteUrlTransform()));
               bundles.Add(new StyleBundle("~/bundles/boxicons/css").Include(
                "~/Content/boxicons/css/boxicons.min.css", new CssRewriteUrlTransform()));
               bundles.Add(new StyleBundle("~/bundles/glightbox/css").Include(
                "~/Content/glightbox/css/glightbox.min.css", new CssRewriteUrlTransform()));
               bundles.Add(new StyleBundle("~/bundles/swiper/css").Include(
                  "~/Content/swiper/swiper-bundle.min.css", new CssRewriteUrlTransform()));
               bundles.Add(new StyleBundle("~/bundles/meniu/css").Include(
             "~/Content/css/stylemenu.css", new CssRewriteUrlTransform()));
               bundles.Add(new StyleBundle("~/bundles/auth/css").Include(
             "~/Content/css/authetification_style.css", new CssRewriteUrlTransform()));
               bundles.Add(new StyleBundle("~/bundles/profile/css").Include(
           "~/Content/css/profilestyle.css", new CssRewriteUrlTransform()));






               bundles.Add(new ScriptBundle("~/bundle/aos/js").Include(
                  "~/Scripts/aos.js"));
               bundles.Add(new ScriptBundle("~/bundle/bootstrap/js").Include(
                  "~/Scripts/bootstrap.min.js"));
               bundles.Add(new ScriptBundle("~/bundle/glightbox/js").Include(
                  "~/Scripts/glightbox.min.js"));
               bundles.Add(new ScriptBundle("~/bundle/isotope-layout/js").Include(
                  "~/Scripts/isotope.pkgd.min.js"));
               bundles.Add(new ScriptBundle("~/bundle/js/js").Include(
                  "~/Scripts/main.js"));
               bundles.Add(new ScriptBundle("~/bundle/php-email-from/js").Include(
                  "~/Scripts/validate.js"));
               bundles.Add(new ScriptBundle("~/bundle/swiper/js").Include(
                  "~/Scripts/swiper-bundle.min.js"));
            
               bundles.Add(new ScriptBundle("~/bundle/scriptmeniu/js").Include(
               "~/Scripts/scriptmeniu.js"));
               bundles.Add(new ScriptBundle("~/bundle/auth/js").Include(
          "~/Scripts/authetification_style.js"));


          }

     }
}