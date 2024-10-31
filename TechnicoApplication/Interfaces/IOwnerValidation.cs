using TechnicoApplication.Models;

namespace TechnicoApplication.Interfaces
{
    public interface IOwnerValidation
    {
        bool OwnerValidator(Owner owner);
    }
}