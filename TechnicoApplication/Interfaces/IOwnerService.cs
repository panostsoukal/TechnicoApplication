using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicoApplication.Models;

namespace TechnicoApplication.Interfaces;

public interface IOwnerService
{
    public void Create(int vat, string name, string surname, string address, int phonenumber, string email, string password, string usertype);
    public void Display(int id);
    public void Update(int id, int vat, string name, string surname, string address, int phonenumber, string email, string password, string usertype);
    public void Delete(int id);
}
