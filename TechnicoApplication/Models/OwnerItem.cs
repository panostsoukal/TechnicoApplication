using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicoApplication.Models
{
    public class OwnerItem
    {
        public int Id { get; set; }
        public Owner? Owner { get; set; }
        public Item? Item { get; set; }
    }
}
