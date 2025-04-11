using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Market_Shop.Models
{
    [DisplayName("Patners_types")]
    public class Partners
    {
        public long Id { get; set; }
        [Display(Name = "Patners_types")]
        public long Patners_Type_id { get; set; }

        public string Patners_Type_name { get; set; }
        public string Director { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }

        public string Addres_Partners { get; set; }


        [NotMapped]
        public long Discount
        {
            get
            {

                Discount_service discount_Service = new Discount_service();

                return discount_Service.Calculate(this);

            }
        }

        public string INN { get; set; }
        public long Rate { get; set; }


        [ForeignKey("Patners_Type_id")]
        [ValidateNever]
        public virtual Patners_type Patners_Type { get; set; }


        [ValidateNever]
        public virtual ICollection<PartnerProduct> PartnerProducts { get; set; } = new HashSet<PartnerProduct>();
        [ValidateNever]
        public virtual ICollection<Requst> Requst { get; set; } = new HashSet<Requst>();

    }
}
