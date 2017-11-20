using Medi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


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

            ExaminationViewModel data = new ExaminationViewModel()
            {
                Exam = _context.Exams.Single(),
                Users = _context.Users.ToList()
            };

            ViewBag.Message = "Nie masz żadnych badań, Gratulacje!";
            return View(data);
        }

        //GET
       // [Authorize(Roles ="Medical")]
        public ActionResult Create()
        {

            ExaminationViewModel y = new ExaminationViewModel
            {
                Exam = _context.Exams.Single(),
                Users = _context.Users.ToList()
            };

            return View(y);
        }



    }
}