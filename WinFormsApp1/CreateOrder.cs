using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.Classes;
using Npgsql;

namespace WinFormsApp1
{
    public partial class CreateOrder : Form
    {

        public CreateOrder()
        {
            InitializeComponent();

        }

        private void CreateOrder_Load(object sender, EventArgs e)
        {
            List<Service> services = Service.getServises();
            foreach (Service service in services)
            {
                listBox1.Items.Add(String.Format("{0}. {1}", service.id, service.name));
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            DB.openConnection();
            Order.createOrder();
            int id_order = Order.getOrders().Max(e => e.id);
            foreach (var item in listBox1.SelectedItems)
            {
                try
                {
                    DB.openConnection();
                    var id_service = item.ToString().Substring(0);
                    NpgsqlCommand command = new NpgsqlCommand("insert into orders_services(id_order, id_service) values (@id_order, @id_service)", DB.getConnection());
                    command.Parameters.Add("@id_order", NpgsqlTypes.NpgsqlDbType.Integer).Value = id_order;
                    command.Parameters.Add("@id_service", NpgsqlTypes.NpgsqlDbType.Integer).Value = Convert.ToInt32(id_service.Substring(0, id_service.IndexOf('.')));
                    command.ExecuteNonQuery();
                    DB.closeConnection();
                }
                catch (Exception ex)
                {
                    
                    MessageBox.Show(ex.Message, "Ошибка");
                }
                
            }
            DB.closeConnection();
        }
    }
}
