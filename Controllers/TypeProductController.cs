using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{

    public class TypeProductController : Controller
    {
        private readonly TypeProductContext _context;

        public TypeProductController(TypeProductContext context) { 

            _context = context; //connect to db
        }
        public async Task<IActionResult>Index()
        {
            var typeproduct = await _context.ProductType.ToListAsync();
            return View(typeproduct); //add view right at View(); / add view 
        }

        [HttpPost]
        public async Task<IActionResult> Create(TypeProduct tproduct) {

            if (ModelState.IsValid)
            {
                _context.ProductType.Add(tproduct);
                await _context.SaveChangesAsync();  //save to db
                TempData["SuccessMessage"] = "Type product add success";
                return RedirectToAction("Index");   //go to main page main when add success
            }
            else { 
                //TempData["ErrorMessage"] = "Error: Unable to add the product. Please try again.";  // Set error message
                return View(tproduct);
            }

        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id) //id มาจากหน้า index TypeProduct
        {
            if (id == null || id <= 0) return BadRequest();
            var typeproduct = await _context.ProductType.FirstOrDefaultAsync(c => c.type_id == id);
            //when found data return data by id
            if(typeproduct == null) return NotFound();
            return View(typeproduct);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, TypeProduct typeproduct) {
            var type = await _context.ProductType.FirstOrDefaultAsync(t => t.type_id == id);
            if (type == null) return NotFound();
            type.type_name = typeproduct.type_name; 
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id <= 0) return BadRequest();

            var del = await _context.ProductType.FirstOrDefaultAsync(t => t.type_id == id);
            if (del == null) return NotFound();

            _context.ProductType.Remove(del);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Detail(int? id) //id มาจากหน้า index TypeProduct
        {
            if (id == null || id <= 0) return BadRequest();
            var typeproduct = await _context.ProductType.FirstOrDefaultAsync(c => c.type_id == id);
            //when found data return data by id
            if (typeproduct == null) return NotFound();
            return View(typeproduct);
        }
    }
}
