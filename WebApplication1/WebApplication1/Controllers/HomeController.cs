using MailChimp;
using MailChimp.Helper;
using MailChimp.Lists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Newsletter mailAddress)
        {
            var mergedVariables = new MergeVar();
            mergedVariables.Add("FNAME","KULLANICI ADI");
            mergedVariables.Add("LNAME", "KULLANICI SOYADI");

            var mc = new MailChimpManager("api key is here");

            var email = new EmailParameter()
            {
                Email = mailAddress.email
            };

            var result = mc.Subscribe("list id is here", email, mergedVariables, doubleOptIn: false, updateExisting: true);
            ViewBag.Success = true;

            return View();
        }

    }
}