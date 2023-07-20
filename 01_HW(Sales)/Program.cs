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
            //DateOnly dateFrom;
            //DateOnly dateTo;
            //do
            //    Console.WriteLine("Enter date from (yyyy/MM/dd):");
            //while (!DateOnly.TryParse(Console.ReadLine().ToString(), out dateFrom));
            //do
            //    Console.WriteLine("Enter date to (yyyy/MM/dd):");
            //while (!DateOnly.TryParse(Console.ReadLine().ToString(), out dateTo));
            //manager.ShowAllSales(dateFrom, dateTo);

            //3
            //Console.WriteLine("Enter first name: ");
            //string firstname = Console.ReadLine();
            //Console.WriteLine("Enter last name: ");
            //string lasttname = Console.ReadLine();
            //Console.WriteLine(manager.GetLastSaleByBuyer(firstname, lasttname));

            //4
            //Console.WriteLine("Enter sellerID to delete: ");
            //int idSeller;
            //if (int.TryParse(Console.ReadLine(), out idSeller))
            //{
            //    int res = manager.DeleteSaller(idSeller);
            //    Console.WriteLine($"Deleted sellers: {res}");
            //}

            //Console.WriteLine("Enter buyerID to delete: ");
            //int idBuyer;
            //if (int.TryParse(Console.ReadLine(), out idBuyer))
            //{
            //    int res = manager.DeleteBuyer(idBuyer);
            //    Console.WriteLine($"Deleted buyers: {res}");
            //}

            //5
            //var topSeller = manager.GetSellerByAmount();
            //Console.WriteLine(topSeller);
        }
    }
}