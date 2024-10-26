using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicoApplication.Models;

namespace TechnicoApplication.Interfaces;

public interface IRepairService
{
    public void Create(DateTime date, string type, string? description, string address, string status, decimal cost, Owner owner);
    public void Display(int id);
    public void Update(int id, DateTime date, string type, string? description, string address, string status, decimal cost, Owner owner);
    public void Delete(int id);
}
