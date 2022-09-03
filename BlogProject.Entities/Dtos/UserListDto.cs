using BlogProject.Entities.Concrete;
using BlogProject.Shared.Entities.Abstract;
using System.Collections.Generic;

namespace BlogProject.Entities.Dtos
{
    public class UserListDto : DtoGetBase
    {
        public IList<User> Users { get; set; }
    }
}
