﻿using HotelSol.hotelsol.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSol.hotelsol.datos.DAO.interfaz
{
    public interface EmpleadoDao
    {
        List<object> ObtenerTodosParaTabla();
        bool ExisteUserName(string userName);
        void Agregar(Empleado empleado);
     
    }
}
