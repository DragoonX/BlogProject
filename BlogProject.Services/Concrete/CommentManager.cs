using BlogProject.Data.Abstract;
using BlogProject.Entities.Concrete;
using BlogProject.Services.Abstract;
using BlogProject.Shared.Utilities.Results.Abstract;
using BlogProject.Shared.Utilities.Results.ComplexTypes;
using BlogProject.Shared.Utilities.Results.Concrete;
using System.Threading.Tasks;

namespace BlogProject.Services.Concrete
{
    public class CommentManager : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommentManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IDataResult<int>> Count()
        {
            int commentCount = await _unitOfWork.GetRepository<Comment>().CountAsync();
            if (commentCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, commentCount);
            }
            return new DataResult<int>(ResultStatus.Error, "Beklenmeyen bir hata ile karşılaşıldı.", -1);
        }

        public async Task<IDataResult<int>> CountByNonDeleted()
        {
            int commentCount = await _unitOfWork.GetRepository<Comment>().CountAsync(x => !x.IsDeleted);
            if (commentCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, commentCount);
            }
            return new DataResult<int>(ResultStatus.Error, "Beklenmeyen bir hata ile karşılaşıldı.", -1);
        }
    }
}
