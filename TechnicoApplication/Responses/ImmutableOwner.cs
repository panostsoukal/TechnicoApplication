using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicoApplication.Models;

namespace TechnicoApplication.Responses;

public record ImmutableOwner(string VAT, string Name, string Surname, string Address, string PhoneNumber, string Email, string Password, UserType UserType);