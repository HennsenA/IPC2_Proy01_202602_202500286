using IPC2_Proy01_202602_202500286.Modelo;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPC2_Proy01_202602_202500286.TDA_s
{
    public class ListaRobots: Listas<ChapinRobots>
    {
        public override void ImprimirNodo()
        {
            var actual = inicio;
            int n = 0;

            while (actual != null)
            {
                n++;
                Console.WriteLine("===Robot No. " + n);
                actual.valor.ImprimirRobot();
                actual = actual.siguiente;
            }
        }
    }
}
