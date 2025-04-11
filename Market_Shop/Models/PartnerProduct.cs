using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Market_Shop.Models
{
    public class PartnerProduct
    {
        public long Id { get; set; }
        [Display(Name = "Название партнера")]

        public long PartnersId { get; set; }

        [Display(Name = "Название продукта")]

        public long ProductId { get; set; }

        [Display(Name = "Количество")]

        public long Count { get; set; }

        [Display(Name = "Название продукта")]

        [ValidateNever]
        [ForeignKey("ProductId")]
        public  virtual  Product Product { get; set; }
        [ValidateNever]
        [Display(Name = "Название партнера")]

        [ForeignKey("PartnersId")]
        public virtual Partners Partners { get; set; }
    }
}
