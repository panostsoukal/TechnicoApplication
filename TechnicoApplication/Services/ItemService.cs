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

public class ItemService : IItemService
{
    private readonly ApplicationDbContext _db;
    private readonly IItemValidation _validation;

    public ItemService(ApplicationDbContext db, IItemValidation validation)
    {
        this._db = db;
        _validation = validation;
    }
    public PropertyResponse<Item> Create(Item item)
    {

        var existingItem = _db.Items.FirstOrDefault(i => i.E9Number == item.E9Number);
        if (existingItem != null)
        {
            return new PropertyResponse<Item>
            {
                Status = 1,
                Description = "Item already exists",
                Value = existingItem
            };
        }

        _db.Items.Add(item);
        _db.SaveChanges();
        return new PropertyResponse<Item>
        {
            Status = 0,
            Description = "Success",
            Value = item
        };
    }
    public PropertyResponse<Item> View(int id)
    {
        var itemdb = _db.Items.Where(i => i.ID == id).FirstOrDefault();
        if (!_validation.ItemValidator(itemdb)) 
        {
            return new PropertyResponse<Item>
            {
                Status = 2,
                Description = "Item not found",
                Value = itemdb
            };
        }
        return new PropertyResponse<Item>
        {
            Status = 0,
            Description = "Success",
            Value = itemdb
        };
    }
    public List<Item?> ViewItems(int id)
    {
        var ownerdb = _db.Owners.FirstOrDefault(o => o.ID == id);

        if (ownerdb == null)
        {
            return new List<Item?>(); 
        }

        var items = _db.Items
             .Include(i => i.Owners)  
             .Where(i => i.Owners.Any(o => o.ID == id))
             .ToList();
        return items;
    }
    public PropertyResponse<Item> Update(Item item)
    {
        Item? itemdb = _db.Items.FirstOrDefault(i => i.ID == item.ID);
        if (_validation.ItemValidator(itemdb))
        {
            itemdb.E9Number = item.E9Number;
            itemdb.Address = item.Address;
            itemdb.YearOfConstruction = item.YearOfConstruction;
            itemdb.Type = item.Type;
            itemdb.Owners = item.Owners;
            itemdb.Repairs = item.Repairs;
            _db.SaveChanges();
            return new PropertyResponse<Item>
            {
                Status = 0,
                Description = "Success",
                Value = itemdb
            };
        }
        return new PropertyResponse<Item>
        {
            Status = 3,
            Description = "Error updating item",
            Value = itemdb
        };
    }
    public bool Delete(int id)
    {
        Item? itemdb = _db.Items.FirstOrDefault(i => i.ID == id);
        if (!_validation.ItemValidator(itemdb) && !itemdb.Owners.Any() && !itemdb.Repairs.Any())
        {
            _db.Items.Remove(itemdb);
            _db.SaveChanges();
            return true;
        }
        return false;
    }
}
