namespace Entidades
{
    public class Usuarios
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string CURP { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string FechaNacimiento { get; set; }
        public string Estatus { get; set; }
        public string FechaRegistro { get; set; }

        public Usuarios(int idUsuario, string nombre, string curp, string telefono, string email, string fechaNacimiento, string estatus, string fechaRegistro)
        {
            IdUsuario = idUsuario;
            Nombre = nombre;
            CURP = curp;
            Telefono = telefono;
            Email = email;
            FechaNacimiento = fechaNacimiento;
            Estatus = estatus;
            FechaRegistro = fechaRegistro;
        }
    }
}