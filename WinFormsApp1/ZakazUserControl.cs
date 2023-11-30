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

namespace WinFormsApp1
{
    public partial class ZakazUserControl : UserControl
    {
        Order order;
        public ZakazUserControl(Order order)
        {

            InitializeComponent();
            this.order = order;
        }

        private void ZakazUserControl_Load(object sender, EventArgs e)
        {
            label1.Text = String.Format("{0}. {1}", order.id, order.date_ord);
        }
    }
}
