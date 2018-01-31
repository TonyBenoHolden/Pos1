using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pos1.Models.Entities
{
    public class Recipe
    {
        public int ID { get; set; }
        public List<InventoryItem> Ingredients { get; set; }
    }
}
