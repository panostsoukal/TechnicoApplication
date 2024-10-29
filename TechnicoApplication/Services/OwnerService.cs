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
    private ApplicationDbContext db;

    public OwnerService(ApplicationDbContext db)
    {
        this.db = db;
    }
    public Owner Create(Owner owner) 
    {
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
            ownerdb.OwnerItems = owner.OwnerItems;
            //ownerdb = owner;
            db.SaveChanges();
        }
        return ownerdb;//add response
    }
    public bool Delete(int id) 
    {
        Owner? ownerdb = db.Owners.FirstOrDefault(o => o.ID == id);
        if (ownerdb != null)
        {
            db.Owners.Remove(ownerdb);
            db.SaveChanges();
            return true;
        }
        return false;//add response
    }
}
