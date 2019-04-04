using HelloWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloWorld.Controllers
{
    public class MetaDataHtmlHelperiController : Controller
    {
        public ViewResult MetaDataView()
        {
            return View(new OsobaMeta());
        }
        [HttpPost]
        public ViewResult MetaDataView(OsobaMeta osoba)
        {
            return View("HtmlLabelDisplay", osoba);
        }
    }
}