using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminWebUI.Models;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AdminWebUI.Controllers
{
    public class OrdersController : ContextController
    {
        public OrdersController(BiesterlanDbContext context, IConfiguration configuration) : base(context, configuration)
        {
        }

        public IActionResult Index()
        {
            var orders = _context.UserOrders.OrderByDescending(p => p.CreateDateTime).ToArray();
            var totalorderamout = orders.Sum(p => p.LineTotal);
            ViewBag.TotalAmount = totalorderamout;
            return View("Orders",orders);
        }


        public JsonResult Get()
        {
            var orders = _context.UserOrders.OrderByDescending(p => p.CreateDateTime).ToArray();

            return Json(orders);
        }

        public ActionResult< List<ProductResultModel>> GetProductResults()
        {
            List<ProductResultModel> result = _context.UserOrders
                .GroupBy(l => l.ArticleName)
                .Select(cl => new ProductResultModel
                {
                    Name = cl.First().ArticleName,
                    Amount = cl.Sum(c=>c.Amount),
                    TotalAmount = cl.Sum(c => c.LineTotal)
                }).ToList();

            var totalsum = result.Sum(p => p.TotalAmount);

            ViewBag.TotalSum = totalsum;

            return View(result.OrderByDescending(p=>p.TotalAmount));
        }
    }
}