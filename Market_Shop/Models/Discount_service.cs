using System.Security.Cryptography.X509Certificates;

namespace Market_Shop.Models
{
    public class Discount_service
    {
        public long Calculate(Partners partners)
        {
            
            if (partners == null && partners.PartnerProducts ==null)
            {
                throw new ArgumentNullException();

            }


            long cost = 0;


            for(int i = 0; i < partners.PartnerProducts.Count;i++)
            {

                cost += partners.PartnerProducts.ElementAt(i).Count;
            }
         

            if (cost < 10000)
            {
                return 0;
            }
            else if (cost <= 10000 && cost <50000 )
            {
                return 5;
            }
            else if(cost <=50000 && cost < 300000)
            {
                return 10;
            }
            else
            {
                return 15;
            }



            //return decimal.Zero;
        }
    }
}
