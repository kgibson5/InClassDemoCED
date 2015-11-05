using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


#region Additional Namespaces
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
#endregion


namespace eRestaurantSystem.DAL.Entities
{
    public class Item
    {
        [Key]
        public int ItemID { get; set; }
        [Required(ErrorMessage = "A Description is required (5-35 characters)")]
        [StringLength(35, MinimumLength = 5, ErrorMessage = "Descriptions must be from 5 to 35 characters in length")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Current Price information is required")]
        [Range(0.01, 50.00, ErrorMessage = "Prices for menu items must be greater than zero and less than or equal to $50.00")]
        public decimal CurrentPrice { get; set; }
        [Required(ErrorMessage = "Current Cost information is required")]
        [Range(0.01, 30.00, ErrorMessage = "Costs for menu items must be greater than zero and less than or equal to $30.00")]
        public decimal CurrentCost { get; set; }
        public bool Active { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Calories noted for a menu item must be greater than or equal to zero")]
        public int? Calories { get; set; }
        public string Comment { get; set; }
        [Required(ErrorMessage = "Every menu item must be categorized")]
        public int MenuCategoryID { get; set; }

        public virtual MenuCategory Category { get; set; }
        public virtual ICollection<BillItem> Billitems { get; set; }

        public Item()
        {
            Active = true;
        }
    }
}
