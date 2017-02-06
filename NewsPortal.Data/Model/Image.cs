using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Data.Model
{
    [Table("Image")]
    public class Image
    {
        public int ID { get; set; }

        [Display(Name = "Resim:")]
        public string Images { get; set; }

        public virtual News News { get; set; }
    }
}
