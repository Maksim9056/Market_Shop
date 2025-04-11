using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Market_Shop.Models
{
    public class Product
    {
        [Key]
        public long Id { get; set; }


        [Display(Name = "Product_types")]

        public long Product_typeId { get; set; }
        public string Name_Product { get; set; }

        public long Артикул { get; set; }


        //[UIHint("String")]
        public double Min_cost_  {get;set;}

        [ValidateNever]
        [ForeignKey("Product_typeId")]
        public virtual Product_type Product_type { get; set; }

        [ValidateNever]
        public virtual ICollection<PartnerProduct> PartnerProducts { get; set; } = new HashSet<PartnerProduct>();
        [ValidateNever]
        public virtual ICollection<Requst> Requst { get; set; } = new HashSet<Requst>();

    }
}
