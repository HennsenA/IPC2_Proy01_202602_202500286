using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace IPC2_Proy01_202602_202500286.TDA_s
{
    public class Listas<T>
    {
        public Nodo<T> inicio; //nodo inicial de la lista

        public void Insertar(T valor)
        {
            bool insertado = false;
            Nodo<T> nuevo = new Nodo<T>(valor);

            if (inicio == null)
            {
                inicio = nuevo;
            }
            else
            {
                var actual = inicio;
                while (actual.siguiente != null)
                {
                    actual = actual.siguiente;
                }
                actual.siguiente = nuevo;
            }
        }

        public void Imprimir()
        {
            var actual = inicio;

            while (actual != null)
            {
                Console.Write(actual.valor + " ");
                actual = actual.siguiente;
            }
            Console.WriteLine();
        }

        public T Buscar(T valor)
        {
            var actual = inicio;
            while (actual != null){
                if (actual.valor.Equals(valor)){
                    var encontrado = actual.valor;
                    return encontrado;
                }
                else
                {
                    actual = actual.siguiente;
                }
            }

            return valor;
        }

        public void Reemplazar(T elemento) { 
        
        }

        public bool Existe(String nombre)
        {
            return true;
        }
    }
}
