using HotelSol.hotelsol.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSolLimpio.hotelsol.modelo
{
    internal class DescuentoCliente
    {
        public static decimal ObtenerDescuento(TipoCliente tipo)
        {
            return tipo switch
            {
                TipoCliente.Estandar => 0.0m,
                TipoCliente.Vip => 0.15m,
                _ => 0.0m
            };
        }

    }
}
