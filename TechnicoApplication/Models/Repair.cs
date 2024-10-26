using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicoApplication.Models;

public class Repair
{
    public int ID { get; set; }
    public DateTime Date { get; set; }
    public string Type { get; set; }
    public string? Description { get; set; }
    public string Address { get; set; }
    public string Status { get; set; }
    public decimal Cost { get; set; }
    public Owner Owner { get; set; }

}
