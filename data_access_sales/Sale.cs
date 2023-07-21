using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access_sales
{
    public class Sale
    {
        public int ID { get; set; }
        public int? buyerID { get; set; }
        public int? sellerID { get; set; }
        public decimal salesAmount { get; set; }
        public DateOnly dateAmount { get; set; }
        public Sale(int buyerID, int sellerID, decimal salesAmount, DateOnly dateAmount)
        {
            this.buyerID = buyerID;
            this.sellerID = sellerID;
            this.salesAmount = salesAmount;
            this.dateAmount = dateAmount;
        }
        public Sale() { }
        public override string ToString()
        {
            return $"{buyerID}, {sellerID}, {salesAmount}$, {dateAmount}";
        }
    }
}
