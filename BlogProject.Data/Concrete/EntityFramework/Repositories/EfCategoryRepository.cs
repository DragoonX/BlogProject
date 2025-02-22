using BlogProject.Data.Abstract;
using BlogProject.Data.Concrete.EntityFramework.Contexts;
using BlogProject.Entities.Concrete;
using BlogProject.Shared.Data.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BlogProject.Data.Concrete.EntityFramework.Repositories
{
    public class EfCategoryRepository : EfEntityRepositoryBase<Category>, ICategoryRepository
    {
        public EfCategoryRepository(DbContext context) : base(context)
        {
        }

        public async Task<Category> GetById(int id)
        {
            return await BlogProjectContext.Categories.SingleOrDefaultAsync(c => c.Id == id);
        }

        private BlogProjectContext BlogProjectContext
        {
            get
            {
                return _context as BlogProjectContext;
            }
        }
    }
}
