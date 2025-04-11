using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Market_Shop.Models
{
    public class Product_type
    {
        public long Id { get; set; }
        [Display(Name = "Тип продукта название")]

        public string Product_types { get; set; }

        [Display(Name = "Коэфицент")]
        public string Ratio_Product_types { get; set; }

        [ValidateNever]

        public virtual  ICollection<Product> Products { get; set;} = new HashSet<Product>();
    }
}
