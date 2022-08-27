using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace UniversityMVC.Controllers
{
    public class RoleController : Controller
    {
        public class RoleManagerController : Controller
        {
            private readonly RoleManager<IdentityRole> _manager;
            public RoleManagerController(RoleManager<IdentityRole> manager)
            {
                _manager = manager;
            }
        }
    }
}
