using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicoApplication.Models;

namespace TechnicoApplication.Responses;

public record ImmutableItem(string E9Number, string Address, DateTime YearOfConstruction, ItemType Type);
