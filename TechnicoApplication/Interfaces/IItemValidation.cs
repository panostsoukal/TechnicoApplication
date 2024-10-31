using TechnicoApplication.Models;

namespace TechnicoApplication.Interfaces
{
    public interface IItemValidation
    {
        bool ItemValidator(Item item);
    }
}