using IPC2_Proy01_202602_202500286.TDA_s;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace IPC2_Proy01_202602_202500286.Modelo
{
    public class Ciudades
    {
        private String nombre { get; set; }
        private int filas {  get; set; } //iteraciones para crear filas
        private int columnas { get; set; } //iteraciones para crear celdas 
        private Listas<Listas<NodoCeldas>> ListaFilas;

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
            for (int i = 0; i < caracteres.Length; i++)
            {
                Listas<NodoCeldas> fila = new Listas<NodoCeldas>();
                for(int j = 0; j<columnas; j++)
                {
                    NodoCeldas nodo = new NodoCeldas(new Celda(caracteres[i][j], i, j));

                    fila.Insertar(nodo);
                }

                ListaFilas.Insertar(fila);
            }

            //Console.WriteLine("Malla Creada!");
        }

        public void InsertarUM(Celda UnidadMilitar)
        {
            NodoCeldas NodoUM = new NodoCeldas(UnidadMilitar);
            ListaUM.Insertar(NodoUM);

            //Console.WriteLine("Unidad militar registrada");
        }

        public bool PoseeCiviles() {
            return false;
        }

        public bool PoseeRecursos()
        {
            return false;
        }
    }
}
