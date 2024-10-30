using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicoApplication.Interfaces;
using TechnicoApplication.Models;
using TechnicoApplication.Repositories;

namespace TechnicoApplication.Services;

public class OwnerItemService : IOwnerItemService
{
    private readonly ApplicationDbContext db;

    public OwnerItemService(ApplicationDbContext db)
    {
        this.db = db;
    }

    public OwnerItem Create(OwnerItem owneritem)
    {

        var existingOwner = db.Owners.FirstOrDefault(o => o.ID == owneritem.Owner.ID);
        if (existingOwner != null)
        {
            db.Attach(existingOwner);
            owneritem.Owner = existingOwner;
        }

        var existingItem = db.Items.FirstOrDefault(i => i.ID == owneritem.Item.ID);
        if (existingItem != null)
        {
            db.Attach(existingItem);
            owneritem.Item = existingItem;
        }

        db.OwnerItems.Add(owneritem);
        db.SaveChanges();
        return owneritem;
    }
    public OwnerItem? Update(OwnerItem owneritem)
    {
        OwnerItem? owneritemdb = db.OwnerItems.FirstOrDefault(oi => oi.Id == owneritem.Id);
        if (owneritemdb != null)
        {
            owneritemdb.Owner.ID = owneritem.Owner.ID;
            owneritemdb.Item.ID = owneritem.Item.ID;
            db.SaveChanges();
        }
        return owneritemdb;
    }
    public bool Delete(int id)
    {
        OwnerItem? owneritemdb = db.OwnerItems.FirstOrDefault(oi => oi.Id == id);
        if (owneritemdb != null)
        {
            db.OwnerItems.Remove(owneritemdb);
            db.SaveChanges();
            return true;
        }
        return false;
    }
}
