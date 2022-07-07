using AjaxHW23.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AjaxHW23.Controllers
{
    public class ApiController : Controller
    {
        private readonly DemoContext _demo;

        public ApiController(DemoContext demo)
        {
            _demo = demo;
        }
        public IActionResult CheckName(Member member) 
        {
            string Answer = "";
            Member db = _demo.Members.FirstOrDefault(t => t.Name == member.Name);
            if (db != null)
                Answer = "該名稱已被使用";
            else
                Answer = "可以使用的名字";
            return Content(Answer, "text/plain", System.Text.Encoding.UTF8);
        }
        public IActionResult City()
        {
            var cities = _demo.Addresses.Select(a => a.City).Distinct();
            return Json(cities);
        }
        public IActionResult Districts(string city)
        {
            var districts = _demo.Addresses.Where(a => a.City == city).Select(a => a.SiteId).Distinct();
            return Json(districts);
        }
        public IActionResult Roads(string district)
        {
            var roads = _demo.Addresses.Where(a => a.SiteId == district).Select(a => a.Road);
            return Json(roads);
        }
    }
}
