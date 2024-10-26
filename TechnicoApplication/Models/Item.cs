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
    public string Address { get; set; } = string.Empty;
    public DateTime YearOfConstruction { get; set; }
    public string Type { get; set; } = string.Empty;
    public List<OwnerItem> OwnerItems { get; set; } = [];

}
