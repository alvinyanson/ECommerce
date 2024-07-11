using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models.ViewModel
{
    public class LoginVM
    {
        public LogIn Credential { get; set; }

        public string ReturnUrl { get; set; }
    }
}
