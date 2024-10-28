using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicoApplication.Models;

namespace TechnicoApplication.Interfaces;

public interface IOwnerService
{
    public Owner Create(Owner owner);
    public Owner? Display(int id);
    public Owner? Update(Owner owner);
    public bool Delete(int id);
}
