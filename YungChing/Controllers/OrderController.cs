using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YungChing.Models;

namespace YungChing.Controllers
{
    public class OrderController : BaseController<Order, OrderRepository>
    {
        public OrderController(OrderRepository repository) : base(repository)
        {
            
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var orders = await Repository.GetAll();
            return View(orders);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Order order)
        {
            await Repository.Add(order);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var order = await Repository.Get(id);
            return View(order);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Order order)
        {
            await Repository.Update(order);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var order = await Repository.Get(id);
            return View(order);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await Repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
