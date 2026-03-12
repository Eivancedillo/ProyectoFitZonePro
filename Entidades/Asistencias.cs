namespace Entidades
{
    public class Asistencias
    {
        public int IdAsistencia { get; set; }
        public int FkIdUsuario { get; set; }
        public string HoraEntrada { get; set; }
        public string HoraSalida { get; set; }

        public Asistencias(int idAsistencia, int fkIdUsuario, string horaEntrada, string horaSalida)
        {
            IdAsistencia = idAsistencia;
            FkIdUsuario = fkIdUsuario;
            HoraEntrada = horaEntrada;
            HoraSalida = horaSalida;
        }
    }
}