using System;
using System.Collections.Generic;
using System.Text;

namespace IPC2_Proy01_202602_202500286.Modelo
{
    internal class ChapinRobots
    {
        private String nombre { get; set; }
        private bool estado { get; set; }

        public ChapinRobots(String nombre)
        {
            this.nombre = nombre;
            this.estado = true;
        }
    }
}
