using FotoBlog_24_01_2024.Attributes;
using System.ComponentModel.DataAnnotations;

namespace FotoBlog_24_01_2024.Models
{
    public class YeniGonderiViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Başlık")]
        [Required(ErrorMessage = "{0} girilmesi zorunludur!")]
        public string Baslik { get; set; } = null!;


        [Display(Name = "ResimYolu")]
        [Required(ErrorMessage = "{0} koyulması zorunludur!")]
        [GecerliResim(MaxDosyaBoyutuMb =1.2)]
        public IFormFile Resim { get; set; } = null!;
    }
}
