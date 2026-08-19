using IPC2_Proy01_202602_202500286.Modelo;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPC2_Proy01_202602_202500286.TDA_s
{
    public class ListaCiudades:Listas<Ciudades>
    {
        public override void ImprimirNodo()
        {
            var actual = inicio;
            int n = 0;

            while (actual != null)
            {
                n++;
                Console.WriteLine("===Ciudad No. " + n);
                actual.valor.ImprimirCiudad();
                actual = actual.siguiente;
            }
        }
    }
}
