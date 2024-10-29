using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicoApplication.Models;
using TechnicoApplication.Repositories;
using TechnicoApplication.Responses;

namespace TechnicoApplication.Services;

public class RepairService
{
    private ApplicationDbContext db;

    public RepairService(ApplicationDbContext db)
    {
        this.db = db;
    }
    public ImmutableRepair? Create(Repair repair)
    {
        db.Repairs.Add(repair);
        db.SaveChanges();
        Repair? repairdb = db.Repairs.Where(r => r.ID == repair.ID).FirstOrDefault();
        return new ImmutableRepair(repairdb.Date, repairdb.Type, repairdb.Description, repairdb.Address, repairdb.Status, repairdb.Cost);//add response + check
    }
    public ImmutableRepair? Search(int id)
    {
        Repair ? repairdb = db.Repairs.Where(r => r.ID == id).FirstOrDefault();
        return new ImmutableRepair(repairdb.Date, repairdb.Type, repairdb.Description, repairdb.Address, repairdb.Status, repairdb.Cost);//add response + check
    }
    public List<ImmutableRepair> SearchRepairs(int id)
    {
        var owner = db.Owners.FirstOrDefault(o => o.ID == id);

        if (owner == null) return new List<ImmutableRepair>();//add response

        var repairlist = db.Repairs
            .Where(r => r.Owner != null && r.Owner.ID == id)
            .Select(r => new ImmutableRepair(r.Date, r.Type, r.Description, r.Address, r.Status, r.Cost)).ToList();
        return repairlist;
    }
    public ImmutableRepair? Update(Repair repair)
    {
        Repair? repairdb = db.Repairs.FirstOrDefault(r => r.ID == repair.ID);
        if (repairdb != null)
        {
            repairdb = repair;
            db.SaveChanges();
        }
        return new ImmutableRepair(repairdb.Date, repairdb.Type, repairdb.Description, repairdb.Address, repairdb.Status, repairdb.Cost);//add response
    }
    public bool Delete(int id)
    {
        Repair? repairdb = db.Repairs.FirstOrDefault(r => r.ID == id);
        if (repairdb != null)
        {
            db.Repairs.Remove(repairdb);
            db.SaveChanges();
            return true;
        }
        return false;//add response
    }
}
