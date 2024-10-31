using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicoApplication.Interfaces;
using TechnicoApplication.Models;
using TechnicoApplication.Repositories;
using TechnicoApplication.Responses;

namespace TechnicoApplication.Services;

public class RepairService : IRepairService
{
    private readonly ApplicationDbContext _db;
    private readonly IRepairValidation _validation;

    public RepairService(ApplicationDbContext db, IRepairValidation validation)
    {
        this._db = db;
        _validation = validation;
    }
    public PropertyResponse<Repair> Create(Repair repair)
    {
        var existingRepair = _db.Repairs.FirstOrDefault(x => x.Address == repair.Address && x.Type == repair.Type && x.Status != RepairStatus.Complete);
        if (existingRepair != null) 
        {
            return new PropertyResponse<Repair>
            {
                Status = 1,
                Description = "Repair already exists",
                Value = existingRepair
            };
        }
        _db.Repairs.Add(repair);
        _db.SaveChanges();
        return new PropertyResponse<Repair>
        {
            Status = 0,
            Description = "Success",
            Value = repair
        };
    }
    public PropertyResponse<Repair> Search(int id)
    {
        var repairdb = _db.Repairs.Where(r => r.ID == id).FirstOrDefault();
        if (!_validation.RepairValidator(repairdb))
        {
            return new PropertyResponse<Repair>
            {
                Status = 2,
                Description = "Repair not found",
                Value = repairdb
            };
        }
        return new PropertyResponse<Repair>
        {
            Status = 0,
            Description = "Success",
            Value = repairdb
        };
    }
    public List<Repair?> SearchRepairs(int id)
    {
        var repairdb = _db.Repairs.FirstOrDefault(r => r.Owner.ID == id);

        if (!_validation.RepairValidator(repairdb))
        {
            return new List<Repair?>();
        }

        var repairlist = _db.Repairs
            .Where(r => r.Owner.ID == id)
            .ToList();
        return repairlist;
    }
    public PropertyResponse<Repair> Update(Repair repair)
    {
        Repair? repairdb = _db.Repairs.FirstOrDefault(r => r.ID == repair.ID);
        if (_validation.RepairValidator(repairdb))
        {
            repairdb.Date = repair.Date;
            repairdb.Type = repair.Type;
            repairdb.Description = repair.Description;
            repairdb.Address = repair.Address;
            repairdb.Status = repair.Status;
            repairdb.Cost = repair.Cost;
            repairdb.Owner = repair.Owner;
            repairdb.Item = repair.Item;
            _db.SaveChanges();
            return new PropertyResponse<Repair>
            {
                Status = 0,
                Description = "Success",
                Value = repairdb
            };
        }
        return new PropertyResponse<Repair>
        {
            Status = 2,
            Description = "Error updating repair",
            Value = repair
        };
    }
    public bool Delete(int id)
    {
        Repair? repairdb = _db.Repairs.FirstOrDefault(r => r.ID == id);
        if (_validation.RepairValidator(repairdb))
        {
            _db.Repairs.Remove(repairdb);
            _db.SaveChanges();
            return true;
        }
        return false;
    }
}
