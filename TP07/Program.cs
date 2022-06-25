
int operacion = 0, cantTareas = 0, duracion = 0, idAux = 0;
string entrada = "";

Random randomObj = new Random();

List<Tarea> tareasPendientes = new List<Tarea>();
List<Tarea> tareasRealizadas = new List<Tarea>();

do {
    // Console.Clear();
    Console.WriteLine("====== Modulo Tareas ======");
    Console.WriteLine("1. Cargar tareas");
    Console.WriteLine("2. Listar tareas pendientes");
    Console.WriteLine("3. Listar tareas realizadas");
    Console.WriteLine("4. Marcar una tarea pendiente como realizada");
    Console.WriteLine("5. Buscar una tarea pendiente");
    Console.WriteLine("6. Listar cantidad de horas trabajadas por el empleado");
    Console.WriteLine("0. Salir");


    entrada = Console.ReadLine();

    while (!Int32.TryParse(entrada, out operacion) || operacion < 0 || operacion > 6) {
        Console.WriteLine("Error! Debe ingresar una opción válida");
        entrada = Console.ReadLine();
    }

    switch (operacion) {
        case 1:
            cantTareas = randomObj.Next(1, 6);
            Console.WriteLine("Cantidad de tareas a cargar: " + cantTareas);
            cargarTareas(tareasPendientes, cantTareas);
            break;
        case 2:
            mostrarTareas(tareasPendientes);
            break;
        case 3:
            mostrarTareas(tareasRealizadas);
            break;
        case 4:
            Console.Write("Ingrese el ID de la tarea pendiente que desea marcar como completada: ");
            entrada = Console.ReadLine();
            while (!Int32.TryParse(entrada, out idAux)) {
                Console.Write("Error! Debe ingresar un ID válido: ");
                entrada = Console.ReadLine();
            }
            moverTarea(tareasPendientes, idAux, tareasRealizadas);
            break;
        case 5:
            Console.Write("Buscar tarea pendiente por descripción: ");
            entrada = Console.ReadLine();
            buscarTarea(entrada, tareasPendientes);
            break;
        case 6:
            int cantHoras = 0;
            foreach (Tarea tarea in tareasRealizadas) {
                cantHoras += tarea.Duracion;
            }
            Console.WriteLine($"Cantidad de horas trabajadas por el empleado: {cantHoras} horas");
            break;
    }
    Thread.Sleep(2000); // Esperar 2 seg antes de volver a mostrar el menú

} while (operacion != 0);



void buscarTarea(string descripcion, List<Tarea> pendientes) {
    bool esta = false;
    Tarea tareaBuscada = null;
    for (int i = 0; i < pendientes.Count; i++) {
        if (pendientes[i].Descripcion == descripcion) {
            esta = true;
            tareaBuscada = pendientes[i];
            break;
        }
    }
    if (!esta) {
        Console.WriteLine("No se encontró la tarea con la descripción brindada.");
    } else {
        Console.WriteLine("--- Tarea encontrada ---");
        Console.WriteLine(tareaBuscada.ToString());
        Console.WriteLine("------------------------");
    }
}

void moverTarea(List<Tarea> pendientes, int IDTarea, List<Tarea> realizadas) {
    bool esta = false;
    for (int i = 0; i < pendientes.Count; i++) {
        if (pendientes[i].TareaID == IDTarea) {
            esta = true;
            pendientes[i].Estado = EstadoTarea.Completada;
            realizadas.Add(pendientes[i]);
            pendientes.Remove(pendientes[i]);
            break;
        }
    }
    if (!esta) {
        Console.WriteLine("No existe la tarea con ese ID dentro de las tareas pendientes");
    }
}

void mostrarTareas (List<Tarea> listado) {
    if (listado.Count == 0) {
        Console.WriteLine("-- Listado de tareas vacío --");
    } else {
        foreach (Tarea unaTarea in listado) {
            Console.WriteLine("\n--- Tarea ---");
            Console.WriteLine(unaTarea.ToString());
            Console.WriteLine("---------------");
        }
    }
}

void cargarTareas(List<Tarea> listado, int cantTareas) {
    int duracion;
    for (int i = 0; i < cantTareas; i++) {
        Console.WriteLine("\n--- Tarea n° " + (i + 1) + " ---");
        Console.Write("Ingrese su descripción: ");
        duracion = randomObj.Next(10, 101);
        string descripcion = Console.ReadLine();
        Tarea tarea = new Tarea(i + 1, descripcion, duracion);
        listado.Add(tarea);
    }
}
