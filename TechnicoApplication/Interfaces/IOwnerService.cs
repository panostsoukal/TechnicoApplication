using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicoApplication.Models;
using TechnicoApplication.Responses;

namespace TechnicoApplication.Interfaces;

public interface IOwnerService
{
    public PropertyResponse<Owner> Create(Owner owner);
    public Owner? Display(int id);
    public PropertyResponse<Owner> Update(Owner owner);
    public bool Delete(int id);
}
