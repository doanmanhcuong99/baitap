using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloW.Models;
using Microsoft.AspNetCore.Mvc;

namespace HelloW.Controllers
{
    public class ProductController : Controller
    {
        private readonly MyDb _context;
        public ProductController(MyDb context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Products.ToList());
        }
        public IActionResult Create()
        {
            
            return View();
        }
        public IActionResult Update(Product product)
        {
            var existProduct = _context.Products.Find(product.Id);
            if (!_context.Products.Any())
            {
                return NotFound();
            }
            existProduct.Name = product.Name;
            existProduct.Price = product.Price;
            _context.Products.Update(existProduct);
            _context.SaveChanges();
            TempData["message"] = "Update Success";
            return new RedirectResult("Index");
        }
        public IActionResult Edit(long id)
        {
            var product = _context.Products.Find(id);
            if (!_context.Products.Any())
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpPost]
        public IActionResult Save(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            TempData["message"] = "Create success";
            return new RedirectResult("Index");

        }
       [HttpDelete]
        public IActionResult Delete( long id)
        {
            var Product = _context.Products.Find(id);
            if (Product == null)
            {
                return NotFound();
            }
           _context.Products.Remove(Product);
           _context.SaveChanges();
            TempData["message"] = "Delete Success";
            return new RedirectResult("Index");

        }
        [HttpDelete]
        public IActionResult DeleteMany(string ids)
        {
            return Json(ids);
        }
    };
}