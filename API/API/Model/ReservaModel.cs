namespace API.Model
{
    public class ReservaModel
    {
        public int Id { get; set; }

        public int IdUsuario { get; set; }
        public int IdLaboratorio { get; set; }

        public DateTime Fecha { get; set; }
        public string? Hora { get; set; }
    }
}
