using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Shopping.Web.Controllers
{
    public class ShopController : BaseController
    {
        public ShopController() : base()
        {
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}