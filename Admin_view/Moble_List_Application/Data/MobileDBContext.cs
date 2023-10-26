using Microsoft.EntityFrameworkCore;
using Moble_List_Application.Models;

namespace Moble_List_Application.Data
{
    public class MobileDBContext:DbContext
    {
        public MobileDBContext(DbContextOptions<MobileDBContext> options):base(options)
        {
            
        }
        public DbSet<Mobile_List> mobile_Lists { get; set; }
    }
}
