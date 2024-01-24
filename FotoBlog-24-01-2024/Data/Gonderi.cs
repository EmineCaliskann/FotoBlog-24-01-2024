using System.ComponentModel.DataAnnotations;

namespace FotoBlog_24_01_2024.Data
{
    public class Gonderi
    {
        public int Id { get; set; }

        [Display(Name = "Başlık")]
        [Required(ErrorMessage = "{0} girilmesi zorunludur!")]
        public string Baslik { get; set; } = null!;


        [MaxLength(255)]
        [Display(Name = "ResimYolu")]
        [Required(ErrorMessage = "{0} girilmesi zorunludur")]
        public string ResimYolu { get; set; } = null!;
    }
}
