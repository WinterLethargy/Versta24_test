using Microsoft.EntityFrameworkCore;

namespace Test_Versta24.Models
{
    public class Versta24dbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public Versta24dbContext(DbContextOptions<Versta24dbContext> opts) : base(opts)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasData(
                    new Order 
                    { 
                        OrderId = 1, 
                        DstCity = "Москва", 
                        DstAddress = "ул. Московская, д. 4", 
                        SrcCity = "Санкт-Петербург", 
                        SrcAddress = "Конрдатьевский пр., д. 15", 
                        PickupDate = DateTime.Now.AddDays(-200), 
                        Weight = 1.23 
                    },
                    new Order 
                    { 
                        OrderId = 2, 
                        DstAddress = "ул. Садовая", 
                        DstCity = "Санкт-Петербург", 
                        SrcAddress = "пр. Суворова", 
                        SrcCity = "Новгород", 
                        PickupDate = DateTime.Now.AddDays(-150), 
                        Weight = 200.45 
                    },
                    new Order 
                    { 
                        OrderId = 3, 
                        DstAddress = "ул. Муму, д. 54", 
                        DstCity = "Екатеринбург", 
                        SrcAddress = "ул. Герасима, д. 45", 
                        SrcCity = "Самара", 
                        PickupDate = DateTime.Now.AddDays(-100), 
                        Weight = 1.23 }
            );
        }
    }
}
