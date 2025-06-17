using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using retail_store_inventory_2.Models;

namespace retail_store_inventory_2.Data;

public class ApplicationDbContext : IdentityDbContext<MyAppUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}
