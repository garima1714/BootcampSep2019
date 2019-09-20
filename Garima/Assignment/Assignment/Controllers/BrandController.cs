using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Assignment.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Controllers
{
    [Route("api/[controller]")]
    public class BrandController : Controller
    {
        projectContext dc = new projectContext();
        // GET api/values
        [HttpGet]
        public JsonResult Get()
        {
            List<Brand> list = dc.Brand.ToList();
            return Json(list);
            //return new Brand();
        }
        [HttpGet("{id}")]
        public Brand Get(int id)
        {
            var m = dc.Brand.Find(id);
            return m;

        }

        public void Post([FromBody]Brand value)
        {
            dc.Brand.Add(value);
            dc.SaveChanges();
        }

        [HttpPut("{id}")]
        public Brand Put([FromBody]Brand bname,int id,int b_id)
        {
            var obj1 = dc.Brand.Where(n => n.Pid == id).SingleOrDefault();
            if (obj1 != null)
            {
                obj1.Pid = id;
                obj1.Bid = b_id;
                obj1.Bname = bname.Bname;
                dc.SaveChanges();
            }
            return obj1;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var obj = dc.Brand.Find(id);
            dc.Brand.Remove(obj);
            dc.SaveChanges();
        }
    }
}