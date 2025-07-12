using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorInventariosVentas
{
   
    public class ProductoElectronico : Producto
    {
        public int MesesGarantia { get; set; }

        public ProductoElectronico(string id, string name, decimal price, int stock, int mesesGarantia)
            : base(id, name, price, stock)
        {
            MesesGarantia = mesesGarantia;
        }

        public override void MostrarDetalles()
        {
            base.MostrarDetalles();
            Console.WriteLine($" Garantia: {MesesGarantia} meses");
        }
    }
}
