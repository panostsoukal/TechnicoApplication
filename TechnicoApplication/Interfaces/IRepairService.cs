using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicoApplication.Models;
using TechnicoApplication.Responses;

namespace TechnicoApplication.Interfaces;

public interface IRepairService
{
    public Repair Create(Repair repair);
    public Repair? Search(int id);
    public List<Repair?> SearchRepairs(int id);
    public Repair? Update(Repair repair);
    public bool Delete(int id);
}
