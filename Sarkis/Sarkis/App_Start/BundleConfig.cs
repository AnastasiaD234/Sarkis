using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Sarkis.App_Start
{
	public class BundleConfig
	{
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new StyleBundle("~/bundles/style/css").Include(
				"~/Content/css/style.css", new CssRewriteUrlTransform()));
               bundles.Add(new StyleBundle("~/bundles/style/css").Include(
                "~/Content/css/style.css", new CssRewriteUrlTransform()));
               bundles.Add(new StyleBundle("~/bundles/style/css").Include(
               "~/Content/css/style.css", new CssRewriteUrlTransform()));
               bundles.Add(new StyleBundle("~/bundles/style/css").Include(
     "~/Content/css/style.css", new CssRewriteUrlTransform()));
               bundles.Add(new StyleBundle("~/bundles/style/css").Include(
     "~/Content/css/style.css", new CssRewriteUrlTransform()));
               bundles.Add(new StyleBundle("~/bundles/style/css").Include(
     "~/Content/css/style.css", new CssRewriteUrlTransform()));
               bundles.Add(new StyleBundle("~/bundles/style/css").Include(
     "~/Content/css/style.css", new CssRewriteUrlTransform()));



               bundles.Add(new ScriptBundle("~/bundles/style/css").Include(
     "~/Content/css/style.js");
          }
	}
}