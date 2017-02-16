using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Data.Model
{
    public class BaseEntity
    {
        private DateTime date = DateTime.Now;
        private bool active = true;

        public int ID { get; set; }

        [Display(Name = "Yüklenme Tarihi:")]
        public DateTime UploadDate { get { return date; } set { date = value; } }

        [Display(Name = "Aktiflik:")]
        public bool Active { get { return active; } set { active = value; } }
    }
}
