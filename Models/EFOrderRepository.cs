namespace Test_Versta24.Models
{
    public class EFOrderRepository : IOrderRepository
    {
        public IQueryable<Order> Orders => _context.Orders;
        private Versta24dbContext _context;
        public EFOrderRepository(Versta24dbContext context) => _context = context;
        public void SaveOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }
    }
}
