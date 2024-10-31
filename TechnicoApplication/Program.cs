// to program 8a trexei 2-3 services gia na fanei oti bainoun pragmata stin vasi
// (isws k alles crud leitourgies) kai kana console write line gia na fanei oti kataxwrountai, oxi menu g xristi
//to do - 
//create class(mb not) for validations for services and responses, check for db context constraints
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using TechnicoApplication.Models;
using TechnicoApplication.Repositories;
using TechnicoApplication.Services;

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
    Owner = owner_one,
    Item = item_one
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
OwnerService ownerService = new OwnerService(db);
ItemService itemService = new ItemService(db);
RepairService repairService = new RepairService(db);
ownerService.Create(owner_one);
ownerService.Create(owner_two);
itemService.Create(item_one);
itemService.Create(item_two);
itemService.Create(item_three);
repairService.Create(repair_one);

//var owneritem_one = new OwnerItem
//{
//    Owner = owner_one,
//    Item = item_one
//};

//var owneritem_two = new OwnerItem
//{
//    Owner = owner_two,
//    Item = item_two
//};

//var owneritem_three = new OwnerItem
//{
//    Owner = owner_two,
//    Item = item_three
//};

//var owneritem_four = new OwnerItem
//{
//    Owner = owner_one,
//    Item = item_three
//};

//ApplicationDbContext db = new ApplicationDbContext();
//OwnerService ownerService = new OwnerService(db);
//ItemService itemService = new ItemService(db);
//RepairService repairService = new RepairService(db);
//OwnerItemService ownerItemService = new OwnerItemService(db);

//ownerService.Create(owner_one);
//ownerService.Create(owner_two);
//itemService.Create(item_one);
//itemService.Create(item_two);
//itemService.Create(item_three);
//repairService.Create(repair_one);
//ownerItemService.Create(owneritem_two);
//ownerItemService.Create(owneritem_three);
//ownerItemService.Create(owneritem_four);

//Item? testItem = itemService.View(15);
//List<Item?> items1 = itemService.ViewItems(13);
//List<Item?> items2 = itemService.ViewItems(14);
//Repair? testRepair = repairService.Search(4);
//List<Repair?> repairs1 = repairService.SearchRepairs(13);
//List<Repair?> repairs2 = repairService.SearchRepairs(14);

//Console.WriteLine($"item name = {testItem?.E9Number} id = {testItem?.ID}");

//foreach (var item in items1)
//{
//    Console.WriteLine($"list1 item name = {item?.E9Number} id = {item?.ID}");
//}

//foreach (var item in items2)
//{
//    Console.WriteLine($"list2 item name = {item?.E9Number} id = {item?.ID}");
//}


//Console.WriteLine($"repair name = {testRepair?.Address} id = {testRepair?.ID}");

//foreach (var repair in repairs1)
//{
//    Console.WriteLine($"list1 repair name = {repair?.Address} id = {repair?.ID}");
//}

//foreach (var repair in repairs2)
//{
//    Console.WriteLine($"list2 repair name = {repair?.Address} id = {repair?.ID}");
//}

//var owner_upd = new Owner()
//{
//    VAT = "1234abcd",
//    Name = "no",
//    Surname = "one",
//    Address = "Zografou, Athens",
//    PhoneNumber = "1234567890",
//    Email = "who@cares.com",
//    Password = "12345",
//    UserType = UserType.Client,
//    ID = 12
//};
//ownerService.Update(owner_upd);
//ownerService.Delete(12);

//Owner? testOwner = ownerService.Display(1);

//Console.WriteLine($"customer name = {testOwner?.Name} id = {testOwner?.ID}");

//Item? testItem = itemService.View(1);

//Console.WriteLine($"item name = {testItem?.E9Number} id = {testItem?.ID}");

//Repair? testRepair = repairService.Search(1);

//Console.WriteLine($"repair name = {testRepair?.Address} id = {testRepair?.ID}");


//List<Item?> items = itemService.ViewItems(3);

//foreach (var item in items) 
//{
//    Console.WriteLine($"list item name = {item?.E9Number} id = {item?.ID}");
//}
