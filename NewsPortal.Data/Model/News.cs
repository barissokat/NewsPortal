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
    public class News
    {
        public int ID { get; set; }

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

        [Display(Name = "Aktiflik:")]
        public bool Active { get; set; }

        [Display(Name = "Yüklenme Tarihi:")]
        public DateTime UploadDate { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Image> Images { get; set; }
    }
}
