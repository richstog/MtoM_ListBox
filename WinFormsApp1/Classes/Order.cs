using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Classes
{
    public class Order
    {
        public int id { get; set; }
        public string date_ord { get; set; }

        public static Order getOrder(int id)
        {
            Order order = new Order();
            DB.openConnection();
            NpgsqlCommand command = new NpgsqlCommand("select * from orders where id = @id", DB.getConnection());
            command.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Integer).Value = id;
            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                order.id = Convert.ToInt32(reader["id"]);
                order.date_ord = Convert.ToString(reader["date_ord"]);
            }
            DB.closeConnection();
            return order;
        }

        public static List<Order> getOrders()
        {
            List<Order> orders = new List<Order>();
            DB.openConnection();
            NpgsqlCommand command = new NpgsqlCommand("select * from orders", DB.getConnection());
            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Order order = new Order();
                order.id = Convert.ToInt32(reader["id"]);
                order.date_ord = Convert.ToString(reader["date_ord"]);
                orders.Add(order);
            }
            DB.closeConnection();
            return orders;
        }

        public static void createOrder()
        {
            DB.openConnection();
            NpgsqlCommand command = new NpgsqlCommand("insert into orders(date_ord) values (@date_ord)", DB.getConnection());
            command.Parameters.Add("@date_ord", NpgsqlTypes.NpgsqlDbType.Date).Value = DateTime.Now;
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка добавления");
            }
        }

        public static void deleteOrder(int id)
        {
            DB.openConnection();
            NpgsqlCommand command = new NpgsqlCommand("delete from orders where id=@id)", DB.getConnection());
            command.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Integer).Value = id;
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка добавления");
            }
        }
    }
}
