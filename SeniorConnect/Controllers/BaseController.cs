﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Negocio.Database;
using Negocio.TOs.Configuration;

namespace SeniorConnect.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        public ApplicationContext ApplicationContext { get; set; }

        public BaseController(ApplicationContext applicationContext)
        {
            ApplicationContext = applicationContext;
        }
    }
}
