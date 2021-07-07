using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YungChing.Models
{
    public class OrderRepository : Repository<Order, NorthwindContext>
    {
        public OrderRepository(NorthwindContext context) : base(context)
        {
        }
    }
}
