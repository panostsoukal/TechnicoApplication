using TechnicoApplication.Models;

namespace TechnicoApplication.Interfaces
{
    public interface IOwnerItemService
    {
        OwnerItem Create(OwnerItem owneritem);
        OwnerItem? Update(OwnerItem owneritem);
        bool Delete(int id);
    }
}