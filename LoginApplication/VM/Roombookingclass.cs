using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginApplication.VM
{
    public class Roombookingclass
    {
        public int Room_id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}