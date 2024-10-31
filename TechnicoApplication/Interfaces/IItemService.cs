using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicoApplication.Models;
using TechnicoApplication.Responses;

namespace TechnicoApplication.Interfaces;

public interface IItemService
{
    public PropertyResponse<Item> Create(Item item);
    public PropertyResponse<Item> View(int id);
    public List<Item?> ViewItems(int id);
    public PropertyResponse<Item> Update(Item item);
    public bool Delete(int id);
}
