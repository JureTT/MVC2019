using HelloWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloWorld.Controllers
{
    public class TemplHtmlHelperiController : Controller
    {
        // GET: TemplHtmlHelperi
        public ViewResult HtmlEditorView()
        {
            return View(new Osoba());
        }

        [HttpPost]
        public ViewResult HtmlEditorView(Osoba osoba)
        {
            return View("HtmlLabelDisplay", osoba);
        }
        public ViewResult EditorModelView()
        {
            return View(new Osoba());
        }

        [HttpPost]
        public ViewResult EditorModelView(Osoba osoba)
        {
            return View("HtmlLabelDisplay", osoba);
        }
    }    
}