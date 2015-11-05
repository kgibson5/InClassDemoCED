using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.Collections;
#endregion

namespace eRestaurantSystem.DAL.DTOs
{
    public class MenuCategoryItems
    {
        public string Description { get; set; }
        public IEnumerable MenuItems { get; set; }
    }
}
