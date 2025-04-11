using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Market_Shop.Models
{
    public class Product
    {
        [Key]
        public long Id { get; set; }


        [Display(Name = "Тип продукта")]

        public long Product_typeId { get; set; }
        [Display(Name = "Название продукта")]

        public string Name_Product { get; set; }
        [Display(Name = "Артикул")]

        public long Артикул { get; set; }


        //[UIHint("String")]
        [Display(Name = "Минимальная ценна")]

        public double Min_cost_  {get;set;}
        [Display(Name = "Тип продукта")]

        [ValidateNever]
        [ForeignKey("Product_typeId")]
        public virtual Product_type Product_type { get; set; }

        [ValidateNever]
        public virtual ICollection<PartnerProduct> PartnerProducts { get; set; } = new HashSet<PartnerProduct>();
        [ValidateNever]
        public virtual ICollection<Requst> Requst { get; set; } = new HashSet<Requst>();

    }
}
