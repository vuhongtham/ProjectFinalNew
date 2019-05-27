using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeduShop.Common.ViewModels
{
    public class OrderInfor
    {
        public int OrderID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerAddress { get; set; }
        public DateTime? CreatedDate { get; set; }
        public decimal Price { get; set; }
        public bool OrderStatus { get; set; }
    }
}
