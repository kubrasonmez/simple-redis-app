using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;
using StackExchangeApp.Services;

namespace StackExchangeApp.Controllers
{
    public class StringTypeController : Controller
    {
        private readonly RedisService _redisService;
        private readonly IDatabase db;
        public StringTypeController(RedisService redisService)
        {
            _redisService = redisService;

            db = _redisService.GetDb(0);
        }
        public IActionResult Index()
        {
            db.StringSet("name", "Kubra");
            db.StringSet("visiter", 100);

            return View();
        }

        public IActionResult Show()
        {
            var value = db.StringGet("name");
            db.StringIncrement("visiter", 1);

            if(value.HasValue)
            {
                ViewBag.value = value.ToString();
            }

            ViewBag.visiter = db.StringGet("visiter");
            return View();
        }


    }
}