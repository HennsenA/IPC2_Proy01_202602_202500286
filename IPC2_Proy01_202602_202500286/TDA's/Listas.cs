using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace IPC2_Proy01_202602_202500286.TDA_s
{
    public class Listas<T>
    {
        private int tamanio;
        private Nodo<T> nodo; //nodo dentro de la lista

        public Listas(int tamanio)
        {
            this.tamanio = tamanio;
        }

        public void Insertar(T tipo)
        {

        }
        public T Buscar(String nombre)
        {
            return default(T);
        }

        public void Reemplazar(T elemento) { 
        
        }

        public bool Existe(String nombre)
        {
            return true;
        }
    }
}
