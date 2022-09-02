using System;
using System.Threading.Tasks;

namespace BlogProject.Data.Abstract
{
    public interface IUnitOfWork : IAsyncDisposable //IAsyncDisposable, C# 8.0 sürümü ile ortaya çıkmıştır. İmplemente sırasında DisposeAsync() olarak çıkacaktır.
    {
        IArticleRepository Articles { get; } // Orn kullanım: _unitOfWork.Articles.AddAsync()
        ICategoryRepository Categories { get; }
        ICommentRepository Comments { get; }

        // _unitOfWork.Articles.AddAsync(article);
        // _unitOfWork.Comments.AddAsync(comment);
        // _unitOfWork.SaveAsync();
        Task<int> SaveAsync();
    }
}
