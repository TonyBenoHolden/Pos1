using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pos1.Models.Entities
{
    public class MenuItem
    {
        
        public int ID { get; set; }
        public string MenuName { get; set; }
        public string MenuDescription { get; set; }
        public MenuCategory menuCategory { get; set; }
        public Recipe Recipe { get; set; }
        public double Price { get; set; }
        public int QtySold { get; set; }
    }
}
