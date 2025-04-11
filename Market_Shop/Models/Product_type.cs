using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Market_Shop.Models
{
    public class Product_type
    {
        public long Id { get; set; }
        public string Product_types { get; set; }
        
        public string Ratio_Product_types { get; set; }

        [ValidateNever]

        public virtual  ICollection<Product> Products { get; set;} = new HashSet<Product>();
    }
}
