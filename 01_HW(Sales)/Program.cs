using data_access_sales;
using System.Configuration;
using System.Text;

namespace _01_HW_Sales_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            SalesManager manager = new(ConfigurationManager.ConnectionStrings["ConnectionStringSalesDB"].ConnectionString);
            //1
            //manager.AddSale(new ()
            //{ 
            //    buyerID = 2, 
            //    sellerID = 2, 
            //    salesAmount = 150, 
            //    dateAmount = new DateOnly(2023, 04, 04)
            //});

            //2
            //manager.ShowAllSales(new(2023, 06, 10), new(2023, 06, 20));

            //3
            //Console.WriteLine( manager.GetLastSaleByBuyer("John", "Doe"));

            //4
            //int res = manager.DeleteSaller(1);
            //Console.WriteLine($"Deleted sellers: {res}");
            //res = manager.DeleteBuyer(1);
            //Console.WriteLine($"Deleted buyers: {res}");

            //5
            var topSeller = manager.GetSellerByAmount();
            Console.WriteLine(topSeller);
        }

    }
}