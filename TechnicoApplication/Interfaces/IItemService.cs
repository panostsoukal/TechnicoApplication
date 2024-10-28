using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicoApplication.Models;

namespace TechnicoApplication.Interfaces;

public interface IItemService
{
    public Item Create(Item item);
    public Item? Display(int id);
    public Item? Update(Item item);
    public bool Delete(int id);
}
