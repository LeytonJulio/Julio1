using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Data;
using System.Linq;

namespace WebApplication1.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemController(ApplicationDbContext context)
        {
            _context = context;
        }


     
        public IActionResult Crear()
        {
            return View();
        }

      
        [HttpPost]
        
        public IActionResult Crear(Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Items.Add(item);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(item);
        }


     
        public IActionResult Index()
        {
            var listaDeItems = _context.Items.ToList();
            return View(listaDeItems); 
        }

 
        public IActionResult Edit(int id)
        {
            var item = _context.Items.Find(id);
            if (item == null)
                return NotFound();

            return View(item); 
        }

       
        [HttpPost]
        
        public IActionResult Edit(Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Items.Update(item);
                _context.SaveChanges();
                return RedirectToAction("Index"); 
            }

            return View(item);
        }

       
        public IActionResult Eliminar(int id)
        {
            var item = _context.Items.Find(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

       
        [HttpPost, ActionName("Eliminar")]
       
        public IActionResult EliminarConfirmado(int id)
        {
            var item = _context.Items.Find(id);
            if (item != null)
            {
                _context.Items.Remove(item);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }




    }
}
