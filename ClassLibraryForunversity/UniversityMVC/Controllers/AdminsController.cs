using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversityMVC.Areas.Identity.Data;
using UniversityMVC.Models;

namespace UniversityMVC.Controllers
{
    public class AdminsController : Controller
    {
        private readonly AdminDbContext _adminDbContext;
        public AdminsController(AdminDbContext adminDbContext)
        {
            _adminDbContext = adminDbContext;
        }

        public IActionResult Approve(Admin adminModels)
        {

            adminModels.Status = "Approved";
            adminModels.IsApproved = true;
            _adminDbContext.Admins.Update(adminModels);
            _adminDbContext.SaveChanges();
            return View("Index", adminModels);
        }
        public IActionResult Reject(Admin adminModels)
        {
            adminModels.Status = "Rejected";
            adminModels.IsApproved = true;
            _adminDbContext.Admins.Update(adminModels);
            _adminDbContext.SaveChanges();
            return View("Index", adminModels);
        }
        //[Authorize(Policy = "writeonly")]
        public IActionResult Index()
        {
            if (_adminDbContext.Admins == null)
            {
                return NotFound();
            }
            List<Admin> adminModels = new List<Admin>();
            adminModels = _adminDbContext.Admins.Where(x => x.Status == "Pending").ToList();
            if (adminModels == null)
            {
                return NotFound();
            }
            return View(adminModels);

        }
    }
}
