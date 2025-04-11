using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Market_Shop.Models
{
    public class Requst
    {
        public long Id { get; set; }

        [Display(Name = "Продукт")]
        public long  ProductionId { get; set; }
        [Display(Name = "Партнер")]

        public long PartnersId { get; set; }

        [Display(Name = "Менеджер")]

        public long ManagerId { get; set; }
        [Display(Name = "Количество")]

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

        [Display(Name = "Дата")]

        public string Date { get; set; }

        [Display(Name = "Статус")]

        public string Status { get; set; }


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
