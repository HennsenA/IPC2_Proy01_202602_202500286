using System;
using System.Collections.Generic;
using System.Text;

namespace IPC2_Proy01_202602_202500286.Modelo
{
    internal class ChapinRobots
    {
        private String nombre { get; set; }
        private int capcomb { get; set; }
        private bool estado { get; set; }

        public ChapinRobots(String nombre, int capcomb)
        {
            this.nombre = nombre;
            this.estado = true;
            this.capcomb = capcomb;
            this.estado = true;
        }

        public void CambiarEstado()
        {
            estado = !estado;
        }
    }
}
