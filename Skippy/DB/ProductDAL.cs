using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace DB
{
    public class ProductDAL
    {
        private DatabaseConnection connection = new DatabaseConnection();
        public void Insert(ProductDTO product)
        {
            try
            {
                using (SqlConnection connection = this.connection.CreateConnection())
                {
                    string Querry = "insert into Products ( Titel, Prijs, Omschrijving) values(@param1,@param2,@param3)";
                    using (SqlCommand command = new SqlCommand(Querry, connection))
                    {
                        connection.Open();

                        command.Parameters.AddWithValue("@param1", product.Titel);
                        command.Parameters.AddWithValue("@param2", product.Prijs);
                        command.Parameters.AddWithValue("@param3", product.Omschrijving);
                        command.CommandType = CommandType.Text;
                        int rowsAdded = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException se)
            {
                Console.Write(se.Message);
            }
        }

        public List<ProductDTO> GetAll()
        {
            List<ProductDTO> products = new List<ProductDTO>();
            try
            {
                using (SqlConnection connection = this.connection.CreateConnection())
                {
                    string Querry = "select * from Products";
                    using (SqlCommand command = new SqlCommand(Querry, connection))
                    {
                        connection.Open();
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            ProductDTO newProduct = new ProductDTO
                            {
                                ProductId = reader.GetInt32(0),
                                Titel = reader.GetString(1),
                                Prijs = reader.GetDecimal(2),
                                Omschrijving = reader.GetString(3)
                            };
                            products.Add(newProduct);
                        }
                    }
                }
            }
            catch (SqlException se)
            {
                Console.Write(se.Message);
            }
            return products;
        }

        public ProductDTO FindById(int id)
        {
            ProductDTO product = new ProductDTO();
            try
            {
                using (SqlConnection connection = this.connection.CreateConnection())
                {
                    string Querry = string.Format("select * from Products where ProductId={0}", id);
                    using (SqlCommand command = new SqlCommand(Querry, connection))
                    {
                        connection.Open();
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            ProductDTO newProduct = new ProductDTO
                            {
                                ProductId = reader.GetInt32(0),
                                Titel = reader.GetString(1),
                                Prijs = reader.GetDecimal(2),
                                Omschrijving = reader.GetString(3)
                            };
                            product = newProduct;
                        }
                    }
                }
            }
            catch (SqlException se)
            {
                Console.Write(se.Message);
            }
            return product;
        }

        public void Delete(int id)
        {
            
            try
            {
                using (SqlConnection connection = this.connection.CreateConnection())
                {
                    string Querry = string.Format("delete from Products where ProductId={0}", id);
                    using (SqlCommand command = new SqlCommand(Querry, connection))
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException se)
            {
                Console.Write(se.Message);
            }
        }

        public void Edit(ProductDTO product)
        {

            try
            {
                using (SqlConnection connection = this.connection.CreateConnection())
                {
                    string Querry = string.Format("update Products ( Titel, Prijs, Omschrijving) values(@param1,@param2,@param3) where ProductId={0}", product.ProductId);
                    using (SqlCommand command = new SqlCommand(Querry, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@param1", product.Titel);
                        command.Parameters.AddWithValue("@param2", product.Prijs);
                        command.Parameters.AddWithValue("@param3", product.Omschrijving);
                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException se)
            {
                Console.Write(se.Message);
            }
        }
    }


}
