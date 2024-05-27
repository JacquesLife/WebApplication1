using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace WebApplication1.Models
{
    public class ProductDisplay
    {
        private readonly string _con_string;

        public ProductDisplay(IConfiguration configuration)
        {
            _con_string = configuration.GetConnectionString("MyDatabaseConnection");
        }

        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductCategory { get; set; }
        public bool ProductAvailability { get; set; }

        public ProductDisplay() { }

        public ProductDisplay(int id, string name, decimal price, string category, bool availability)
        {
            ProductID = id;
            ProductName = name;
            ProductPrice = price;
            ProductCategory = category;
            ProductAvailability = availability;
        }

        public List<ProductDisplay> SelectProducts()
        {
            List<ProductDisplay> products = new List<ProductDisplay>();

            using (SqlConnection con = new SqlConnection(_con_string))
            {
                string sql = "SELECT productID, productName, productPrice, productCategory, productAvailability FROM productTable";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductDisplay product = new ProductDisplay
                    {
                        ProductID = Convert.ToInt32(reader["productID"]),
                        ProductName = Convert.ToString(reader["productName"]),
                        ProductPrice = Convert.ToDecimal(reader["productPrice"]),
                        ProductCategory = Convert.ToString(reader["productCategory"]),
                        ProductAvailability = Convert.ToBoolean(reader["productAvailability"])
                    };
                    products.Add(product);
                }
                reader.Close();
            }
            return products;
        }
    }
}