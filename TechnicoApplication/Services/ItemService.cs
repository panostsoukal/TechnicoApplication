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
    private readonly ApplicationDbContext db;

    public ItemService(ApplicationDbContext db)
    {
        this.db = db;
    }
    public Item Create(Item item)
    {

        var existingItem = db.Items.FirstOrDefault(i => i.E9Number == item.E9Number);
        if (existingItem != null)
        {
            return existingItem;
        }

        db.Items.Add(item);
        db.SaveChanges();
        return item;//add response + check
    }
    public Item? View(int id)
    {
        return db.Items.Where(i => i.ID == id).FirstOrDefault();//add response + check
    }
    public List<Item?> ViewItems(int id)
    {
        var owner = db.Owners.FirstOrDefault(o => o.ID == id);

        if (owner == null) return new List<Item?>();//add response

        return owner.Items.ToList();
    }
    public Item? Update(Item item)
    {
        Item? itemdb = db.Items.FirstOrDefault(i => i.ID == item.ID);
        if (itemdb != null)
        {
            itemdb.E9Number = item.E9Number;
            itemdb.Address = item.Address;
            itemdb.YearOfConstruction = item.YearOfConstruction;
            itemdb.Type = item.Type;
            itemdb.Owners = item.Owners;
            itemdb.Repairs = item.Repairs;//fix
            db.SaveChanges();
        }
        return itemdb;//add response
    }
    public bool Delete(int id)
    {
        Item? itemdb = db.Items.FirstOrDefault(i => i.ID == id);
        if (itemdb != null)
        {
            db.Items.Remove(itemdb);
            db.SaveChanges();
            return true;
        }
        return false;//add response
    }
}
