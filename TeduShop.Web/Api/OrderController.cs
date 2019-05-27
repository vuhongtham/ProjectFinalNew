using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TeduShop.Service;
using TeduShop.Web.Infrastructure.Core;
using TeduShop.Common.ViewModels;

namespace TeduShop.Web.Api
{
    [RoutePrefix("api/order")]
    public class OrderController : ApiControllerBase
    {
        private IOrderService _orderService;

        public OrderController(IErrorService errorService, IOrderService orderService): base(errorService)
        {
            this._orderService = orderService;
        }
        [Route("getallorders")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request, int page, int pageSize = 15)
        {
            Func<HttpResponseMessage> func = () =>
            {
                int totalRow = 0;
                var model = _orderService.GetListOrder();

                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.CreatedDate).Skip(page * pageSize).Take(pageSize);
                var paginationSet = new PaginationSet<OrderInfor>()
                {
                    Items = query,
                    Page = page,
                    TotalCount = totalRow,
                    TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize)
                };
                var response = request.CreateResponse(HttpStatusCode.OK, paginationSet);
                return response;
            };
            return CreateHttpResponse(request, func);
        }
    }
}
