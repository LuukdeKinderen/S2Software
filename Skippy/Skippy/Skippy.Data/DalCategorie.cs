using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using Skippy.Interface;

namespace Skippy.Data
{
    public class DalCategorie : IDalCategorie
    {
        private DatabaseConnection connection = new DatabaseConnection();
        public void Insert(DtoCategorie categorie)
        {
            try
            {
                using (SqlConnection connection = this.connection.CreateConnection())
                {
                    string Querry = "insert into Categories ( Titel ) values (@param1)";
                    using (SqlCommand command = new SqlCommand(Querry, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@param1", categorie.Titel);
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

        public List<DtoCategorie> GetAll()
        {
            List<DtoCategorie> categories = new List<DtoCategorie>();
            try
            {
                using (SqlConnection connection = this.connection.CreateConnection())
                {
                    string Querry = "select * from Categories";
                    using (SqlCommand command = new SqlCommand(Querry, connection))
                    {
                        connection.Open();
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            DtoCategorie newCategorie = new DtoCategorie
                            {
                                Id = reader.GetInt32(0),
                                Titel = reader.GetString(1),
                            };
                            categories.Add(newCategorie);
                        }
                    }
                }
            }
            catch (SqlException se)
            {
                Console.Write(se.Message);
            }
            return categories;
        }

        public DtoCategorie GetById(int id)
        {
            DtoCategorie categorie = new DtoCategorie();
            try
            {
                using (SqlConnection connection = this.connection.CreateConnection())
                {
                    string Querry = string.Format("select * from Categories where Id={0}", id);
                    using (SqlCommand command = new SqlCommand(Querry, connection))
                    {
                        connection.Open();
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            DtoCategorie newCategorie = new DtoCategorie
                            {
                                Id = reader.GetInt32(0),
                                Titel = reader.GetString(1)
                            };
                            categorie = newCategorie;
                        }
                    }
                }
            }
            catch (SqlException se)
            {
                Console.Write(se.Message);
            }
            return categorie;
        }

        public void Delete(int id)
        {
            try
            {
                using (SqlConnection connection = this.connection.CreateConnection())
                {
                    string Querry = "DELETE FROM Categories WHERE Id=@id";
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

        public void Update(DtoCategorie categorie)
        {
            try
            {
                using (SqlConnection connection = this.connection.CreateConnection())
                {
                    string Querry = "UPDATE Categories SET Titel = @titel Where Id = @id";
                    using (SqlCommand command = new SqlCommand(Querry, connection))
                    {
                        connection.Open();

                        command.Parameters.AddWithValue("@id", categorie.Id);

                        command.Parameters.AddWithValue("@titel", categorie.Titel);

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


        public List<DtoProduct> GetProductsNotInCategorie(int categorieId)
        {

            List<DtoProduct> productDTOs = new List<DtoProduct>();
            try
            {
                using (SqlConnection connection = this.connection.CreateConnection())
                {
                    string Querry = "SELECT Products.Id,Products.Titel,Products.Prijs,Products.Omschrijving FROM Products LEFT JOIN Categorie_Product ON Categorie_Product.ProductId = Products.Id AND Categorie_Product.CategorieId = @id WHERE CategorieId IS NULL ORDER BY Id";
                    using (SqlCommand command = new SqlCommand(Querry, connection))
                    {
                        connection.Open();

                        command.Parameters.AddWithValue("@id", categorieId);

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
                            productDTOs.Add(newProduct);
                        }
                    }
                }
            }
            catch (SqlException se)
            {
                Console.Write(se.Message);
            }
            return productDTOs;
        }
        public List<DtoProduct> GetProductsInCategorie(int categorieId)
        {

            List<DtoProduct> productDTOs = new List<DtoProduct>();
            try
            {
                using (SqlConnection connection = this.connection.CreateConnection())
                {
                    string Querry = "SELECT Products.Id,Products.Titel,Products.Prijs,Products.Omschrijving FROM Products LEFT JOIN Categorie_Product ON Categorie_Product.ProductId = Products.Id AND Categorie_Product.CategorieId = @id WHERE CategorieId IS NOT NULL ORDER BY Id";
                    using (SqlCommand command = new SqlCommand(Querry, connection))
                    {
                        connection.Open();

                        command.Parameters.AddWithValue("@id", categorieId);

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
                            productDTOs.Add(newProduct);
                        }
                    }
                }
            }
            catch (SqlException se)
            {
                Console.Write(se.Message);
            }
            return productDTOs;
        }

        public void AddProduct(int categorieId,int productId)
        {
            try
            {
                using (SqlConnection connection = this.connection.CreateConnection())
                {
                    string Querry = "insert into Categorie_Product ( CategorieId, ProductId ) values (@catId, @prodId)";
                    using (SqlCommand command = new SqlCommand(Querry, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@catId", categorieId);
                        command.Parameters.AddWithValue("@prodId", productId);
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

        public void RemoveProduct(int categorieId, int productId)
        {
            try
            {
                using (SqlConnection connection = this.connection.CreateConnection())
                {
                    string Querry = "DELETE FROM Categorie_Product WHERE CategorieId=@catId AND ProductId=@prodId";
                    using (SqlCommand command = new SqlCommand(Querry, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@catId", categorieId);
                        command.Parameters.AddWithValue("@prodId", productId);
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

    }
}
