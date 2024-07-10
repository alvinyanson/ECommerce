using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models.ViewModel
{
    public class CartVM
    {
        public IEnumerable<Cart> Cart { get; set; }

        public double OrderTotal { get; set; }
    }
}
