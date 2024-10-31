using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicoApplication.Interfaces;
using TechnicoApplication.Models;
using TechnicoApplication.Repositories;
using TechnicoApplication.Responses;

namespace TechnicoApplication.Services;

public class OwnerService : IOwnerService
{
    private readonly ApplicationDbContext _db;
    private readonly IOwnerValidation _validation;

    public OwnerService(ApplicationDbContext db, IOwnerValidation validation)
    {
        this._db = db;
        _validation = validation;
    }
    public PropertyResponse<Owner> Create(Owner owner) 
    {
        var existingOwner = _db.Owners.FirstOrDefault(o => o.VAT == owner.VAT);
        if (existingOwner != null)
        {
            return new PropertyResponse<Owner>
            {
                Status = 1,
                Description = "Owner already exists",
                Value = existingOwner
            };
        }

        _db.Owners.Add(owner);
        _db.SaveChanges();
        return new PropertyResponse<Owner> 
        {
            Status = 0,
            Description = "Success",
            Value = owner 
        };
    }
    public Owner? Display(int id) 
    {
        return _db.Owners.Where(o => o.ID == id).FirstOrDefault();
    }
    public PropertyResponse<Owner> Update(Owner owner) 
    {
        Owner? ownerdb = _db.Owners.FirstOrDefault(o => o.ID == owner.ID);
        if (_validation.OwnerValidator(ownerdb))
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
            _db.SaveChanges();
            return new PropertyResponse<Owner>
            {
                Status = 0,
                Description = "Success",
                Value = ownerdb
            };
        }
        return new PropertyResponse<Owner>
        {
            Status = 3,
            Description = "Error updating owner",
            Value = owner
        };
    }
    public bool Delete(int id)
    {
        Owner? ownerdb = _db.Owners
            .Include(o => o.Items)
            .Include(o => o.Repairs)
            .FirstOrDefault(o => o.ID == id);

        if (_validation.OwnerValidator(ownerdb) && !ownerdb.Items.Any() && !ownerdb.Repairs.Any())
        {
            _db.Owners.Remove(ownerdb);
            _db.SaveChanges();
            return true;
        }
        return false;
    }
}
