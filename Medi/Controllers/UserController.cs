using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Medi.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace Medi.Controllers
{
    [Authorize(Roles ="Admin")]
    public class UserController : Controller
    {
        ApplicationDbContext _context;

        public UserController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: User
        public ActionResult Index()
        {
            if (!isAdminUser())
            {
                return RedirectToAction("Index", "Home");
            }

            
            var users = _context.Users.ToList();

            return View(users);

        }


        public ActionResult Edit (string Id)
        {
            var user = mapToEditViewModel(_context.Users.Single(u => u.Id == Id));
            ViewBag.Name = new SelectList(_context.Roles.ToList(), "Name", "Name");

            return View(user);
        }


        public Boolean isAdminUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "Admin")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

      public EditViewModel mapToEditViewModel(ApplicationUser user)
        {
            return new EditViewModel
            {
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
               // UserRoles = user.Roles.First()
            };



        }
        
    }

}