﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using ConsoleGestorInventariosVentas.Class;

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