using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorInventariosVentas
{
    public class GestorAplicacion
    {
        private Inventario _inventario;

        public GestorAplicacion()
        {

            _inventario = new Inventario();
            // Aquí podrías cargar datos iniciales si existieran
        }

        public void Ejecutar()
        {
            bool salir = false;

            while (!salir)
            {
                MostrarMenu();
                string opcion = Console.ReadLine();


                switch (opcion)
                {
                    case "1":
                        AgregarNuevoProducto();
                        break;
                    case "2":
                        ActualizarStockProducto();
                        break;
                    case "3":
                        ListarTodosProductos();
                        break;
                    case "4":
                        Console.WriteLine("Saliendo de la aplicación...");
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción no valida, intente nuevamente. ");
                        break;
                }
                Console.WriteLine("\n Presione cualquier tecla para continuar");
                Console.ReadKey();
            }
        }

        private void MostrarMenu()
        {
            Console.Clear(); //Limpiar la consola para un efecto más limpio
            Console.WriteLine("--- Gestor de Inventario y Ventas --- ");
            Console.WriteLine("1. Agregar un nuevo producto");
            Console.WriteLine("2. Actualizar Stock del producto");
            Console.WriteLine("3. Ver Inventario");
            Console.WriteLine("4. Salir");
            Console.Write("Selecciona una opción:  ");
        }

        public void AgregarNuevoProducto()
        {
            Console.WriteLine("--- Agregar un nuevo producto ---");
            Console.Write("ID del producto: ");
            string id = Console.ReadLine();
            Console.Write("Nombre del producto: ");
            string name = Console.ReadLine();
            Console.Write("Precio: ");
            // Aquí es donde empezaremos a pensar en el manejo de excepciones
            decimal price;

            if (!decimal.TryParse(Console.ReadLine(), out price))
            {
                Console.WriteLine("Precio invalido. Por favor ingrese un número");
                return;
            }
            Console.Write("Stock inicial: ");
            int stock;

            if (!int.TryParse(Console.ReadLine(), out stock))
            {
                Console.WriteLine("Stock invalido. Por Favor ingrese un número entero");
                return;
            }

            Console.Write("Tipo de producto (A: Alimenticio, E: Eléctronico, O: Otro): ");
            string tipo = Console.ReadLine().ToUpper();

            Producto nuevoProducto;

            switch (tipo)
            {
                case "A":
                    Console.Write("Fecha de caducidad (YYYY-MM-DD): ");
                    DateTime fechaCaducidad;

                    if (!DateTime.TryParse(Console.ReadLine(), out fechaCaducidad))
                    {
                        Console.WriteLine("Fecha de caducidad invalida: ");
                        return;
                    }
                    nuevoProducto = new ProductoAlimenticio(id, name, price, stock, fechaCaducidad);
                    break;
                case "E":
                    Console.Write("Meses de Garantia: ");
                    int mesesGarantia;

                    if (!int.TryParse(Console.ReadLine(), out mesesGarantia))
                    {
                        Console.WriteLine("Meses de Gatantia invalidos");
                        return;
                    }
                    nuevoProducto = new ProductoElectronico(id, name, price, stock, mesesGarantia);
                    break;
                default:
                    nuevoProducto = new Producto(id, name, price, stock);
                    break;
            }
            _inventario.AgregarProducto(nuevoProducto);
        }

        private void ActualizarStockProducto()
        {
            Console.WriteLine("\n --- Actualizar Stock --- ");
            Console.Write("ID del producto a actualizar: ");
            string id = Console.ReadLine();

            Console.Write("Cantidad a añadir/restar (Ej: 5 para añadir, -2 para restar): ");
            int cantidad;

            if (!int.TryParse(Console.ReadLine(), out cantidad))
            {
                Console.WriteLine("Cantidad invalidad, intente nuevamente ingresar un nuevo entero");
                return;
            }
            _inventario.ActualizarStock(id, cantidad);
        }

        private void ListarTodosProductos()
        {
            Console.WriteLine("\n --- Inventario actual --- ");
            List<Producto> productos = _inventario.ObtenerTodosLosProductos();

            if (productos.Count == 0)
            {
                Console.Write("El inventario esta vacio.");
                return;
            }

            foreach (var p in productos)
            {
                p.MostrarDetalles(); // Aquí el polimorfismo entra en juego, cada producto sabe cómo mostrarse
            }

        }
    }
}
