using IPC2_Proy01_202602_202500286.TDA_s;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace IPC2_Proy01_202602_202500286.Modelo
{
    public class Ciudades
    {
        public String nombre { get; set; }
        public int filas {  get; set; } //iteraciones para crear filas
        public int columnas { get; set; } //iteraciones para crear celdas 
        private Listas<Listas<NodoCeldas>> ListaFilas;
        public NodoCeldas PrimeraCelda;
        private Listas<NodoCeldas> ListaUM;

        public Ciudades(String nombre, int filas, int columnas)
        {
            this.nombre = nombre;
            this.filas = filas;
            this.columnas = columnas;
            this.ListaFilas = new Listas<Listas<NodoCeldas>>();
            this.ListaUM = new Listas<NodoCeldas>();
        }

        public void ImprimirCiudad()
        {
            string datos = 
                $"""

                Ciudad: {nombre}
                No. Filas: {filas}
                No. Columnas: {columnas}

                """;

            Console.WriteLine(datos);
        }

        public void CrearMalla(char[][] caracteres, int columnas)
        {
            NodoCeldas primerNodoFilaAnterior = null;

            for (int i = 0; i < caracteres.Length; i++)
            {
                Listas<NodoCeldas> fila = new Listas<NodoCeldas>();
                NodoCeldas nodoIzquierdo = null;
                NodoCeldas nodoArriba = primerNodoFilaAnterior;
                NodoCeldas primerNodoFilaActual = null;

                for (int j = 0; j < columnas; j++)
                {
                    NodoCeldas nodo = new NodoCeldas(new Celda(caracteres[i][j], i, j));

                    // Enlazar horizontalmente con la celda a su izquierda
                    if (nodoIzquierdo != null)
                    {
                        nodoIzquierdo.Derecha = nodo;
                        nodo.Izquierda = nodoIzquierdo;
                    }

                    // Enlazar verticalmente con la celda de la fila anterior
                    if (nodoArriba != null)
                    {
                        nodo.Arriba = nodoArriba;
                        nodoArriba.Abajo = nodo;
                        nodoArriba = nodoArriba.Derecha; // avanza junto con "j"
                    }

                    if (primerNodoFilaActual == null)
                        primerNodoFilaActual = nodo;

                    fila.Insertar(nodo);
                    nodoIzquierdo = nodo;
                }

                ListaFilas.Insertar(fila);
                primerNodoFilaAnterior = primerNodoFilaActual; // esta fila será "la de arriba" en la próxima vuelta

                if (i == 0)
                    PrimeraCelda = primerNodoFilaActual; // guarda la esquina superior izquierda
            }
        }

        public void InsertarUM(Celda UnidadMilitar)
        {
            NodoCeldas NodoUM = new NodoCeldas(UnidadMilitar);
            ListaUM.Insertar(NodoUM);

            //Console.WriteLine("Unidad militar registrada");
        }

        public Listas<NodoCeldas> BuscarCelda(int tipo) // 1=Entrada 2=Recurso 3=Civil
        {
            Listas<NodoCeldas> ListaEntradas = new Listas<NodoCeldas>();
            NodoCeldas inicioFila = PrimeraCelda;

            while (inicioFila != null)
            {
                NodoCeldas actual = inicioFila;

                while (actual != null)
                {
                    switch (tipo)
                    {
                        case 1:
                            if (actual.celda.tipo.Equals('E'))
                            {
                                ListaEntradas.Insertar(actual);
                            }
                            break;
                        case 2:
                            if (actual.celda.tipo.Equals('R'))
                            {
                                ListaEntradas.Insertar(actual);
                            }
                            break;
                        case 3:
                            if (actual.celda.tipo.Equals('C'))
                            {
                                ListaEntradas.Insertar(actual);
                            }
                            break;
                    }

                    actual = actual.Derecha;
                }

                inicioFila = inicioFila.Abajo; 
            }

            return ListaEntradas;
        }
    }
}
