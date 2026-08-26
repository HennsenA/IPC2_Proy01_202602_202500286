using IPC2_Proy01_202602_202500286.Modelo;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPC2_Proy01_202602_202500286.TDA_s
{
    public class NodoCeldas
    {
        public Celda celda { get;}
        public NodoCeldas Arriba, Abajo;
        public NodoCeldas Izquierda, Derecha;
        public NodoCeldas Padre;

        public NodoCeldas(Celda celda)
        {
            this.celda = celda;
            this.Arriba = null;
            this.Abajo = null;
            this.Izquierda = null; 
            this.Derecha = null;
            this.Padre = null;
        }

        public void Dfs(int MaxSize, NodoCeldas CeldaInicio, NodoCeldas CeldaDestino, int CapacidadR, int mision)
        {
            Pila pila = new Pila(MaxSize);
            Listas<NodoCeldas> visitados = new Listas<NodoCeldas>();

            pila.Push(CeldaInicio);
            visitados.Insertar(CeldaInicio);

            /*Console.WriteLine(
                    $"""
                        Celda de Destino
                        Fila: {CeldaDestino.celda.fila}
                        Columna: {CeldaDestino.celda.columna}
                    """);*/

            while (!pila.PilaVacia())
            {
                NodoCeldas actual = pila.Pop();

                /*Console.WriteLine(
                    $"""
                        Fila: {actual.celda.fila}
                        Columna: {actual.celda.columna}
                    """);*/

                // Condicion de llegada
                if (actual.celda.fila == CeldaDestino.celda.fila && actual.celda.columna == CeldaDestino.celda.columna)
                {
                    MostrarCamino(actual, MaxSize);
                    Console.WriteLine("Capacidad de Combate final: "+CapacidadR);
                    return;
                }

                NodoCeldas[] vecinos = { actual.Arriba, actual.Abajo, actual.Izquierda, actual.Derecha };

                foreach (NodoCeldas vecino in vecinos)
                {
                    if (vecino != null && vecino.celda.Transitable(CapacidadR, mision) && !visitados.Existe(vecino))
                    {
                        if (vecino.celda.capcomb > 0)
                        {
                            CapacidadR-=vecino.celda.capcomb;
                        }
                        vecino.Padre = actual; 
                        visitados.Insertar(vecino);
                        pila.Push(vecino);
                    }
                }
            }

            Console.WriteLine("Misión Imposible");
        }

        private void MostrarCamino(NodoCeldas destino, int MaxSize)
        {
            Pila camino = new Pila(MaxSize);
            NodoCeldas actual = destino;

            while (actual != null)
            {
                camino.Push(actual);
                actual = actual.Padre;
            }

            while (!camino.PilaVacia())
            {
                NodoCeldas nodo = camino.Pop();
                Console.WriteLine($"({nodo.celda.fila},{nodo.celda.columna})");
            }
        }
    }
}
