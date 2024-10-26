using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicoApplication.Interfaces;
using TechnicoApplication.Models;

namespace TechnicoApplication.Services;

public class OwnerService : IOwnerService
{
    private Owner _owner;

    public OwnerService(Owner owner)
    {
        _owner = owner;
    }
    public void Create(int vat, string name, string surname, string address, int phonenumber, string email, string password, string usertype) 
    {
        _owner = new Owner() 
        {
            VAT = vat,
            Name = name,
            Surname = surname,
            Address = address,
            PhoneNumber = phonenumber,
            Email = email,
            Password = password,
            UserType = usertype
        };
        //add logic for persistence
    }
    public void Display(int id) 
    {

    }
    public void Update(int id, int vat, string name, string surname, string address, int phonenumber, string email, string password, string usertype) 
    {

    }
    public void Delete(int id) 
    {

    }
}
