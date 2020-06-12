using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using Skippy.Interface;

namespace Skippy.Data
{
    public class DalProduct : IDalProduct
    {
        private DatabaseConnection connection = new DatabaseConnection();
        public void Insert(DtoProduct product)
        {
            try
            {
                using (SqlConnection connection = this.connection.CreateConnection())
                {
                    string Querry = "insert into Products ( Titel, Prijs, Omschrijving) values(@titel,@prijs,@omschrijving)";
                    using (SqlCommand command = new SqlCommand(Querry, connection))
                    {
                        connection.Open();

                        command.Parameters.AddWithValue("@titel", product.Titel);
                        command.Parameters.AddWithValue("@prijs", product.Prijs);
                        command.Parameters.AddWithValue("@omschrijving", product.Omschrijving);
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

        public List<DtoProduct> GetAll()
        {
            List<DtoProduct> products = new List<DtoProduct>();
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
                            DtoProduct newProduct = new DtoProduct
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

        public DtoProduct GetById(int id)
        {
            DtoProduct product = new DtoProduct();
            try
            {
                using (SqlConnection connection = this.connection.CreateConnection())
                {
                    string Querry = "select * from Products where Id=@id"; 
                    using (SqlCommand command = new SqlCommand(Querry, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@id", id);
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            DtoProduct newProduct = new DtoProduct
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
            try
            {
                using (SqlConnection connection = this.connection.CreateConnection())
                {
                    string Querry = "DELETE FROM Categorie_Product WHERE ProductId=@id; DELETE FROM Products WHERE Id=@id";
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

        public void Update(DtoProduct product)
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
