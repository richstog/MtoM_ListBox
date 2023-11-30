using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Classes
{
    public class Service
    {
        public int id { get; set; }
        public string name { get; set; }
        public int cost { get; set; }

        public static Service getServise(int id)
        {
            Service service = new Service();
            DB.openConnection();
            NpgsqlCommand command = new NpgsqlCommand("select * from services where id = @id", DB.getConnection());
            command.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Integer).Value = id;
            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                service.id = Convert.ToInt32(reader["id"]);
                service.name = Convert.ToString(reader["name"]);
                service.cost = Convert.ToInt32(reader["cost"]);
            }
            DB.closeConnection();
            return service;
        }

        public static List<Service> getServises()
        {
            List<Service> services = new List<Service>();
            DB.openConnection();
            NpgsqlCommand command = new NpgsqlCommand("select * from services", DB.getConnection());
            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Service service = new Service();
                service.id = Convert.ToInt32(reader["id"]);
                service.name = Convert.ToString(reader["name"]);
                service.cost = Convert.ToInt32(reader["cost"]);
                services.Add(service);
            }
            DB.closeConnection();
            return services;
        }
    }
}
