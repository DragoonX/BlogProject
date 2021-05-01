using BlogProject.Shared.Entities.Abstract;
using System.Collections.Generic;

namespace BlogProject.Entities.Concrete
{
    public class Role : EntityBase, IEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<User> Users { get; set; } //Navigation Property (one to many relation)
    }
}
