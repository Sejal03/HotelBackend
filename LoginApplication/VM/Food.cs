using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginApplication.VM
{
    public class Food
    {
        public int Food_Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public Nullable<bool> available { get; set; }
    }
}