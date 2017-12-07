using Medi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;


namespace Medi.Controllers
{
    public class ExaminationController : Controller
    {
        public ApplicationDbContext _context { get; set; }
        // GET: Examination

        public ExaminationController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize(Roles ="Admin , Patient")]
        public ActionResult Index()
        {
            _context.Configuration.ProxyCreationEnabled = false;
            ExaminationViewModel data = new ExaminationViewModel()
            {
                Exam = _context.Exams.Single(),
                Users = _context.Users.ToList()
            };

            var currentUserId = User.Identity.GetUserId();
            List<Examination> exams = _context.Exams.Where(u => u.User.Id == currentUserId).ToList();
                



            ViewBag.Message = "Nie masz żadnych badań, Gratulacje!";
            return View(exams);
        }

        //GET
       // [Authorize(Roles ="Medical")]
        public ActionResult Create()
        {
            _context.Configuration.ProxyCreationEnabled = false;
            ExaminationViewModel y = new ExaminationViewModel
            {
                
                Users = _context.Users.ToList()
            };

            return View(y);
        }



    }
}