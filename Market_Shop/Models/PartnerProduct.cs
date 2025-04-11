using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Market_Shop.Models
{
    public class PartnerProduct
    {
        public long Id { get; set; }
        [Display(Name = "Patners_Type_name")]

        public long PartnersId { get; set; }

        [Display(Name = "Name_Product")]

        public long ProductId { get; set; }


        public long Count { get; set; }


        [ValidateNever]
        [ForeignKey("ProductId")]
        public  virtual  Product Product { get; set; }
        [ValidateNever]

        [ForeignKey("PartnersId")]
        public virtual Partners Partners { get; set; }
    }
}
