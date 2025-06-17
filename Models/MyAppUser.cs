using Microsoft.AspNetCore.Identity;

namespace retail_store_inventory_2.Models
{
    public class MyAppUser : IdentityUser
    {
        public string Role { get; set; }
    }
}
