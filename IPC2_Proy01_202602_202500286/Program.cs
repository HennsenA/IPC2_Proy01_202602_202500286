using IPC2_Proy01_202602_202500286.Modelo;
using IPC2_Proy01_202602_202500286.TDA_s;
using IPC2_Proy01_202602_202500286.XML;
using System.Runtime.InteropServices.Marshalling;

namespace IPC2_Proy01_202602_202500286;

public class Sistema {
    public ListaRobots ListaRobots;
    public ListaCiudades ListaCiudades;

    public Sistema()
    {
        ListaRobots= new ListaRobots();
        ListaCiudades= new ListaCiudades();
    }

    public static void Main(string[] args)
    {
        Sistema metodos = new Sistema();

        int option = 1;
        while (option > 0) {
            mostrarMenu();
            option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    metodos.cargarArchivos();
                break;
                case 2:
                    metodos.ejecutarMisiones();
                    break;
            }
        }
    }

    public static void mostrarMenu() {
        String menu =
            """
            =================================================
            |           Chapin Wariors System               |
            =================================================
            |   0. Salir                                    |
            |   1. Cargar archivos de configuracion         |
            |   2. Ejecutar Misiones                        |
            =================================================
            |Selecciona una opcion:
            """;

        Console.WriteLine(menu);
    }

    public void cargarArchivos()
    {
        String ruta = "";
        Console.WriteLine("Ingrese la ruta del archivo: ");

        while (ruta=="" || ruta==null)
        {
            ruta = Console.ReadLine();
            if (ruta == "" || ruta == null)
            {
                Console.WriteLine("Error: ruta vacia, ingrese de nuevo");
            }
        }

        ManejoXML UsoXml = new ManejoXML(ruta);
        bool estado = UsoXml.CargaArchivo();
        if (estado == false)
        {
            Console.WriteLine("Error: No se cargo el archivo");
            return;
        }

        UsoXml.CargarRobots(ListaRobots);
        UsoXml.CargarCiudades(ListaCiudades);
    }
    public void ejecutarMisiones() {
        Console.WriteLine("Ejecutando mision de rescate...");
        try
        {
            ListaCiudades.ImprimirNodo();
            NodoCeldas dfs = ListaCiudades.Buscar(0).valor.PrimeraCelda;
            int TamanioMapa = ListaCiudades.Buscar(0).valor.filas * ListaCiudades.Buscar(0).valor.columnas;
            Listas<NodoCeldas> ListaEntradas = ListaCiudades.Buscar(0).valor.BuscarCelda(1);
            Listas<NodoCeldas> ListaRecursos = ListaCiudades.Buscar(0).valor.BuscarCelda(2);
            Listas<NodoCeldas> ListaCiviles = ListaCiudades.Buscar(0).valor.BuscarCelda(3);
            Random rnd = new Random();
            int NoEntradas = ListaEntradas.NoElementos();
            int NoRecursos = ListaRecursos.NoElementos();
            int NoCiviles = ListaCiviles.NoElementos();

            Console.WriteLine("No. Entradas: " + NoEntradas);
            Console.WriteLine("No. Recursos: " + NoRecursos);
            Console.WriteLine("No. Civiles: " + NoCiviles);

            dfs.Dfs(TamanioMapa, ListaEntradas.Buscar(rnd.Next(NoEntradas)).valor, ListaCiviles.Buscar(rnd.Next(NoCiviles)).valor, 0, 1);

            /*Console.WriteLine("Camino encontrado con exito!");*/
        }
        catch (Exception) {
            Console.WriteLine("Error: No hay ciudades en la lista");
        }
    }
    public void MisionRescate() { }
    public void MisionExtraccion() { }
}