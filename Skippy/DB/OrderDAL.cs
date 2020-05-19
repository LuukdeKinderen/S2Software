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

        public List<OrderDTO> GetAll()
        {
            DeleteAllEmpty();
            List<OrderDTO> orders = new List<OrderDTO>();
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
                            OrderDTO newOrder = new OrderDTO
                            {
                                Id = reader.GetInt32(0),
                                Betaald = reader.GetBool(1),
                                KlantId = reader.SafeGetInt(2),
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

        public void UpdateOrderRegel(int orderId, OrderRegelDTO orderRegel)
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

        public void DeleteOrderRegel(int orderId, OrderRegelDTO orderRegel)
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

        private void DeleteOrderRegels(int orderId)
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

        public void Delete(int id)
        {
            DeleteOrderRegels(id);

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

        public void Complete(int id)
        {
            try
            {
                using (SqlConnection connection = this.connection.CreateConnection())
                {
                    string Querry = "UPDATE Orders SET Betaald = @betaald WHERE Id = @orderId";
                    using (SqlCommand command = new SqlCommand(Querry, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@orderId", id);
                        command.Parameters.AddWithValue("@betaald", true);
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

        public void OpRekening(int id)
        {
            try
            {
                using (SqlConnection connection = this.connection.CreateConnection())
                {
                    string Querry = "UPDATE Orders SET Betaald = @betaald WHERE Id = @orderId";
                    using (SqlCommand command = new SqlCommand(Querry, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@orderId", id);
                        command.Parameters.AddWithValue("@betaald", false);
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

        public void AddKlant(int orderId, int klantId)
        {
            try
            {
                using (SqlConnection connection = this.connection.CreateConnection())
                {
                    string Querry = "UPDATE Orders SET KlantId = @klantId WHERE Id = @orderId";
                    using (SqlCommand command = new SqlCommand(Querry, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@orderId", orderId);
                        command.Parameters.AddWithValue("@klantId", klantId);
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
