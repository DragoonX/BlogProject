using BlogProject.Entities.Concrete;
using BlogProject.Entities.Dtos;
using BlogProject.Shared.Utilities.Results.ComplexTypes;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BlogProject.Mvc.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;

        public UserController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [Area("Admin")]
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            return View(new UserListDto
            {
                Users = users,
                ResultStatus = ResultStatus.Success
            });
        }
    }
}
