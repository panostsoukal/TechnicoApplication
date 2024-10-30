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
    private readonly ApplicationDbContext db;

    public RepairService(ApplicationDbContext db)
    {
        this.db = db;
    }
    public Repair Create(Repair repair)
    {
        db.Repairs.Add(repair);
        db.SaveChanges();
        return repair;//add response + check
    }
    public Repair? Search(int id)
    {
        return db.Repairs.Where(r => r.ID == id).FirstOrDefault();//add response + check
    }
    public List<Repair?> SearchRepairs(int id)
    {
        var owner = db.Owners.FirstOrDefault(o => o.ID == id);

        if (owner == null) return new List<Repair?>();//add response

        var repairlist = db.Repairs
            .Where(r => r.Owner != null && r.Owner.ID == id)
            .ToList();
        return repairlist;
    }
    public Repair? Update(Repair repair)
    {
        Repair? repairdb = db.Repairs.FirstOrDefault(r => r.ID == repair.ID);
        if (repairdb != null)
        {
            repairdb.Date = repair.Date;
            repairdb.Type = repair.Type;
            repairdb.Description = repair.Description;
            repairdb.Address = repair.Address;
            repairdb.Status = repair.Status;
            repairdb.Cost = repair.Cost;
            repairdb.Owner = repair.Owner;
            repairdb.Item = repair.Item;
            db.SaveChanges();
        }
        return repair;//add response
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
