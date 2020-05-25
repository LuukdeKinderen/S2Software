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
                                Id = reader.GetInt32(0),
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

        public ProductDTO GetById(int id)
        {
            ProductDTO product = new ProductDTO();
            try
            {
                using (SqlConnection connection = this.connection.CreateConnection())
                {
                    string Querry = string.Format("select * from Products where Id={0}", id);
                    using (SqlCommand command = new SqlCommand(Querry, connection))
                    {
                        connection.Open();
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            ProductDTO newProduct = new ProductDTO
                            {
                                Id = reader.GetInt32(0),
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
            DeleteCategorieRef(id);
            try
            {
                using (SqlConnection connection = this.connection.CreateConnection())
                {
                    string Querry = "DELETE FROM Products WHERE Id=@id";
                    using (SqlCommand command = new SqlCommand(Querry, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@id", id);
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

        private void DeleteCategorieRef(int id)
        {
            try
            {
                using (SqlConnection connection = this.connection.CreateConnection())
                {
                    string Querry = "DELETE FROM Categorie_Product WHERE ProductId=@id";
                    using (SqlCommand command = new SqlCommand(Querry, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@id", id);
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

        public void Update(ProductDTO product)
        {
            try
            {
                using (SqlConnection connection = this.connection.CreateConnection())
                {
                    string Querry = "UPDATE Products SET Titel = @titel, Prijs = @prijs, Omschrijving = @omschrijving Where Id = @id";
                    using (SqlCommand command = new SqlCommand(Querry, connection))
                    {
                        connection.Open();

                        command.Parameters.AddWithValue("@id", product.Id);
                        command.Parameters.AddWithValue("@titel", product.Titel);
                        command.Parameters.AddWithValue("@prijs", product.Prijs);
                        command.Parameters.AddWithValue("@omschrijving", product.Omschrijving);

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
