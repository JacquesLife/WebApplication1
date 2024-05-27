using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace WebApplication1.Models
{

    public class ProductTable
    {
        private readonly IConfiguration _configuration;

        public ProductTable()
        {
        }

        public ProductTable(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Price { get; set;}
        public string Category { get; set; }
        public string Availability { get; set; }

        public int InsertProduct(ProductTable product)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("MyDatabaseConnection")))
                {
                    string sql = "INSERT INTO productTable (productName, productPrice, productCategory, productAvailability) VALUES (@Name, @Price, @Category, @Availability)";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@Name", product.Name);
                        cmd.Parameters.AddWithValue("@Price", product.Price);
                        cmd.Parameters.AddWithValue("@Category", product.Category);
                        cmd.Parameters.AddWithValue("@Availability", product.Availability);
                        con.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
    }

    public List<ProductTable> GetAllProducts()
            {
                List<ProductTable> products = new List<ProductTable>();
                using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("MyDatabaseConnection")))
                {
                    con.Open();
                    string sql = "SELECT * FROM productTable";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ProductTable product = new ProductTable(_configuration)
                                {
                                    ProductID = Convert.ToInt32(reader["productID"]),
                                    Name = reader["productName"].ToString(),
                                    Price = reader["productPrice"].ToString(),
                                    Category = reader["productCategory"].ToString(),
                                    Availability = reader["productAvailability"].ToString()
                                };
                                products.Add(product);
                            }
                        }
                    }
                }
                return products;
            }
        }
    }