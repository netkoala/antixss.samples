using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Security.Application;

namespace AntiXSSSamples.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Xss(string message)
        {
            //string body = Sanitizer.GetSafeHtml("<div onload=\"alert('xss');\"><script>alert('xss')</script></div>");
            //輸出結果
            //<html>
            //<body>
            //<div></div>
            //</body>
            //</html>

            //body = Sanitizer.GetSafeHtmlFragment("<div onload=\"alert('xss');\"><script>alert('xss')</script></div>");
            //輸出結果
            //<div></div>

            ViewBag.SafeHtmlMessage = Sanitizer.GetSafeHtml(message);
            ViewBag.SafeHtmlFragmentMessage = Sanitizer.GetSafeHtmlFragment(message);

            return View("Index");
        }
    }
}