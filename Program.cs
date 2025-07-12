using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using GestorInventariosVentas; // Asegúrate de que tu namespace sea el correcto


namespace GestorInventariosVentas
{
    class Program
    {
        static void Main(string[] args)
        {
            GestorAplicacion app = new GestorAplicacion();
            app.Ejecutar();
        }
    }
}