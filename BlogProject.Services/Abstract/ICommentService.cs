using BlogProject.Shared.Utilities.Results.Abstract;
using System.Threading.Tasks;

namespace BlogProject.Services.Abstract
{
    public interface ICommentService
    {
        Task<IDataResult<int>> CountAsync();
        Task<IDataResult<int>> CountByNonDeletedAsync();
    }
}
