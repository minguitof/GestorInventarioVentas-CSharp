using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorInventariosVentas
{
    public class Inventario
    {
        private List<Producto> _producto; // Encapsulamiento: la lista es privada

        public Inventario()
        {
            _producto = new List<Producto>();
        }

        public void AgregarProducto(Producto producto)
        {
            // Podríamos añadir lógica para evitar IDs duplicados aquí
            _producto.Add(producto);
            Console.WriteLine($"Producto {producto.Name} agregado al inventario.");
        }

        public Producto BuscarProcutoPorID(string id)
        {
            // Usaremos LINQ más adelante, pero por ahora un bucle simple
            foreach (var p in _producto)
            {
                if (p.Id.Equals(id, StringComparison.OrdinalIgnoreCase))
                {
                    return p;
                }
            }
            return null; // si no se encuentra el producto
        }

        public void ActualizarStock(string idProducto, int cantidad)
        {
            Producto producto = BuscarProcutoPorID(idProducto);
            if (producto != null)
            {
                producto.Stock += cantidad;
                Console.WriteLine($"Stock de {producto.Name} actualizado a {producto.Stock}");
            }
            else
            {
                Console.WriteLine($"Error: producto con ID `{idProducto}` no encontrado.");
            }
        }


        public List<Producto> ObtenerTodosLosProductos()
        {
            return _producto; // Devolver una copia o una lista de solo lectura es una buena práctica
        }
    }
}
