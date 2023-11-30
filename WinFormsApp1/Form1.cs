using WinFormsApp1.Classes;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            refreshAll();
        }

        public void LoadList()
        {

        }

        public void refreshAll()
        {
            flowLayoutPanel1.Controls.Clear();
            List<Order> orders = Order.getOrders();
            foreach (Order order in orders)
            {
                flowLayoutPanel1.Controls.Add(new ZakazUserControl(order));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            refreshAll();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CreateOrder co = new CreateOrder();
            co.Show();
        }
    }
}