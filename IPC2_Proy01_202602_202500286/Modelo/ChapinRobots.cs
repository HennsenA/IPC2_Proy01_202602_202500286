using System;
using System.Collections.Generic;
using System.Text;

namespace IPC2_Proy01_202602_202500286.Modelo
{
    public class ChapinRobots
    {
        public String nombre { get; set; }
        public int capcomb { get; set; }
        public bool estado { get; set; }

        public ChapinRobots(String nombre, int capcomb)
        {
            this.nombre = nombre;
            this.estado = true;
            this.capcomb = capcomb;
        }

        public void CambiarEstado()
        {
            estado = !estado;
        }

        public void ImprimirRobot()
        {
            string datos =
                $"""

                Robot:             {nombre}
                Capacidad Combate: {capcomb} (ChapinRescue=0, ChapinFighter > 0)
                Estado:            {estado} (Disponible = true, NoDisponible = false)

                """;

            Console.WriteLine(datos);
        }
    }
}
