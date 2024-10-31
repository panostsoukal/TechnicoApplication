//to do - 
//check crud functionality and validations
//known issues
// creating an owner first and then running the program again and creating an item that references that owner leads to conflict
//repair validation doesnt have a check for datetime because create and delete have different datetime if clauses
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using TechnicoApplication.Models;
using TechnicoApplication.Repositories;
using TechnicoApplication.Services;
using TechnicoApplication.Validations;

var owner_one = new Owner()
{
    VAT = "1234abcd",
    Name = "Panagiotis",
    Surname = "Tsoukalochoritis",
    Address = "Zografou, Athens",
    PhoneNumber = "1234567890",
    Email = "panostsoukal@gmail.com",
    Password = "12345",
    UserType = UserType.Client
};

var item_one = new Item() 
{
    E9Number = "abcd1234",
    Address = "Home Address 1",
    YearOfConstruction = new DateTime(1990, 1, 1, 0, 0, 0),
    Type = ItemType.Apartment_Building,
    Owners = new List<Owner> { owner_one }
};

var repair_one = new Repair() 
{
    Date = new DateTime(2024, 1, 1, 0, 0, 0),
    Type = RepairType.Painting,
    Description = "painting of 1st floor",
    Address = "Home Address 1",
    Status = RepairStatus.Pending,
    Cost = 200m,
    OwnerID = owner_one.ID,
    ItemID = item_one.ID
};

var owner_two = new Owner()
{
    VAT = "aaaaaa11111111",
    Name = "John",
    Surname = "Doe",
    Address = "Suntagma, Athens",
    PhoneNumber = "000000000",
    Email = "john@doe.com",
    Password = "54321",
    UserType = UserType.Client
};

var item_two = new Item()
{
    E9Number = "bbbbbbb222222",
    Address = "Home Address 2",
    YearOfConstruction = new DateTime(1991, 1, 1, 0, 0, 0),
    Type = ItemType.Maisonet,
    Owners = new List<Owner> { owner_two }
};

var item_three = new Item()
{
    E9Number = "cccccc333333",
    Address = "Home Address 3",
    YearOfConstruction = new DateTime(1992, 1, 1, 0, 0, 0),
    Type = ItemType.Maisonet,
    Owners = new List<Owner> { owner_one, owner_two }
};
ApplicationDbContext db = new ApplicationDbContext();
OwnerValidation ownerValidation = new OwnerValidation();
ItemValidation itemValidation = new ItemValidation();
RepairValidation repairValidation = new RepairValidation();
OwnerService ownerService = new OwnerService(db, ownerValidation);
ItemService itemService = new ItemService(db, itemValidation);
RepairService repairService = new RepairService(db, repairValidation);
//ownerService.Create(owner_one);
//ownerService.Create(owner_two);
//itemService.Create(item_one);
//itemService.Create(item_two);
//itemService.Create(item_three);
//repairService.Create(repair_one);
repairService.Delete(10);
itemService.Delete(20);
itemService.Delete(21);
itemService.Delete(22);
ownerService.Delete(16);
ownerService.Delete(17);
