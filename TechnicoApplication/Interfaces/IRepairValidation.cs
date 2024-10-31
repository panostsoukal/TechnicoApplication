using TechnicoApplication.Models;

namespace TechnicoApplication.Interfaces
{
    public interface IRepairValidation
    {
        bool RepairValidator(Repair repair);
    }
}