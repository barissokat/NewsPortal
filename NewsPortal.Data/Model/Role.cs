using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Data.Model
{
    public class Role
    {
        public int ID { get; set; }
        [Display(Name = "Rol Adı:")]
        public string RoleName { get; set; }
    }
}
