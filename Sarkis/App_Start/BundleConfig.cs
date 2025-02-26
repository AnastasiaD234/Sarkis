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


               bundles.Add(new ScriptBundle("~/bundle/aos/js").Include(
                  "~/Content/aos/aos.js"));
               bundles.Add(new ScriptBundle("~/bundle/bootstrap/js").Include(
                  "~/Content/bootstrap/js/bootstrap.min.js"));
               bundles.Add(new ScriptBundle("~/bundle/glightbox/js").Include(
                  "~/Content/glightbox/js/glightbox.min.js"));
               bundles.Add(new ScriptBundle("~/bundle/isotope-layout/js").Include(
                  "~/Content/isotope-layout/isotope.pkgd.min.js"));
               bundles.Add(new ScriptBundle("~/bundles/js/js").Include(
                  "~/Content/js/main.js"));
               bundles.Add(new ScriptBundle("~/bundles/php-email-from/js").Include(
                  "~/Content/php-email-from/validate.js"));
               bundles.Add(new ScriptBundle("~/bundles/swiper/js").Include(
                  "~/Content/swiper/swiper-bundle.min.js"));

          }
        
	}
}