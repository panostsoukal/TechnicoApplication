using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicoApplication.Interfaces;
using TechnicoApplication.Models;

namespace TechnicoApplication.Validations;

public class RepairValidation : IRepairValidation
{
    public bool RepairValidator(Repair repair)
    {
        if (repair == null)
            return false;
        if (repair.Address.IsNullOrEmpty() || string.IsNullOrWhiteSpace(repair.Address))
            return false;
        return true;
    }
}
