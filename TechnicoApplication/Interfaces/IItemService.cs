using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicoApplication.Models;

namespace TechnicoApplication.Interfaces;

public interface IItemService
{
    public void Create(int e9number, string address, DateTime yearofconstruction, string type, int ownervat);
    public void Display(int id);
    public void Update(int id, int e9number, string address, DateTime yearofconstruction, string type, int ownervat);
    public void Delete(int id);
}
