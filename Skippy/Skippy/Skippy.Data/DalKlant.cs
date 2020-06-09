using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using Data.Extentions;
using Skippy.Interface;

namespace Skippy.Data
{
    public class DalKlant : IDalKlant
    {
        private DatabaseConnection connection = new DatabaseConnection();
        public void Insert(DtoKlant klant)
        {
            try
            {
                using (SqlConnection connection = this.connection.CreateConnection())
                {
                    string Querry = "insert into Klant ( Naam, FactuurAdres, BezorgAdres) values(@param1,@param2,@param3)";
                    using (SqlCommand command = new SqlCommand(Querry, connection))
                    {
                        connection.Open();

                        command.Parameters.AddWithValue("@param1", klant.Naam);
                        command.Parameters.AddWithValue("@param2", klant.FactuurAdres);
                        command.Parameters.AddWithValue("@param3", klant.BezorgAdres);
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

        public List<DtoKlant> GetAll()
        {
            List<DtoKlant> klanten = new List<DtoKlant>();
            try
            {
                using (SqlConnection connection = this.connection.CreateConnection())
                {
                    string Querry = "select * from Klant";
                    using (SqlCommand command = new SqlCommand(Querry, connection))
                    {
                        connection.Open();
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            DtoKlant newKlant = new DtoKlant
                            {
                                Id = reader.GetInt32(0),
                                Naam = reader.GetString(1),
                                FactuurAdres = reader.SafeGetString(2),
                                BezorgAdres = reader.SafeGetString(3)
                            };





                            klanten.Add(newKlant);
                        }
                    }
                }
            }
            catch (SqlException se)
            {
                Console.Write(se.Message);
            }
            return klanten;
        }


        public DtoKlant GetById(int id)
        {
            DtoKlant klant = new DtoKlant();
            try
            {
                using (SqlConnection connection = this.connection.CreateConnection())
                {
                    string Querry = string.Format("select * from Klant where Id={0}", id);
                    using (SqlCommand command = new SqlCommand(Querry, connection))
                    {
                        connection.Open();
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            DtoKlant newKlant = new DtoKlant
                            {
                                Id = reader.GetInt32(0),
                                Naam = reader.GetString(1),
                                FactuurAdres = reader.SafeGetString(2),
                                BezorgAdres = reader.SafeGetString(3)
                            };
                            klant = newKlant;
                        }
                    }
                }
            }
            catch (SqlException se)
            {
                Console.Write(se.Message);
            }
            return klant;
        }

        public void Update(DtoKlant product)
        {
            try
            {
                using (SqlConnection connection = this.connection.CreateConnection())
                {
                    string Querry = "UPDATE Klant SET Naam = @naam, FactuurAdres = @facAdd, BezorgAdres = @bezAdd Where Id = @id";
                    using (SqlCommand command = new SqlCommand(Querry, connection))
                    {
                        connection.Open();

                        command.Parameters.AddWithValue("@id", product.Id);
                        command.Parameters.AddWithValue("@naam", product.Naam);
                        command.Parameters.AddWithValue("@facAdd", product.FactuurAdres);
                        command.Parameters.AddWithValue("@bezAdd", product.BezorgAdres);

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

        public List<DtoOrder> GetOrders(int klantId)
        {
            List<DtoOrder> orders = new List<DtoOrder>();
            try
            {
                using (SqlConnection connection = this.connection.CreateConnection())
                {
                    string Querry = string.Format("select * from Orders where KlantId={0}", klantId);
                    using (SqlCommand command = new SqlCommand(Querry, connection))
                    {
                        connection.Open();
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            DtoOrder newOrder = new DtoOrder
                            {
                                Id = reader.GetInt32(0),
                                Betaald = reader.GetBool(1),
                                KlantId = reader.GetInt32(2),
                                Date = reader.GetDateTime(3)
                            };
                            orders.Add(newOrder);
                        }
                    }
                }
            }
            catch (SqlException se)
            {
                Console.Write(se.Message);
            }
            return orders;
        }


    }


}
