using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicoApplication.Models;

public class Item
{
    [Key]
    public int ID { get; set; }
    [Required]
    public string E9Number { get; set; } = string.Empty;
    [Required]
    public string Address { get; set; } = string.Empty;
    public DateTime YearOfConstruction { get; set; }
    public ItemType Type { get; set; } = default;
    public List<Owner> Owners { get; set; } = [];
    public List<Repair> Repair { get; set; } = [];

}
