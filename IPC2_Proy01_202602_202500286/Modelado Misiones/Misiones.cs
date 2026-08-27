using IPC2_Proy01_202602_202500286.TDA_s;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace IPC2_Proy01_202602_202500286.Modelado_Misiones
{
    internal class Misiones
    {
        public string GenerarDot(NodoCeldas primeraCelda, Listas<NodoCeldas> camino)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("digraph Malla {");
            sb.AppendLine("  rankdir=TB;");
            sb.AppendLine("  splines=false;");
            sb.AppendLine("  nodesep=0.05;");
            sb.AppendLine("  ranksep=0.05;");
            sb.AppendLine("  node [shape=square, style=filled, fixedsize=true, width=0.5, height=0.5, label=\"\"];");

            NodoCeldas inicioFila = primeraCelda;
            int f = 0;
            Listas<Listas<string>> idsPorFila = new Listas<Listas<string>>();

            // 1. Declarar nodos y agrupar por fila (rank=same)
            while (inicioFila != null)
            {
                NodoCeldas actual = inicioFila;
                int c = 0;
                Listas<string> idsFilaActual = new Listas<string>();

                sb.Append("  { rank=same; ");
                while (actual != null)
                {
                    string id = $"c{f}_{c}";
                    idsFilaActual.Insertar(id);

                    string color = "";
                    if (actual.celda.tipo.Equals('*'))
                    {
                        color = "black";
                    }else if(actual.celda.tipo.Equals(' '))
                    {
                        color = "white";
                    }else if (actual.celda.tipo.Equals('R'))
                    {
                        color = "gray";
                    }else if (actual.celda.tipo.Equals('C')){
                        color = "blue";
                    }else if (actual.celda.tipo.Equals('U'))
                    {
                        color = "red";
                    }else if (actual.celda.tipo.Equals('E'))
                    {
                        color = "green";
                    }

                    sb.AppendLine();
                    sb.Append($"    {id} [fillcolor=\"{color}\"];");

                    actual = actual.Derecha;
                    c++;
                }
                sb.AppendLine();
                sb.AppendLine("  }");

                idsPorFila.Insertar(idsFilaActual);
                inicioFila = inicioFila.Abajo;
                f++;
            }

            // 2. Aristas invisibles horizontales (izquierda -> derecha dentro de cada fila)
            var nodoFila = idsPorFila.inicio;
            while (nodoFila != null)
            {
                Listas<string> fila = nodoFila.valor;
                var nodoId = fila.inicio;

                while (nodoId != null && nodoId.siguiente != null)
                {
                    sb.AppendLine($"  {nodoId.valor} -> {nodoId.siguiente.valor} [style=invis];");
                    nodoId = nodoId.siguiente;
                }

                nodoFila = nodoFila.siguiente;
            }

            // 3. Aristas invisibles verticales (misma columna, fila a fila) — recorrido "en paralelo"
            var nodoFilaActual = idsPorFila.inicio;
            while (nodoFilaActual != null && nodoFilaActual.siguiente != null)
            {
                var nodoColActual = nodoFilaActual.valor.inicio;
                var nodoColSiguiente = nodoFilaActual.siguiente.valor.inicio;

                while (nodoColActual != null && nodoColSiguiente != null)
                {
                    sb.AppendLine($"  {nodoColActual.valor} -> {nodoColSiguiente.valor} [style=invis];");
                    nodoColActual = nodoColActual.siguiente;
                    nodoColSiguiente = nodoColSiguiente.siguiente;
                }

                nodoFilaActual = nodoFilaActual.siguiente;
            }

            // 4. Resaltar el camino del DFS
            if (camino != null)
            {
                var nodo = camino.inicio;
                string idAnterior = null;

                while (nodo != null)
                {
                    string idActual = $"c{nodo.valor.celda.fila}_{nodo.valor.celda.columna}";
                    if (idAnterior != null)
                        sb.AppendLine($"  {idAnterior} -> {idActual} [color=\"gold\", penwidth=6, arrowhead=none, constraint=false];");

                    idAnterior = idActual;
                    nodo = nodo.siguiente;
                }
            }

            sb.AppendLine("}");
            return sb.ToString();
        }

        public void GenerarImagenMision(string contenidoDot, string rutaSalidaPng)
        {
            string rutaDot = Path.Combine(Path.GetTempPath(), "C:\\Users\\Dell\\Documents\\Universidad\\IPC2\\Proyecto1\\IPC2_Proy01_202602_202500286\\Modelado Misiones\\malla.dot");
            File.WriteAllText(rutaDot, contenidoDot);

            var proceso = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "dot",
                    Arguments = $"-Tpng \"{rutaDot}\" -o \"{rutaSalidaPng}\"",
                    UseShellExecute = false,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                }
            };

            proceso.Start();
            string error = proceso.StandardError.ReadToEnd();
            proceso.WaitForExit();

            if (proceso.ExitCode != 0)
                Console.WriteLine("Error de Graphviz: " + error);
        }
    }
}
