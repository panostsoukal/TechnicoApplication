using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicoApplication.Models;

namespace TechnicoApplication.Responses;

public record ImmutableRepair(DateTime Date, RepairType Type, string? Description, string Address, RepairStatus Status, decimal Cost);
