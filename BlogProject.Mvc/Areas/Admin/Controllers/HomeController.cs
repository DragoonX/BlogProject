using BlogProject.Entities.Concrete;
using BlogProject.Mvc.Areas.Admin.Models;
using BlogProject.Services.Abstract;
using BlogProject.Shared.Utilities.Results.ComplexTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BlogProject.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Editor")]
    public class HomeController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IArticleService _articleService;
        private readonly ICommentService _commentService;
        private readonly UserManager<User> _userService;

        public HomeController(ICategoryService categoryService, IArticleService articleService, ICommentService commentService, UserManager<User> userService)
        {
            _categoryService = categoryService;
            _articleService = articleService;
            _commentService = commentService;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var categoriesCountResult = await _categoryService.CountByNonDeletedAsync();
            var articlesCountResult = await _articleService.CountByNonDeletedAsync();
            var commentsCountResult = await _commentService.CountByNonDeletedAsync();
            var usersCountResult = await _userService.Users.CountAsync();
            var articlesResult = await _articleService.GetAllAsync();

            if (categoriesCountResult.ResultStatus == ResultStatus.Success
                && articlesCountResult.ResultStatus == ResultStatus.Success
                && commentsCountResult.ResultStatus == ResultStatus.Success
                && usersCountResult > -1
                && articlesResult.ResultStatus == ResultStatus.Success
                )
            {
                return View(new DashboardViewModel
                {
                    CategoriesCount = categoriesCountResult.Data,
                    ArticlesCount = articlesCountResult.Data,
                    CommentsCount = commentsCountResult.Data,
                    UsersCount = usersCountResult,
                    Articles = articlesResult.Data
                });
            }

            return NotFound();
        }
    }
}
