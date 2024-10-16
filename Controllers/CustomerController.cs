using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CustomerContext _contextCus;

        public CustomerController(CustomerContext context)
        {
            _contextCus = context; 
        }
        public async Task<IActionResult> Index()
        {
            var customers = await _contextCus.tb_customer.ToListAsync();
            return View(customers);
        }
        public ActionResult Create() { 
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomerModel cus)
        {

            if (ModelState.IsValid)
            {
                _contextCus.tb_customer.Add(cus);
                await _contextCus.SaveChangesAsync();  
                //TempData["SuccessMessage"] = "Customer add success";
                return RedirectToAction("Index"); 
            }
            else
            {
                //TempData["ErrorMessage"] = "Error: Unable to add the product. Please try again.";  // Set error message
                return View(cus);
            }

        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null || id <= 0) return BadRequest();
            var cus = await _contextCus.tb_customer.FirstOrDefaultAsync(c => c.cus_id == id);
            if (cus == null) return NotFound();
            return View(cus);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id <= 0) return BadRequest();

            var del = await _contextCus.tb_customer.FirstOrDefaultAsync(t => t.cus_id == id);
            if (del == null) return NotFound();

            _contextCus.tb_customer.Remove(del);
            await _contextCus.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id) //id มาจากหน้า index TypeProduct
        {
            if (id == null || id <= 0) return BadRequest();
            var customer = await _contextCus.tb_customer.FirstOrDefaultAsync(c => c.cus_id == id);
            //when found data return data by id
            if (customer == null) return NotFound();
            return View(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, CustomerModel customer)
        {
            var cus = await _contextCus.tb_customer.FirstOrDefaultAsync(t => t.cus_id == id);
            if (cus == null) return NotFound();
            cus.cus_name = customer.cus_name;
            cus.cus_lname = customer.cus_lname;
            cus.cus_add = customer.cus_add;
            cus.cus_tel = customer.cus_tel;
            cus.bdate = customer.bdate;
            cus.sex = customer.sex;
            cus.username = customer.username;
            cus.password = customer.password;
            await _contextCus.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
