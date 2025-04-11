namespace Market_Shop.Models
{
    public class CostService
    {

        public double Calculate(Requst requst)
        {
            if (requst == null && requst.Partners == null)
            {
                throw new ArgumentNullException();


            }
            double cost = 0;

            if (requst.Partners != null)
            {






                cost =requst.Product.Min_cost_ * requst.Count;
                if(requst.Partners.Discount >0)
                {
                    cost = cost - (cost *requst.Partners.Discount /100);

                }

                return cost;
            }


            return cost;

        }
    }
}
