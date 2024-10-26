using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicoApplication.Models;

public class Item
{
    public int ID { get; set; }
    public int E9Number { get; set; }
    public string Address { get; set; }
    public DateTime YearOfConstruction { get; set; }
    public string Type { get; set; }//check for enum
    public int OwnerVAT { get; set; }

}
