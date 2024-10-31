using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TechnicoApplication.Models;

public class Owner
{
    [Key]
    public int ID {  get; set; }
    [Required]
    public string VAT {  get; set; } = string.Empty;
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string Surname { get; set; } = string.Empty;
    [Required]
    public string Address { get; set; } = string.Empty;
    [Phone]
    public string PhoneNumber { get; set; } = string.Empty;
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
    public UserType UserType { get; set; } = default;
    public List<Item> Items { get; set; } = [];
    public List<Repair> Repairs { get; set; } = [];

}
