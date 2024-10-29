using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicoApplication.Models;
using TechnicoApplication.Repositories;
using TechnicoApplication.Responses;

namespace TechnicoApplication.Services;

public class ItemService
{
    private ApplicationDbContext db;

    public ItemService(ApplicationDbContext db)
    {
        this.db = db;
    }
    public Item Create(Item item)
    {
        db.Items.Add(item);
        db.SaveChanges();
        return item;//add response + check
    }
    public Item? View(int id)
    {
        return db.Items.Where(i => i.ID == id).FirstOrDefault();//add response + check
    }
    public List<ImmutableItem> ViewItems(int id)
    {
        var owner = db.Owners.FirstOrDefault(o => o.ID == id);

        if (owner == null) return new List<ImmutableItem>();//add response

        var itemlist = db.OwnerItems
            .Where(oi => oi.Owner != null && oi.Owner.ID == id)
            .Select(oi => oi.Item)
            .Where(item => item != null)
            .Select(item => new ImmutableItem(item.E9Number, item.Address, item.YearOfConstruction, item.Type)).ToList();
        return itemlist;
    }
    public Item? Update(Item item)
    {
        Item? itemdb = db.Items.FirstOrDefault(i => i.ID == item.ID);
        if (itemdb != null)
        {
            itemdb = item;
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
