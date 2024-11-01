using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicoApplication.Interfaces;
using TechnicoApplication.Models;

namespace TechnicoApplication.Validations;

public class ItemValidation : IItemValidation
{
    public bool ItemValidator(Item item)
    {
        if (item == null)
            return false;
        if (item.E9Number.IsNullOrEmpty() || string.IsNullOrWhiteSpace(item.E9Number))
            return false;
        if (item.Address.IsNullOrEmpty() || string.IsNullOrWhiteSpace(item.Address))
            return false;
        return true;
    }
}
