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
    [Route("api/Tax")]


    public class TaxController : Controller
    {

        projectContext dc = new projectContext();
        // GET: api/Tax
        [HttpGet]
        public IEnumerable<Tax> Get()
        {
            var a = dc.Tax.ToList();
            return a;
        }

        // GET: api/Tax/5
        [HttpGet("{id}")]
        public Tax Get(int id)
        {
            var m = dc.Tax.Find(id);
            return m;
        }
        
        // POST: api/Tax
        [HttpPost]
        public void Post([FromBody]Tax value)
        {
            dc.Tax.Add(value);
            dc.SaveChanges();
        }
        
        // PUT: api/Tax/5
        [HttpPut("{id}")]
        public Tax Put(int id,int gst)
        {
            var obj1 = dc.Tax.Where(n => n.Pid == id).SingleOrDefault();
            if (obj1 != null)
            {
                obj1.Pid = id;
                obj1.Gst = gst;
                dc.SaveChanges();
            }
            return obj1;
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var obj = dc.Tax.Find(id);
            dc.Tax.Remove(obj);
            dc.SaveChanges();
        }
    }
}
