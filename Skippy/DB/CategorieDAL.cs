using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace DB
{
    public class CategorieDAL
    {
        private DatabaseConnection connection = new DatabaseConnection();
        public void Insert(CategorieDTO categorie)
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

        public List<CategorieDTO> GetAll()
        {
            List<CategorieDTO> categories = new List<CategorieDTO>();
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
                            CategorieDTO newCategorie = new CategorieDTO
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

        public CategorieDTO FindById(int id)
        {
            CategorieDTO categorie = new CategorieDTO();
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
                            CategorieDTO newCategorie = new CategorieDTO
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
                    string Querry = string.Format("delete from Products where Id={0}", id);
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

        public void Update(CategorieDTO categorie)
        {
            try
            {
                using (SqlConnection connection = this.connection.CreateConnection())
                {
                    string Querry = "UPDATE Products SET Titel = @titel Where Id = @id";
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

        public List<int> GetProductIds(int categorieId)
        {
            List<int> productIds = new List<int>();

            try
            {
                using (SqlConnection connection = this.connection.CreateConnection())
                {
                    string Querry = string.Format("select * from Categorie_Product where CategorieId={0}", categorieId);
                    using (SqlCommand command = new SqlCommand(Querry, connection))
                    {
                        connection.Open();
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            productIds.Add(reader.GetInt32(1));
                        }
                    }
                }
            }
            catch (SqlException se)
            {
                Console.Write(se.Message);
            }
            return productIds;
        }
    }


}
