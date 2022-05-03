using BlogProject.Entities.Concrete;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BlogProject.Entities.Dtos
{
    public class ArticleAddDto
    {
        [DisplayName("Başlık")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        [MaxLength(100, ErrorMessage = "{0} alanı {1} karakterden fazla olmamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} alanı {1} karakterden az olmamalıdır.")]
        public string Title { get; set; }

        [DisplayName("İçerik")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        [MinLength(20, ErrorMessage = "{0} alanı {1} karakterden az olmamalıdır.")]
        public string Content { get; set; }

        [DisplayName("Thumbnail")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        [MaxLength(250, ErrorMessage = "{0} alanı {1} karakterden fazla olmamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} alanı {1} karakterden az olmamalıdır.")]
        public string Thumbnail { get; set; }

        [DisplayName("Tarih")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }

        [DisplayName("Seo Yazar")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        [MaxLength(50, ErrorMessage = "{0} alanı {1} karakterden fazla olmamalıdır.")]
        [MinLength(0, ErrorMessage = "{0} alanı {1} karakterden az olmamalıdır.")]
        public string SeoAuthor { get; set; }

        [DisplayName("Seo Açıklama")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        [MaxLength(150, ErrorMessage = "{0} alanı {1} karakterden fazla olmamalıdır.")]
        [MinLength(0, ErrorMessage = "{0} alanı {1} karakterden az olmamalıdır.")]
        public string SeoDescription { get; set; }

        [DisplayName("Seo Etiketler")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        [MaxLength(70, ErrorMessage = "{0} alanı {1} karakterden fazla olmamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} alanı {1} karakterden az olmamalıdır.")]
        public string SeoTags { get; set; }

        [DisplayName("Kategori")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [DisplayName("Aktif mi?")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        public bool IsActive { get; set; }

        [DisplayName("Silinsin mi?")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        public bool IsDeleted { get; set; }
    }
}
