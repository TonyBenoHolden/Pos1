using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pos1.Models.Entities
{
    public class Inventory
    {
        public int ID { get; set;}
        public DateTime Date { get; set; }
        public ICollection<InventoryItem> Items { get; set; }
    }
}
