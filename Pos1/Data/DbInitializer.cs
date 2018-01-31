using Pos1.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pos1.Data
{
    public class DbInitializer
    {
        public static void Initialize(MenuContext context)
        {
            context.Database.EnsureCreated();

            //Look for Menu Categories.
            if (context.MenuCategories.Any())
            {
                return; // Db has already been seeded.
            }

            var menuCategories = new MenuCategory[]
            {
                new MenuCategory{Header="Beverages"},
                new MenuCategory{Header="Sandwiches"},
                new MenuCategory{Header="Pizza"}
            };

            foreach (MenuCategory mc in menuCategories)
            {
                context.MenuCategories.Add(mc);
            }
            context.SaveChanges();

            var menuItems = new MenuItem[]
            {
                new MenuItem{MenuName="Hamburger", MenuDescription="6oz patty, Kaiser Roll", menuCategory=null, Recipe=null, Price=10, QtySold=0 },
                new MenuItem{MenuName="Fountain Soda", MenuDescription="12oz.", menuCategory=null, Recipe=null, Price=2.50, QtySold=0}
            };

            foreach(MenuItem item in menuItems)
            {
                context.MenuItems.Add(item);
            }
            context.SaveChanges();
        }
    }
}
