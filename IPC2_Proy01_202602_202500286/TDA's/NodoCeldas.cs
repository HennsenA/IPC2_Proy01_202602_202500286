using IPC2_Proy01_202602_202500286.Modelo;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPC2_Proy01_202602_202500286.TDA_s
{
    public class NodoCeldas
    {
        public Celda celda { get; set; }
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
            int CapacidadRestante = CapacidadR;
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
                        Celda Actual

                        Fila: {actual.celda.fila+1}
                        Columna: {actual.celda.columna+1}
                        Capacidad: {actual.celda.capcomb}
                        Tipo: {actual.celda.tipo}
                    """);*/

                // Condicion de llegada
                if (actual.celda.fila == CeldaDestino.celda.fila && actual.celda.columna == CeldaDestino.celda.columna)
                {
                    MostrarCamino(actual, MaxSize);
                    Console.WriteLine("Capacidad de Combate final: "+CapacidadRestante);
                    return;
                }

                if (actual.celda.capcomb > 0)
                {
                    CapacidadRestante -= actual.celda.capcomb;
                }

                NodoCeldas[] vecinos = { actual.Arriba, actual.Abajo, actual.Izquierda, actual.Derecha };

                foreach (NodoCeldas vecino in vecinos)
                {
                    if (vecino != null && vecino.celda.Transitable(CapacidadR, mision) && !visitados.Existe(vecino))
                    { 
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
                Console.WriteLine($"({nodo.celda.fila+1},{nodo.celda.columna+1}) capcomb: {nodo.celda.capcomb}");
            }
        }
    }
}
