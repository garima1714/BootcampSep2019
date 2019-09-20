using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Controllers
{
    [Produces("application/json")]
    [Route("api/Orders")]
    public class OrdersController : Controller
    {
        projectContext dc = new projectContext();
        // GET: api/Orders
        [HttpGet]
        public IEnumerable<Orders> Get()
        {
            var a = dc.Orders.ToList();
            return a;
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public Orders Get(int id)
        {
            var m = dc.Orders.Find(id);
            return m;
        }
        
        // POST: api/Orders
        [HttpPost]
        public void Post([FromBody]Orders value)
        {
            dc.Orders.Add(value);
            dc.SaveChanges();
        }
        
        // PUT: api/Orders/5
        [HttpPut("{id}")]
        public Orders Put(int id, [FromBody]Orders pname,int qty,int price)
        {
            var obj1 = dc.Orders.Where(n => n.Bid == id).SingleOrDefault();
            if (obj1 != null)
            {
                obj1.Bid = id;
                obj1.Pname = pname.Pname;
                obj1.Quantity = qty;
                obj1.Price =price;
                dc.SaveChanges();
            }
            return obj1;
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var obj = dc.Orders.Find(id);
            dc.Orders.Remove(obj);
            dc.SaveChanges();
        }
    }
}
