using BlogProject.Data.Abstract;
using BlogProject.Data.Concrete;
using BlogProject.Data.Concrete.EntityFramework.Contexts;
using BlogProject.Services.Abstract;
using BlogProject.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace BlogProject.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<BlogProjectContext>();
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddScoped<ICategoryService, CategoryManager>();
            serviceCollection.AddScoped<IArticleService, ArticleManager>();
            return serviceCollection;
        }
    }
}
