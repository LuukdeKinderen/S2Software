using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using DB.Extentions;

namespace DB
{
    public class OrderDAL
    {
        private DatabaseConnection connection = new DatabaseConnection();
        //public void Insert(KlantDTO klant)
        //{
        //    try
        //    {
        //        using (SqlConnection connection = this.connection.CreateConnection())
        //        {
        //            string Querry = "insert into Klant ( Naam, FactuurAdres, BezorgAdres) values(@param1,@param2,@param3)";
        //            using (SqlCommand command = new SqlCommand(Querry, connection))
        //            {
        //                connection.Open();

        //                command.Parameters.AddWithValue("@param1", klant.Naam);
        //                command.Parameters.AddWithValue("@param2", klant.FactuurAdres);
        //                command.Parameters.AddWithValue("@param3", klant.BezorgAdres);
        //                command.CommandType = CommandType.Text;
        //                int rowsAdded = command.ExecuteNonQuery();
        //            }
        //        }
        //    }
        //    catch (SqlException se)
        //    {
        //        Console.Write(se.Message);
        //    }
        //}

        //public List<KlantDTO> GetAll()
        //{
        //    List<KlantDTO> klanten = new List<KlantDTO>();
        //    try
        //    {
        //        using (SqlConnection connection = this.connection.CreateConnection())
        //        {
        //            string Querry = "select * from Klant";
        //            using (SqlCommand command = new SqlCommand(Querry, connection))
        //            {
        //                connection.Open();
        //                var reader = command.ExecuteReader();
        //                while (reader.Read())
        //                {
        //                    KlantDTO newKlant = new KlantDTO
        //                    {
        //                        Id = reader.GetInt32(0),
        //                        Naam = reader.GetString(1),
        //                        FactuurAdres = reader.SafeGetString(2),
        //                        BezorgAdres = reader.SafeGetString(3)
        //                    };





        //                    klanten.Add(newKlant);
        //                }
        //            }
        //        }
        //    }
        //    catch (SqlException se)
        //    {
        //        Console.Write(se.Message);
        //    }
        //    return klanten;
        //}


        public OrderDTO GetById(int id)
        {
            OrderDTO order = new OrderDTO();
            try
            {
                using (SqlConnection connection = this.connection.CreateConnection())
                {
                    string Querry = string.Format("select * from Orders where Id={0}", id);
                    using (SqlCommand command = new SqlCommand(Querry, connection))
                    {
                        connection.Open();
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            OrderDTO newOrder = new OrderDTO
                            {
                                Id = reader.GetInt32(0),
                                Betaald = reader.GetByte(1) == 1 ? true : false,
                                KlantId = reader.SafeGetInt(2),
                                Date = reader.GetDateTime(3)
                            };
                            order = newOrder;
                        }
                    }
                }
            }
            catch (SqlException se)
            {
                Console.Write(se.Message);
            }
            return order;
        }

        public List<OrderRegelDTO> GetOrderRegels(int orderId)
        {
            List<OrderRegelDTO> orderRegels = new List<OrderRegelDTO>();
            try
            {
                using (SqlConnection connection = this.connection.CreateConnection())
                {
                    string Querry = string.Format("select * from OrderRegel where OrderId={0}", orderId);
                    using (SqlCommand command = new SqlCommand(Querry, connection))
                    {
                        connection.Open();
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            OrderRegelDTO newOrderRegel = new OrderRegelDTO
                            {
                                Aantal = reader.GetInt32(0),
                                ProductId = reader.GetInt32(2)
                            };
                            orderRegels.Add(newOrderRegel);
                        }
                    }
                }
            }
            catch (SqlException se)
            {
                Console.Write(se.Message);
            }
            return orderRegels;
        }

        public void AddOrderRegel(int orderId, OrderRegelDTO orderRegel)
        {
            try
            {
                using (SqlConnection connection = this.connection.CreateConnection())
                {
                    string Querry = "insert into OrderRegel ( Aantal, OrderId, ProductId) values(@aantal,@orderId,@prodId)";
                    using (SqlCommand command = new SqlCommand(Querry, connection))
                    {
                        connection.Open();

                        command.Parameters.AddWithValue("@aantal", orderRegel.Aantal);
                        command.Parameters.AddWithValue("@orderId", orderId);
                        command.Parameters.AddWithValue("@prodId", orderRegel.ProductId);
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

        //public void Update(KlantDTO product)
        //{
        //    try
        //    {
        //        using (SqlConnection connection = this.connection.CreateConnection())
        //        {
        //            string Querry = "UPDATE Klant SET Naam = @naam, FactuurAdres = @facAdd, BezorgAdres = @bezAdd Where Id = @id";
        //            using (SqlCommand command = new SqlCommand(Querry, connection))
        //            {
        //                connection.Open();

        //                command.Parameters.AddWithValue("@id", product.Id);
        //                command.Parameters.AddWithValue("@naam", product.Naam);
        //                command.Parameters.AddWithValue("@facAdd", product.FactuurAdres);
        //                command.Parameters.AddWithValue("@bezAdd", product.BezorgAdres);

        //                command.CommandType = CommandType.Text;
        //                command.ExecuteNonQuery();
        //            }
        //        }
        //    }
        //    catch (SqlException se)
        //    {
        //        Console.Write(se.Message);
        //    }
        //}

        //public List<OrderDTO> GetOrders(int klantId)
        //{
        //    List<OrderDTO> orders = new List<OrderDTO>();
        //    try
        //    {
        //        using (SqlConnection connection = this.connection.CreateConnection())
        //        {
        //            string Querry = string.Format("select * from Orders where KlantId={0}", klantId);
        //            using (SqlCommand command = new SqlCommand(Querry, connection))
        //            {
        //                connection.Open();
        //                var reader = command.ExecuteReader();
        //                while (reader.Read())
        //                {
        //                    OrderDTO newOrder = new OrderDTO
        //                    {
        //                        Id = reader.GetInt32(0),
        //                        Betaald = reader.GetByte(1) == 1 ? true : false,
        //                        KlantId = reader.SafeGetInt(2),
        //                        Date = reader.GetDateTime(3)
        //                    };
        //                    orders.Add(newOrder);
        //                }
        //            }
        //        }
        //    }
        //    catch (SqlException se)
        //    {
        //        Console.Write(se.Message);
        //    }
        //    return orders;
        //}


    }


}
