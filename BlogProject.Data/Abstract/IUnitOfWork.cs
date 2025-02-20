using BlogProject.Shared.Data.Abstract;
using BlogProject.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Data.Abstract
{
    public interface IUnitOfWork : IAsyncDisposable //IAsyncDisposable, C# 8.0 sürümü ile ortaya çıkmıştır. İmplemente sırasında DisposeAsync() olarak çıkacaktır.
    {
        Task<int> SaveAsync();

        IEntityRepository<T> GetRepository<T>() where T : class, IEntity, new(); // Generic olarak bir GetRepository fonksiyonu oluşturduk.
        IQueryable<T> QueryableRepository<T>() where T : class, IEntity, new();
        IEnumerable<T> ExecuteSql<T>(string sql) where T : class, IEntity, new();
    }
}
