using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Market_Shop.Models
{
    public class Requst
    {
        public long Id { get; set; }

        [Display(Name = "Name_Product")]
        public long  ProductionId { get; set; }
        [Display(Name = "Patners_Type_name")]

        public long PartnersId { get; set; }

        [Display(Name = "FullName")]

        public long ManagerId { get; set; }

        public long  Count { get; set; }

        [NotMapped]
        public double Price 
        {
            get 
            { 


              CostService  cost = new CostService();

              return cost.Calculate(this);

            }
        }


        public  string Date { get; set; }


        public  string Status { get; set; }


        [ForeignKey("ManagerId")]
        [ValidateNever]
        public virtual Manager Managers { get; set; }

        [ForeignKey("PartnersId")]
        [ValidateNever]
        public virtual Partners Partners { get; set; }

        [ForeignKey("ProductionId")]

        [ValidateNever]
        public virtual Product Product { get; set; }    
    }
}
