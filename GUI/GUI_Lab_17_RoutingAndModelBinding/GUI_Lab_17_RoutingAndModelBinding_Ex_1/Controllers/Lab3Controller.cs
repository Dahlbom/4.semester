using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GUI_Lab_17_RoutingAndModelBinding_Ex_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace GUI_Lab_17_RoutingAndModelBinding_Ex_1.Controllers
{
    public class Lab3Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public Person AddPerson(Person model)
        {
            return model;
        }
    }
}