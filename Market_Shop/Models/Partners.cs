using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Market_Shop.Models
{
    [DisplayName("Patners_types")]
    public class Partners
    {
        [Display(Name = "Код")]

        public long Id { get; set; }
        [Display(Name = "Тип продуктов")]
        public long Patners_Type_id { get; set; }
        [Display(Name = "Название партнера")]

        public string Patners_Type_name { get; set; }
        [Display(Name = "Директор")]

        public string Director { get; set; }

        [Display(Name ="Почта")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name ="Телефон")]
        [Phone]
        public string Phone { get; set; }

        [Display(Name ="Адрес партнера")]
        public string Addres_Partners { get; set; }

        [Display(Name = "Скидка партнера")]

        [NotMapped]
        public long Discount
        {
            get
            {

                Discount_service discount_Service = new Discount_service();

                return discount_Service.Calculate(this);

            }
        }
        [Display(Name = "ИНН")]

        public string INN { get; set; }
        [Display(Name = "Рейтинг")]

        public long Rate { get; set; }

        [Display(Name = "Тип продуктов")]

        [ForeignKey("Patners_Type_id")]
        [ValidateNever]
        public virtual Patners_type Patners_Type { get; set; }


        [ValidateNever]
        public virtual ICollection<PartnerProduct> PartnerProducts { get; set; } = new HashSet<PartnerProduct>();
        [ValidateNever]
        public virtual ICollection<Requst> Requst { get; set; } = new HashSet<Requst>();

    }
}
