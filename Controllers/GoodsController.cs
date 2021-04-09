using Microsoft.AspNetCore.Mvc;
using Online_Store.Data;
using Online_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Store.Controllers
{
    public class GoodsController : Controller
    {
        private readonly ApplicationDbContext _db;
        public GoodsController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Goods> objList = _db.Goods.ToList();
            return View(objList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Goods good)
        {
            _db.Add(good);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(Goods good)
        {
            _db.Remove(good);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
