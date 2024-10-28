using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicoApplication.Models;

public class Repair
{
    [Key]
    public int ID { get; set; }
    [Required]
    public DateTime Date { get; set; }
    public RepairType Type { get; set; } = default;
    public string? Description { get; set; }
    [Required]
    public string Address { get; set; } = string.Empty;
    public RepairStatus Status { get; set; } = default;
    [Precision(8, 2)]
    public decimal Cost { get; set; }
    public Owner? Owner { get; set; }

}
