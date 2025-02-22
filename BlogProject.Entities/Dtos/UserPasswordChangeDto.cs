using System.ComponentModel.DataAnnotations;

namespace BlogProject.Entities.Dtos
{
    public class UserPasswordChangeDto
    {
        [Display(Name = "Mevcut Şifreniz")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        [MaxLength(30, ErrorMessage = "{0} alanı {1} karakterden büyük olmamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} alanı {1} karakterden küçük olmamalıdır.")]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }

        [Display(Name = "Yeni Şifreniz")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        [MaxLength(30, ErrorMessage = "{0} alanı {1} karakterden büyük olmamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} alanı {1} karakterden küçük olmamalıdır.")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Display(Name = "Yeni Şifrenizin Tekrarı")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        [MaxLength(30, ErrorMessage = "{0} alanı {1} karakterden büyük olmamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} alanı {1} karakterden küçük olmamalıdır.")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Şifreler uyuşmuyor.")]
        public string RepeatPassword { get; set; }
    }
}
