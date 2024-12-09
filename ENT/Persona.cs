namespace ENT
{
    public class Persona
    {
        public int Id { get; set; } = 0;
        public string? Nombre { get; set; } = "";
        public string? Apellidos { get; set; } = "";
        public string? Telefono { get; set; } = "";
        public string? Direccion { get; set; } = "";
        public string? Foto { get; set; } = "";
        public DateTime? FechaNacimiento { get; set; } = DateTime.Now;
        public int? IDDepartamento { get; set; } = 0;

        public string NombreCompleto => $"{Nombre} {Apellidos}";

        public Persona()
        {
        }

        public Persona(Persona p)
        {
            Id = p.Id;
            Nombre = p.Nombre;
            Apellidos = p.Apellidos;
            Telefono = p.Telefono;
            Direccion = p.Direccion;
            Foto = p.Foto;
            FechaNacimiento = p.FechaNacimiento;
            IDDepartamento = p.IDDepartamento;
        }

        public Persona(string nombre, string apellidos, string telefono, string direccion, string foto, DateTime fechaNacimiento, int idDepartamento)
        {
            Nombre = nombre;
            Apellidos = apellidos;
            Telefono = telefono;
            Direccion = direccion;
            Foto = foto;
            FechaNacimiento = fechaNacimiento;
            IDDepartamento = idDepartamento;
        }
        public override string ToString()
        {
            return $"Id: {Id}, Nombre: {Nombre}, Apellidos: {Apellidos}, Telefono: {Telefono}, " +
                   $"Direccion: {Direccion}, Foto: {Foto}, FechaNacimiento: {FechaNacimiento?.ToShortDateString()}, " +
                   $"IDDepartamento: {IDDepartamento}, NombreCompleto: {NombreCompleto}";
        }

    }
}
