using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Data.Model
{
    [Table("Category")]
    public class Category
    {
        public int ID { get; set; }

        [MinLength(2, ErrorMessage = "{0} karakterden az olamaz."), MaxLength(150, ErrorMessage = "150 karakterden çok olamaz.")]
        public string Name { get; set; }

        public int ParentId { get; set; }

        [MinLength(2, ErrorMessage = "{0} karakterden az olamaz."), MaxLength(150, ErrorMessage = "150 karakterden çok olamaz.")]
        public string Url { get; set; }

        public bool Active { get; set; }

        public virtual ICollection<News> News { get; set; }
    }
}
