using System.Web;
using System.Web.Optimization;

namespace GHPWEB
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        { 

            #region JS
            bundles.Add(new ScriptBundle("~/bundles/base").Include(
                "~/Template/js/jquery.min.js",
                "~/Template/js/bootstrap.js",
                "~/Template/js/app.js",
                "~/Template/js/slimscroll/jquery.slimscroll.min.js",
                "~/Template/js/datepicker/bootstrap-datepicker.js",
                "~/Template/js/slider/bootstrap-slider.js",
                "~/Template/js/file-input/bootstrap-filestyle.min.js",
                "~/Template/js/wysiwyg/jquery.hotkeys.js",
                "~/Template/js/wysiwyg/bootstrap-wysiwyg.js",
                "~/Template/js/wysiwyg/demo.js",
               // "~/Template/js/markdown/epiceditor.min.js",
                "~/Template/js/markdown/demo.js",
                "~/Template/js/chosen/chosen.jquery.min.js",
                "~/Template/js/app.plugin.js",
                "~/Template/js/jPlayer/jquery.jplayer.min.js",
                "~/Template/js/jPlayer/add-on/jplayer.playlist.min.js"
                //"~/Template/js/jPlayer/demo.js" 
 ));

            bundles.Add(new ScriptBundle("~/bundles/Validata").Include(
              "~/Scripts/jquery-1.10.2.min.js",
              "~/Template/js/jquery.validate.min.js",
              "~/Template/js/messages_zh.js"
       

));
            #endregion

            #region CSS

            bundles.Add(new StyleBundle("~/Template/css").Include(
   
          "~/Template/js/jPlayer/jplayer.flat.css",
          "~/Template/css/bootstrap.css",
          "~/Template/css/animate.css",
          "~/Template/css/font-awesome.min.css",
          "~/Template/css/simple-line-icons.css",
          "~/Template/css/font.css",
          "~/Template/css/app.css",
          "~/Template/js/datepicker/datepicker.css",
          "~/Template/js/slider/slider.css",
          "~/Template/js/chosen/chosen.css"

          ));
            #endregion

        }
    }
}
