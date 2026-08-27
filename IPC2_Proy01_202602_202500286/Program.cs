using IPC2_Proy01_202602_202500286.Modelado_Misiones;
using IPC2_Proy01_202602_202500286.Modelo;
using IPC2_Proy01_202602_202500286.TDA_s;
using IPC2_Proy01_202602_202500286.XML;
using System.Diagnostics;
using System.Globalization;
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
                    metodos.EjecutarMisiones();
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
    public void EjecutarMisiones() {
        int op = 1;

        //Validacion de sistema sin configuracion
        if (ListaCiudades.NoElementos()==0 || ListaRobots.NoElementos()==0)
        {
            Console.WriteLine(
                """

                Error: No es posible ejecutar alguna mision
                Cargue el archivo de configuracion e intente de nuevo.

                """);

            return;
        }

        int NoCiudad = 0;
        String menu = "";

        //seleccion de ciudad
        Console.WriteLine("""
                Lista de Ciudades:

                """);
        ListaCiudades.ImprimirNodo();
        Console.WriteLine("Seleccione una ciudad");
        NoCiudad = int.Parse(Console.ReadLine()) - 1;
        while (NoCiudad < 0 || NoCiudad >= ListaCiudades.NoElementos())
        {
            Console.WriteLine("Error: Numero de ciudad no valido, ingrese otro");
            NoCiudad = int.Parse(Console.ReadLine()) - 1;
        }

        //validacion de tipo de ciudad
        Ciudades CiudadSeleccionada = ListaCiudades.Buscar(NoCiudad).valor;
        Listas<NodoCeldas> ListaEntradas = CiudadSeleccionada.BuscarCelda(1);
        Listas<NodoCeldas> ListaRecursos = CiudadSeleccionada.BuscarCelda(2);
        Listas<NodoCeldas> ListaCiviles = CiudadSeleccionada.BuscarCelda(3);

        while (op > 0)
        {
            Console.WriteLine(
            """
            =================================================
            |           Ejecucion de Misiones               |
            =================================================
            |   0. Salir                                    |
            |   1. Ejecutar Mision de Rescate                |
            |   2. Ejecutar Mision de Extraccion             |
            =================================================
            |Selecciona una opcion:
            """);

            op = int.Parse(Console.ReadLine());
            switch (op)
            {
                case 1:
                    MisionRescate(op, CiudadSeleccionada, ListaEntradas, ListaCiviles);
                    break;
                case 2:
                    MisionExtraccion(op, CiudadSeleccionada, ListaEntradas, ListaRecursos);
                    break;
                case 0:
                    Console.WriteLine("Regresando al menu principal...\n");
                    return;
                default:
                    Console.WriteLine("Error: opcion no valida, ingrese de nuevo");
                    break;
            }
        }
    }
    public void MisionRescate(int mision, Ciudades ciudad, Listas<NodoCeldas> ListaEntradas, Listas<NodoCeldas> ListaCiviles) 
    {

        //DATOS DE LA CIUDAD
        NodoCeldas dfs = ciudad.PrimeraCelda; //Celda de referencia para dfs (no es la inicial)
        Misiones Grafica = new Misiones();
        int TamanioMapa = ciudad.filas * ciudad.columnas;
        Random rnd = new Random();
        int NoEntradas = ListaEntradas.NoElementos();
        int NoCiviles = ListaCiviles.NoElementos();

        //IMPRESION Y SELECCION DE ROBOTS
        int NoRobot = 0;
        Console.WriteLine("""
            
            Lista de Robots:

            """);
        ListaRobots.ImprimirNodo();
        Console.WriteLine("Seleccione un robot (solo se permite ChapinRescue): ");
        NoRobot = int.Parse(Console.ReadLine())-1;
        while (NoRobot<0 || NoRobot >= ListaRobots.NoElementos())
        {
            Console.WriteLine("Error: Numero de robot no valido, ingrese de nuevo");
            NoRobot = int.Parse(Console.ReadLine())-1;
        }

        ChapinRobots Robot = ListaRobots.Buscar(NoRobot).valor;

        //VALIDACION DE ROBOT CORRECTO
        if (Robot.capcomb != 0)
        {
            Console.WriteLine("Error: Este robot no puede ejecutar la mision");
            return;
        }

        //IMPRESION DE CIVILES
        Console.WriteLine("No. Civiles: " + NoCiviles); //Mostrar los civiles y sus coordenadas
        for(int i = 0; i < ListaCiviles.NoElementos(); i++)
        {
            int fila = ListaCiviles.Buscar(i).valor.celda.fila;
            int columna = ListaCiviles.Buscar(i).valor.celda.columna;

            Console.WriteLine($"""

                Civil No. {i+1}
                Fila: {fila+1}
                Columna: {columna+1}

                """);
        }

        //INPUT DEL CIVIL A RESCATAR
        Console.WriteLine("Seleccione el civil a rescatar: ");
        int NoCivil = 0;
        NoCivil = int.Parse(Console.ReadLine()) - 1;
        while (NoCivil < 0 || NoCivil >= ListaCiviles.NoElementos())
        {
            Console.WriteLine("Error: Numero de civil no valido, ingrese de nuevo");
            NoCivil = int.Parse(Console.ReadLine()) - 1;
        }
        NodoCeldas Civil = ListaCiviles.Buscar(NoCivil).valor;

        Listas<NodoCeldas> ListaCamino = dfs.Dfs(TamanioMapa, ListaEntradas.Buscar(rnd.Next(NoEntradas)).valor, Civil, Robot.capcomb, mision);

        string ArchivoDot = Grafica.GenerarDot(ciudad.PrimeraCelda, ListaCamino);
        string RutaImgs = "C:\\Users\\Dell\\Documents\\Universidad\\IPC2\\Proyecto1\\IPC2_Proy01_202602_202500286\\Modelado Misiones\\mision_rescate.png";
        Grafica.GenerarImagenMision(ArchivoDot, RutaImgs);
        Process.Start(new ProcessStartInfo(RutaImgs) { UseShellExecute = true });
    }

    public void MisionExtraccion(int mision, Ciudades ciudad, Listas<NodoCeldas> ListaEntradas, Listas<NodoCeldas> ListaRecursos)
    {
        //DATOS DE LA CIUDAD
        NodoCeldas dfs = ciudad.PrimeraCelda; //Celda de referencia para dfs (no es la inicial)
        Misiones Grafica = new Misiones();
        int TamanioMapa = ciudad.filas * ciudad.columnas;
        Random rnd = new Random();
        int NoEntradas = ListaEntradas.NoElementos();
        int NoRecursos = ListaRecursos.NoElementos();

        //IMPRESION Y SELECCION DE ROBOTS
        int NoRobot = 0;
        Console.WriteLine("""
            
            Lista de Robots:

            """);
        ListaRobots.ImprimirNodo();
        Console.WriteLine("Seleccione un robot (solo se permite ChapinFighter): ");
        NoRobot = int.Parse(Console.ReadLine()) - 1;
        while (NoRobot < 0 || NoRobot >= ListaRobots.NoElementos())
        {
            Console.WriteLine("Error: Numero de robot no valido, ingrese de nuevo");
            NoRobot = int.Parse(Console.ReadLine()) - 1;
        }

        ChapinRobots Robot = ListaRobots.Buscar(NoRobot).valor;
        //VALIDACION DE ROBOT CORRECTO
        if (Robot.capcomb == 0)
        {
            Console.WriteLine("Error: Este robot no puede ejecutar la mision");
            return;
        }

        //IMPRESION DE RECURSOS
        Console.WriteLine("No. Recursos: " + NoRecursos); //Mostrar los civiles y sus coordenadas
        for (int i = 0; i < ListaRecursos.NoElementos(); i++)
        {
            int fila = ListaRecursos.Buscar(i).valor.celda.fila;
            int columna = ListaRecursos.Buscar(i).valor.celda.columna;

            Console.WriteLine($"""

                Recurso No. {i + 1}
                Fila: {fila + 1}
                Columna: {columna + 1}

                """);
        }

        //INPUT DEL RECURSO A EXTRAER
        Console.WriteLine("Seleccione el recurso a extraer: ");
        int NoRecurso = 0;
        NoRecurso = int.Parse(Console.ReadLine()) - 1;
        while (NoRecurso < 0 || NoRecurso >= ListaRecursos.NoElementos())
        {
            Console.WriteLine("Error: Numero de recurso no valido, ingrese de nuevo");
            NoRecurso = int.Parse(Console.ReadLine()) - 1;
        }
        NodoCeldas Recurso = ListaRecursos.Buscar(NoRecurso).valor;

        Listas<NodoCeldas> ListaCamino = dfs.Dfs(TamanioMapa, ListaEntradas.Buscar(rnd.Next(NoEntradas)).valor, Recurso, Robot.capcomb, mision);
        string ArchivoDot = Grafica.GenerarDot(ciudad.PrimeraCelda, ListaCamino);
        string RutaImgs = "C:\\Users\\Dell\\Documents\\Universidad\\IPC2\\Proyecto1\\IPC2_Proy01_202602_202500286\\Modelado Misiones\\mision_extraccion.png";
        Grafica.GenerarImagenMision(ArchivoDot, RutaImgs);
        Process.Start(new ProcessStartInfo(RutaImgs) { UseShellExecute = true });
    }
}