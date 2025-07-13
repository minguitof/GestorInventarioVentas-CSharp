using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGestorInventariosVentas.Class
{
    public class ProductoAlimenticio : Producto
    {
        public DateTime FechaCaducidad { get; set; }

        public ProductoAlimenticio(string id, string name, decimal price, int stock, DateTime fechaCaducidad)
            : base(id, name, price, stock) // Llama al constructor de la clase base (Producto)
        {
            FechaCaducidad = fechaCaducidad;
        }

        public override void MostrarDetalles() // Aquí usamos 'override' para sobreescribir el método del padre
        {
            base.MostrarDetalles(); // Llama al método del padre para mostrar los detalles comunes
            Console.WriteLine($"Fecha de Caducidad: {FechaCaducidad.ToShortDateString()}");
        }

    }

}
