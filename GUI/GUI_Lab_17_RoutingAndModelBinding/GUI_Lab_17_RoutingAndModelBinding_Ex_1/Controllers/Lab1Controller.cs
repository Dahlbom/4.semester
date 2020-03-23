using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GUI_Lab_17_RoutingAndModelBinding_Ex_1.Controllers
{
    public class Lab1Controller : Controller
    {
        public IActionResult Index()
        {
            return View();        
        }

        public IActionResult ShowResult(int x = 2, int y = 4)
        {
            return Content(string.Format($"x={x}, og y={y}"));
        }
    }
}