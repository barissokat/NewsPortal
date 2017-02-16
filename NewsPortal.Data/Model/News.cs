using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Data.Model
{
    [Table("News")]
    public class News : BaseEntity
    {
        [Display(Name = "Haber Başlığı:")]
        [MaxLength(255,ErrorMessage = "Haber başlığını çok uzun girdiniz.")]
        [Required]
        public string Title { get; set; }

        [Display(Name = "Haber Özeti:")]
        public string Summary { get; set; }

        [Display(Name = "Haber İçeriği:")]
        public string Content { get; set; }

        [Display(Name = "Okunma Sayısı:")]
        public int ReadCount { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Image> Image { get; set; }

        public virtual Category Category { get; set; }
    }
}
