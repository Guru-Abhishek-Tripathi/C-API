using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRegister.Model
{
    public class Register
    {
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Pincode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string GSTN { get; set; }
        public string Pan { get; set; }
        public string Aadhaar { get; set; }
        public string ServiceNeeded { get; set; }
        public string Details { get; set; }
        public string Comments { get; set; }
    }
}
