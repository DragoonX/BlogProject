using BlogProject.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BlogProject.Shared.Data.Abstract
{
    public interface IEntityRepository<T> where T : class, IEntity, new() //new kelimesi, sadece Concrete içindeki veritabanı nesnelerinin kullanılmasını sağlar.
    {
        // GetAsync fonksiyonu lambda fonksiyon şeklinde kullanılabilir hale getirilir. Orn: var kullanici = repository.GetAsync(x => x.Id == 2);
        // params kelimesi, parametrenin birden fazla getirilebilmesini sağlar.
        // GetAsync'da ikinci parametrede ise bir sınıfın diğer özellikleri object olarak getirilir.
        // Orn: var makale = repository.GetAsync(x => x.Id == 2, x=>x.User, x=>x.Comments);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        //GetAllAsync'da ilk parametre varsayılan olarak null getirilir. Burası null ise tüm değerler, değilse belirtilen filtredeki değerler getirilir.
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        // Any fonksiyonu, bir kaydın daha önce eklenip eklenilmediğini kontrol eder.
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        Task<int> CountAsync(Expression<Func<T, bool>> predicate);
    }
}
