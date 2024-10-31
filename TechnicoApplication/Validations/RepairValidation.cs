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
        if (repair.Date <= DateTime.Now)
            return false;
        if (repair.Address == null)
            return false;
        if (repair.Owner == null)
            return false;
        if (repair.Item == null)
            return false;
        return true;
    }
}
