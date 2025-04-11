using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Market_Shop.Models
{
    public class Manager
    {
        [Key]
        public long Id { get; set; }


        [Display(Name = "Полное ФИО")]
        public string FullName { get; set; }
        [Display(Name = "Телефон или  почта")]

        public string Contact { get; set; }
        [Display(Name = "Пароль")]

        public string Password { get; set; }

        //[ValidateNever]
        //public virtual ICollection<Frames> Frames { get; set; } = new HashSet<Frames>();

        [ValidateNever]

        public virtual ICollection<Requst> Requst { get; set; } = new HashSet<Requst>();

    }
}
