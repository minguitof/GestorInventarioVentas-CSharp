using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGestorInventariosVentas.Class
{
    public class Producto
    {
        public string Id { get; set; } //Identificador unico (SKU)
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        //Constructor para iniciar el producto
        public Producto(string id, string name, decimal price, int stock)
        {
            Id = id;
            Name = name;
            Price = price;
            Stock = stock;
        }

        // Método para mostrar información del producto (lo sobreescribiremos en clases hijas)
        public virtual void MostrarDetalles()
        {
            Console.WriteLine($"ID: {Id}\nNombre: {Name}\nPrecio: {Price:C}\nStock: {Stock}\n");
        }

    }
}
