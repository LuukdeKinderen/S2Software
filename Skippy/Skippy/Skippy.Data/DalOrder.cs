using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using Data.Extentions;
using Skippy.Interface;

namespace Skippy.Data
{
    public class DalOrder : IDalOrder
    {
        private DatabaseConnection connection = new DatabaseConnection();

        public int Insert()
        {
            int id = -1;
            try
            {
                using (SqlConnection connection = this.connection.CreateConnection())
                {
                    string Querry = "INSERT INTO Orders (Betaald, date) VALUES(@betaald,@date) SELECT @NewId = SCOPE_IDENTITY()";
                    using (SqlCommand command = new SqlCommand(Querry, connection))
                    {
                        connection.Open();

                        command.Parameters.AddWithValue("@betaald", false);
                        command.Parameters.AddWithValue("@date", DateTime.Now);
                        command.Parameters.Add("@NewId", SqlDbType.Int).Direction = ParameterDirection.Output;
                        //command.CommandType = CommandType.Text;

                        command.ExecuteNonQuery();
                        id = Convert.ToInt32(command.Parameters["@NewId"].Value);
                    }
                }
            }
            catch (SqlException se)
            {
                Console.Write(se.Message);
            }
            return id;
        }

        public DtoOrder GetById(int id)
        {
            DtoOrder order = new DtoOrder();
            try
            {
                using (SqlConnection connection = this.connection.CreateConnection())
                {
                    string Querry = "select * from Orders where Id=@id";
                    using (SqlCommand command = new SqlCommand(Querry, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@id", id);
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            DtoOrder newOrder = new DtoOrder
                            {
                                Id = reader.GetInt32(0),
                                Betaald = reader.GetBool(1),
                                Date = reader.GetDateTime(3)
                            };
                            if (!reader.IsDBNull(2))
                            {
                                newOrder.KlantId = reader.GetInt32(2);
                            }
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

        public List<DtoOrder> GetAll()
        {
            DeleteAllEmpty();
            List<DtoOrder> orders = new List<DtoOrder>();
            try
            {
                using (SqlConnection connection = this.connection.CreateConnection())
                {
                    string Querry = string.Format("select * from Orders ORDER BY Id DESC");
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
                                Date = reader.GetDateTime(3)
                            };
                            if (!reader.IsDBNull(2))
                            {
                                newOrder.KlantId = reader.GetInt32(2);
                            }
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
        private void DeleteAllEmpty()
        {
            try
            {
                using (SqlConnection connection = this.connection.CreateConnection())
                {
                    string Querry = "DELETE Orders FROM Orders LEFT JOIN OrderRegel ON Orders.Id = OrderRegel.OrderId WHERE OrderRegel.OrderId IS NULL";
                    using (SqlCommand command = new SqlCommand(Querry, connection))
                    {
                        connection.Open();
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


        public List<DtoOrderRegel> GetOrderRegels(int orderId)
        {
            List<DtoOrderRegel> orderRegels = new List<DtoOrderRegel>();
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
                            DtoOrderRegel newOrderRegel = new DtoOrderRegel
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

        public void AddOrderRegel(int orderId, DtoOrderRegel orderRegel)
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

        public void UpdateOrderRegel(int orderId, DtoOrderRegel orderRegel)
        {
            try
            {
                using (SqlConnection connection = this.connection.CreateConnection())
                {
                    string Querry = "UPDATE OrderRegel SET Aantal = @aantal WHERE OrderId = @orderId AND ProductId = @prodId";
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

        public void DeleteOrderRegel(int orderId, DtoOrderRegel orderRegel)
        {
            try
            {
                using (SqlConnection connection = this.connection.CreateConnection())
                {
                    string Querry = "Delete from OrderRegel WHERE OrderId = @orderId AND ProductId = @prodId";
                    using (SqlCommand command = new SqlCommand(Querry, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@orderId", orderId);
                        command.Parameters.AddWithValue("@prodId", orderRegel.ProductId);
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



        public void Delete(int id)
        {
            DeleteAllOrderRegels(id);

            try
            {
                using (SqlConnection connection = this.connection.CreateConnection())
                {
                    string Querry = "Delete from Orders WHERE Id = @orderId";
                    using (SqlCommand command = new SqlCommand(Querry, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@orderId", id);
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

        private void DeleteAllOrderRegels(int orderId)
        {
            try
            {
                using (SqlConnection connection = this.connection.CreateConnection())
                {
                    string Querry = "Delete from OrderRegel WHERE OrderId = @orderId";
                    using (SqlCommand command = new SqlCommand(Querry, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@orderId", orderId);
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


        public void Update(DtoOrder order)
        {
            try
            {
                using (SqlConnection connection = this.connection.CreateConnection())
                {
                    string Querry = "UPDATE Orders SET Betaald = @betaald, date = @date  WHERE Id = @orderId";
                    if (order.KlantId.HasValue)
                    {
                        Querry = "UPDATE Orders SET Betaald = @betaald, KlantId = @klantId, date = @date  WHERE Id = @orderId";
                    }
                    using (SqlCommand command = new SqlCommand(Querry, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@orderId", order.Id);
                        command.Parameters.AddWithValue("@betaald", order.Betaald);
                        if (order.KlantId.HasValue)
                        {
                            command.Parameters.AddWithValue("@klantId", order.KlantId);
                        }
                        command.Parameters.AddWithValue("@date", order.Date);
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
