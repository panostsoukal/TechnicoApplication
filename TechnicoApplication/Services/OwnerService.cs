using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicoApplication.Interfaces;
using TechnicoApplication.Models;
using TechnicoApplication.Repositories;

namespace TechnicoApplication.Services;

public class OwnerService : IOwnerService
{
    private readonly ApplicationDbContext db;

    public OwnerService(ApplicationDbContext db)
    {
        this.db = db;
    }
    public Owner Create(Owner owner) 
    {
        var existingOwner = db.Owners.FirstOrDefault(o => o.VAT == owner.VAT);
        if (existingOwner != null)
        {
            return existingOwner;
        }

        db.Owners.Add(owner);
        db.SaveChanges();
        return owner;//add response + check
    }
    public Owner? Display(int id) 
    {
        return db.Owners.Where(o => o.ID == id).FirstOrDefault();//add response + check
    }
    public Owner? Update(Owner owner) 
    {
        Owner? ownerdb = db.Owners.FirstOrDefault(o => o.ID == owner.ID);
        if (ownerdb != null)
        {
            ownerdb.VAT = owner.VAT;
            ownerdb.Name = owner.Name;
            ownerdb.Surname = owner.Surname;
            ownerdb.Address = owner.Address;
            ownerdb.PhoneNumber = owner.PhoneNumber;
            ownerdb.Email = owner.Email;
            ownerdb.Password = owner.Password;
            ownerdb.UserType = owner.UserType;
            ownerdb.Items = owner.Items;
            ownerdb.Repairs = owner.Repairs;
            db.SaveChanges();
        }
        return ownerdb;//add response
    }
    public bool Delete(int id)//add check to delete only if no repairs or items are tied to them
    {
        Owner? ownerdb = db.Owners
            .Include(o => o.Items)
            .Include(o => o.Repairs)
            .FirstOrDefault(o => o.ID == id);

        if (ownerdb != null && !ownerdb.Items.Any() && !ownerdb.Repairs.Any())
        {
            db.Owners.Remove(ownerdb);
            db.SaveChanges();
            return true;
        }
        return false;//add response
    }
}
