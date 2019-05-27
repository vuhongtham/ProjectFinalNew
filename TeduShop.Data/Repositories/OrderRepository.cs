using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using TeduShop.Common.ViewModels;
using TeduShop.Data.Infrastructure;
using TeduShop.Model.Models;
using System.Linq;

namespace TeduShop.Data.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        IEnumerable<RevenueStatisticViewModel> GetRevenueStatistic(string fromDate, string toDate);
        IEnumerable<OrderInfor> GetListOrder();
    }

    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<RevenueStatisticViewModel> GetRevenueStatistic(string fromDate, string toDate)
        {
            var parameters = new SqlParameter[]{
                new SqlParameter("@fromDate",fromDate),
                new SqlParameter("@toDate",toDate)
            };
            return DbContext.Database.SqlQuery<RevenueStatisticViewModel>("GetRevenueStatistic @fromDate,@toDate", parameters);
        }
        public IEnumerable<OrderInfor> GetListOrder()
        {
            var query = from o in DbContext.Orders
                        join od in DbContext.OrderDetails
                        on o.ID equals od.OrderID
                        select new OrderInfor{
                            OrderID = o.ID,
                            CustomerName = o.CustomerName,
                            CustomerAddress = o.CustomerAddress,
                            CustomerEmail = o.CustomerEmail,
                            CreatedDate = o.CreatedDate,
                            Price = od.Price,
                            OrderStatus = o.Status
                        };
            
            return query.OrderByDescending(x => x.CreatedDate);
        }
    }
}