using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicoApplication.Exceptions;

public class OwnerException : Exception
{
    public OwnerException(string? message) : base(message)
    {
    }
}
