using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace data_access_sales
{
    public class SalesManager
    {
        private SqlConnection connection = null;
        public SalesManager(string connectionStr)
        {
            connection = new(connectionStr);
            connection.Open();
        }
        private void ShowTable(SqlDataReader reader)
        {
            // відображається назви всіх колонок таблиці
            for (int i = 0; i < reader.FieldCount; i++)
            {
                Console.Write($"{reader.GetName(i),-10}\t");
            }
            Console.WriteLine('\n' + new string('-', 100));

            // відображаємо всі значення кожного рядка
            while (reader.Read()) // go to the next row
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write($"{reader[i],-10}\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine('\n' + new string('_', 100));
        }

        // ------------ public interface
        public void AddSale(Sale sale)
        {
            string cmd = $"insert Sales values (@buyer, @seler, @salesAmount, @dateAmount);";
            SqlCommand sql = new(cmd, connection);

            sql.Parameters.AddWithValue("@buyer", sale.buyerID);
            sql.Parameters.AddWithValue("@seler", sale.sellerID);
            sql.Parameters.AddWithValue("@salesAmount", sale.salesAmount);
            sql.Parameters.AddWithValue("@dateAmount", sale.dateAmount.ToString("yyyy-MM-dd"));

            sql.ExecuteNonQuery();
        }
        private Sale GetSale(SqlDataReader reader)
        {
            return new Sale()
            {

                ID = (int)reader["ID"],
                buyerID = (int)reader["BuyerID"],
                sellerID = (int)reader["SellerID"],
                salesAmount = (decimal)reader["Sales amount"],
                dateAmount = DateOnly.Parse((string)reader["Date amount"])
            };
        }
        public IEnumerable<Sale> GetAllSales(DateOnly dateFrom, DateOnly dateTo)
        {
            string cmd = $"select * from Sales where [Date amount] BETWEEN '{dateFrom.ToString("yyyy-MM-dd")}' AND '{dateTo.ToString("yyyy-MM-dd")}';"; SqlCommand sql = new(cmd, connection);

            using var reader = sql.ExecuteReader();
            while (reader.Read())
                yield return GetSale(reader);
        }
        public IEnumerable<Sale> GetAllSales()
        {
            string cmd = "select * from Sales;";
            SqlCommand sql = new(cmd, connection);

            using var reader = sql.ExecuteReader();
            while (reader.Read())
                yield return GetSale(reader);
        }
        public void ShowAllSales()
        {
            const string cmd = "select * from Sales;";
            SqlCommand sql = new(cmd, connection);

            using var reader = sql.ExecuteReader();
            ShowTable(reader);
        }
        public void ShowAllSales(DateOnly dateFrom, DateOnly dateTo)
        {
            string cmd = $"select * from Sales where [Date amount] BETWEEN '{dateFrom.ToString("yyyy-MM-dd")}' AND '{dateTo.ToString("yyyy-MM-dd")}';";
            SqlCommand sql = new(cmd, connection);

            using var reader = sql.ExecuteReader();
            ShowTable(reader);
        }
        public Sale GetLastSaleByBuyer(string firstname, string lastname)
        {
            //string cmd = $"select top 1  ID, BuyerID, SellerID, [Sales amount],  CONVERT(varchar, [Date amount], 4) AS [Date amount]  from Sales where BuyerID = (select ID from Buyers where [First name] = '{firstname}' and[Last name] = '{lastname}')  order by[Date amount] desc;";
            //SqlCommand sql = new(cmd, connection);
            
            //using var reader = sql.ExecuteReader();
            //reader.Read();
            //return GetSale(reader);

            SqlCommand command = connection.CreateCommand();
            command.CommandText = "select top 1 " +
                "ID, BuyerID, SellerID, [Sales amount], CONVERT(varchar, [Date amount], 4) AS [Date amount]" +
                "from Sales " +
                "where BuyerID = " +
                                    "(select ID " +
                                    "from Buyers " +
                                    "where [First name] = @firstname and[Last name] = @lastname)" +
                                    "order by[Date amount] desc;";

            command.Parameters.Add("@firstname", SqlDbType.NVarChar).Value = firstname;
            //command.Parameters.AddWithValue("@firstname", firstname);
            command.Parameters.Add("@lastname", SqlDbType.NVarChar).Value = lastname;
            //command.Parameters.AddWithValue("@lastname", lastname);

            using var reader = command.ExecuteReader();
            reader.Read();
            return GetSale(reader);
        }
        public int DeleteSaller(int id)
        {
            string cmd = $"delete from Sellers where ID = {id}";
            SqlCommand sql = new(cmd, connection);

            return sql.ExecuteNonQuery();
        }
        public int DeleteBuyer(int id)
        {
            string cmd = $"delete from Buyers where ID = {id}";
            SqlCommand sql = new(cmd, connection);

            return sql.ExecuteNonQuery();
        }
        public Seller GetSellerByAmount() 
        {
            const string cmd = $"select * from Sellers where ID = (select top 1  SellerID from Sales group by SellerID order by sum([Sales amount]) desc)";
            SqlCommand sql = new(cmd, connection);

            using var reader = sql.ExecuteReader();
            reader.Read();
            return new Seller()
            {
                ID = (int)reader["ID"],
                FirstName = (string)reader["First name"],
                LastName = (string)reader["Last name"],
            };
        }
    }
}