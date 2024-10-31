using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicoApplication.Interfaces;
using TechnicoApplication.Models;

namespace TechnicoApplication.Validations;

public class OwnerValidation : IOwnerValidation
{
    public bool OwnerValidator(Owner owner)
    {
        if (owner == null)
            return false;
        if (owner.VAT == null)
            return false;
        if (owner.Name == null)
            return false;
        if (owner.Surname == null)
            return false;
        if (owner.Address == null)
            return false;
        if (owner.Email == null)
            return false;
        if (owner.Password == null)
            return false;
        return true;
    }
}
