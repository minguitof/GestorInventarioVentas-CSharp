using System;
using System.Collections.Generic;
using System.Drawing;
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
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nPresione cualquier tecla para continuar");
                Console.ResetColor();
                Console.ReadKey();

            }
        }

        private void MostrarMenu()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Green; // cambio de color a verde
            Console.WriteLine("--- Gestor de Inventario y Ventas --- \n");
            Console.ResetColor();

            Console.WriteLine("1. Agregar un nuevo producto");
            Console.WriteLine("2. Actualizar Stock del producto");
            Console.WriteLine("3. Ver Inventario");
            Console.WriteLine("4. Salir");

            Console.ForegroundColor = ConsoleColor.Yellow; // cambio de color a amarillo
            Console.Write("\nSelecciona una opción:  ");
            Console.ResetColor();
        }

        public void AgregarNuevoProducto()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n--- Agregar un nuevo producto ---\n");
            Console.ResetColor();


            Console.Write("ID del producto: ");
            string id = Console.ReadLine();
            Console.Write("Nombre del producto: ");
            string name = Console.ReadLine();
            
            // Aquí es donde empezaremos a pensar en el manejo de excepciones
            decimal price;

            // Bucle para solicitar el precio hasta que sea válido
            while (true)
            {
                Console.Write("Precio: ");
                if (decimal.TryParse(Console.ReadLine(), out price))
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("❌ Precio inválido. Por favor, ingrese un número válido.");
                    Console.ResetColor();

                }
            }


            // --- Manejo de Stock ---
            int stock;

            while (true) 
            {
                Console.Write("Stock inicial: ");
                if (int.TryParse(Console.ReadLine(), out stock))
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Stock invalido. Por Favor ingrese un número entero");
                    Console.ResetColor();
                }
            }


            // --- Manejo del Tipo de Producto ---
            string tipo;
            // Bucle para solicitar el tipo de producto hasta que sea una opción válida

            while(true)
            {
                Console.Write("Tipo de producto (A: Alimenticio, E: Eléctronico, O: Otro): ");
                tipo = Console.ReadLine().ToUpper();


                if (tipo == "A" || tipo == "E" || tipo=="O")
                {
                    break;
                }
                else 
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("❌ Tipo de producto inválido. Por favor, seleccione 'A', 'E' u 'O'.");
                    Console.ResetColor();
                }
            }

            Producto nuevoProducto;

            switch (tipo)
            {
                case "A":
                    DateTime fechaCaducidad;

                    while(true)
                    {
                        Console.Write("Fecha de caducidad (YYYY-MM-DD): ");
                        if (DateTime.TryParse(Console.ReadLine(), out fechaCaducidad))
                        {
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("❌ Fecha de caducidad inválida. Por favor, ingrese en formato YYYY-MM-DD.");
                            Console.ResetColor();
                        }   
                    }

                   
                    

                    nuevoProducto = new ProductoAlimenticio(id, name, price, stock, fechaCaducidad);
                    break;
                case "E":
                    int mesesGarantia;

                    while(true)
                    {
                        Console.Write("Meses de Garantia: ");
                        if (!int.TryParse(Console.ReadLine(), out mesesGarantia))
                        {
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("❌ Meses de Garantía inválidos. Por favor, ingrese un número entero.");
                            Console.ResetColor();
                        }
                    }
                    nuevoProducto = new ProductoElectronico(id, name, price, stock, mesesGarantia);
                    break;
                default:
                    nuevoProducto = new Producto(id, name, price, stock);
                    break;
            }
            _inventario.AgregarProducto(nuevoProducto);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n✅ Producto '{name}' agregado con éxito.\n");
            Console.ResetColor();
        }

        private void ActualizarStockProducto()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n --- Actualizar Stock --- \n");
            Console.ResetColor();

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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n --- Inventario actual --- \n");
            Console.ResetColor();

            List<Producto> productos = _inventario.ObtenerTodosLosProductos();

            if (productos.Count == 0)
            {
                Console.Write("El inventario esta vacio.");
                return;
            }

            foreach (var p in productos)
            {
                p.MostrarDetalles(); // Aquí el polimorfismo entra en juego, cada producto sabe cómo mostrarse
                Console.ForegroundColor= ConsoleColor.Green;
                Console.Write("========================================================\n");
                Console.ResetColor();
            }

        }
    }
}
