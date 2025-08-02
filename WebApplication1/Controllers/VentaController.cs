using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using System.Linq;

namespace WebApplication1.Controllers
{
    public class VentaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VentaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Mostrar lista de ventas
        public IActionResult ListaVentas()
        {
            var ventas = _context.Ventas.Include(v => v.Item).ToList();
            return View(ventas);
        }

        // Vista para crear una venta
        public IActionResult ListaVentasCrear()
        {
            ViewBag.Items = _context.Items.ToList(); // Para dropdown
            return View();
        }

        [HttpPost]
        public IActionResult ListaVentasCrear(Venta venta)
        {
            try
            {
                // Calcular subtotal automáticamente
                venta.SubTotal = venta.Cantidad * venta.Costo;

                _context.Ventas.Add(venta);
                _context.SaveChanges();

                TempData["Mensaje"] = "Venta registrada exitosamente.";
                return RedirectToAction("ListaVentas");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al guardar la venta: " + ex.Message;
            }

            ViewBag.Items = _context.Items.ToList();
            return View(venta);
        }



    }
}
