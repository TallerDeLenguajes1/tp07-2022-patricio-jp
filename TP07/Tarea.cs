public enum EstadoTarea {
    Completada,
    Pendiente
}

public class Tarea {
    private int tareaID;
    private string descripcion;
    private int duracion;
    private EstadoTarea estado;

    public int TareaID { get => tareaID; set => tareaID = value; }
    public string Descripcion { get => descripcion; set => descripcion = value; }
    public int Duracion { get => duracion; set => duracion = value; }
    public EstadoTarea Estado { get => estado; set => estado = value; }

    public Tarea(int id, string descripcion, int duracion) {
        TareaID = id;
        Descripcion = descripcion;
        Duracion = duracion;
        Estado = EstadoTarea.Pendiente;
    }

    public override string ToString() {
        return "ID: " + TareaID + "\nDescripción: " + Descripcion + "\nDuración: " + Duracion + "\nEstado: " + Estado.ToString();
    }
}