using IPC2_Proy01_202602_202500286.TDA_s;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPC2_Proy01_202602_202500286.Modelo
{
    public class Ciudades
    {
        private String nombre { get; set; }
        private int filas {  get; set; } //iteraciones para crear filas
        private int columnas { get; set; } //iteraciones para crear celdas 

        public Ciudades(String nombre, int filas, int columnas)
        {
            this.nombre = nombre;
            this.filas = filas;
            this.columnas = columnas;
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

        public void CrearMalla(char[][] caracteres)
        {

        }
        public void VerMalla()
        {

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
