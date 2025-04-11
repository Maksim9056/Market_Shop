using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Market_Shop.Models
{
    public class Patners_type
    {
        public  long Id { get; set; }

        [Display(Name = "Тип партнера")]

        public string Patners_types { get; set; }



        [ValidateNever]
        public  virtual ICollection<Partners> Partners { get; set; } = new List<Partners>();

    }
}
