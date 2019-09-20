using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Assignment.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        projectContext dc = new projectContext();





        // GET api/values
        [HttpGet]
        public IEnumerable<Product> Get()
        {
           var a = dc.Product.ToList();
          return a;
         }
        [HttpGet("{id}")]
         public Product Get(int id)
        {
           var m = dc.Product.Find(id);
           return m;
         }
        
       public void Post([FromBody]Product value)
        {
            dc.Product.Add(value);
            dc.SaveChanges();
        }

        [HttpPut("{id}")]
        public Product Put([FromBody]Product pname, int id)
        {
            var obj1 = dc.Product.Where(n => n.Pid == id).SingleOrDefault();
            if (obj1 != null)
            {
                obj1.Pid = id;
                obj1.Pname = pname.Pname;
                dc.SaveChanges();
            }
            return obj1;
        }

        [ HttpDelete("{id}")]
        public void Delete(int id)
        {
            var obj = dc.Product.Find(id);
            dc.Product.Remove(obj);
            dc.SaveChanges();
        }
    }

}





