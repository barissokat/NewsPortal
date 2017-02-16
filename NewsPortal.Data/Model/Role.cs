using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Data.Model
{
    [Table("Role")]
    public class Role : BaseEntity
    {
        [Display(Name = "Rol Adı:")]
        public string RoleName { get; set; }
    }
}
