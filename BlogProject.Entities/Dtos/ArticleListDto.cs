using BlogProject.Entities.Concrete;
using BlogProject.Shared.Entities.Abstract;
using System.Collections.Generic;

namespace BlogProject.Entities.Dtos
{
    public class ArticleListDto : DtoGetBase
    {
        public IList<Article> Articles { get; set; }
    }
}
