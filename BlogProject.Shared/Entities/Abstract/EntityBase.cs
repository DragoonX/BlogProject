using System;

namespace BlogProject.Shared.Entities.Abstract
{
    public abstract class EntityBase
    {
        public virtual int Id { get; set; }
        public virtual DateTime CreatedDate { get; set; } = DateTime.Now;
        //abstract sınıftaki bir property başka bir class içinde kullanılabilir bu nedenle virtual olarak tanımlanmalıdır.
        //başka bir class'da farklı bir değer atanacaksa "override CreatedDate { get; set; } = new DateTime(2020/01/01);" şeklinde kullanılabilir.

        public virtual DateTime ModifiedDate { get; set; }
        public virtual bool IsDeleted { get; set; } = false;
        public virtual bool IsActive { get; set; } = true;

        public virtual string CreatedByName { get; set; }
        public virtual string ModifiedByName { get; set; }

    }
}
