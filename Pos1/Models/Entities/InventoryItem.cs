using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pos1.Models.Entities
{
    public class InventoryItem
    {
        public int ID { get; set; }
        public string ItemName { get; set; }
        public decimal CostPerCase { get; set; }
        public int PortionsPerCase { get; set; }
        public decimal CostPerPortion { get; set; }
        public double TotalSpent { get; set; }
        public double TotalUnitsPurchased { get; set; }
    }
}
