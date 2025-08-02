using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Venta
    {
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        public double Cantidad { get; set; }

        public double Costo { get; set; }

        public double SubTotal { get; set; }

        [Required]
        public int IdItem { get; set; }  // Clave foránea

        [ForeignKey("IdItem")]
        public Item Item { get; set; }   // Navegación
    }
}

//TERMINADO
//jaja