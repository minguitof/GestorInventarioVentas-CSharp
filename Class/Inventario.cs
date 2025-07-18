﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGestorInventariosVentas.Class
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
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nStock de {producto.Name} ha sido actualizado a {producto.Stock}");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: producto con ID `{idProducto}` no encontrado.");
                Console.ResetColor();
            }
        }

        public void ActualizarPrice(string idProducto, int cantidad)
        {
            Producto producto = BuscarProcutoPorID(idProducto);
            if (producto != null)
            {
                producto.Price = cantidad;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nPrecio de {producto.Name} ha sido actualizado a {producto.Price}");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: producto con ID `{idProducto}` no encontrado.");
                Console.ResetColor();
            }
        }

        public List<Producto> ObtenerTodosLosProductos()
        {
            return _producto; // Devolver una copia o una lista de solo lectura es una buena práctica
        }
    }
}
