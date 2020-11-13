using PhoneStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class PhonesController : Controller
    {
        private ApplicationDbContext _context;

        public PhonesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Phones
        [AllowAnonymous]
        public ActionResult Index()
        {
            PhoneViewModel phoneViewModel = new PhoneViewModel
            {
                Manufacturers = _context.Manufacturers,
                Colors = _context.Colors,
                Materials = _context.Materials,
                Models = _context.Models,
                OperatingSystems = _context.OperatingSystems
            };

            return View("Index", phoneViewModel);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            if (id < 0)
            {
                return HttpNotFound();
            }
            Phone phone = _context.Phones.FirstOrDefault(c => c.Id == id);

            if (phone != null)
            {
                _context.Phones.Remove(phone);
                _context.SaveChanges();
                return RedirectToAction("Index", "Phones");
            }
            return RedirectToAction("Index", "Phones");
        }






    }
}