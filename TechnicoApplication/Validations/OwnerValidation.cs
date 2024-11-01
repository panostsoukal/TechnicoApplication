using Microsoft.IdentityModel.Tokens;
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
        if (owner.VAT.IsNullOrEmpty() || string.IsNullOrWhiteSpace(owner.VAT))
            return false;
        if (owner.Name.IsNullOrEmpty() || string.IsNullOrWhiteSpace(owner.Name))
            return false;
        if (owner.Surname.IsNullOrEmpty() || string.IsNullOrWhiteSpace(owner.Surname))
            return false;
        if (owner.Address.IsNullOrEmpty() || string.IsNullOrWhiteSpace(owner.Address))
            return false;
        if (owner.Email.IsNullOrEmpty() || string.IsNullOrWhiteSpace(owner.Email))
            return false;
        if (owner.Password.IsNullOrEmpty() || string.IsNullOrWhiteSpace(owner.Password))
            return false;
        return true;
    }
}
