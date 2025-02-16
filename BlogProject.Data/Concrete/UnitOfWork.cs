using BlogProject.Data.Abstract;
using BlogProject.Data.Concrete.EntityFramework.Contexts;
using BlogProject.Data.Concrete.EntityFramework.Repositories;
using BlogProject.Shared.Data.Abstract;
using BlogProject.Shared.Data.Concrete.EntityFramework;
using BlogProject.Shared.Entities.Abstract;
using System;
using System.Threading.Tasks;

namespace BlogProject.Data.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BlogProjectContext _context;
        private EfArticleRepository _articleRepository; //new leme yapılacağı için readonly eklemiyoruz.
        private EfCategoryRepository _categoryRepository;
        private EfCommentRepository _commentRepository;

        public UnitOfWork(BlogProjectContext context)
        {
            _context = context;
        }

        public IArticleRepository Articles => _articleRepository ?? new EfArticleRepository(_context);

        public ICategoryRepository Categories => _categoryRepository ?? new EfCategoryRepository(_context);

        public ICommentRepository Comments => _commentRepository ?? new EfCommentRepository(_context);

        // Generic olarak bir GetRepository fonksiyonu oluşturduk.
        public IEntityRepository<T> GetRepository<T>() where T : class, IEntity, new()
        {
            return new EfEntityRepositoryBase<T>(_context);
        }

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
            GC.SuppressFinalize(this);
        }

        public int Save()
        {
            int result = 0;

            try
            {
                using var transaction = _context.Database.BeginTransaction();
                try
                {
                    result = _context.SaveChanges();
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public async Task<int> SaveAsync()
        {
            int result = 0;

            try
            {
                await using var transaction = await _context.Database.BeginTransactionAsync();
                try
                {
                    result = await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch
                {
                    await transaction.RollbackAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
    }
}
