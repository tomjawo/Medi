using Medi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Medi.Views.Manage
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        public ApplicationDbContext  _context { get; set; }

        public  AdminController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

    }
}