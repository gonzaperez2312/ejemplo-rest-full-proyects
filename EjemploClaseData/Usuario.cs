namespace EjemploClaseData
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public string CorreoElectronico { get; set;}
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaEliminacion { get; set; }

        public List<Telefono> Telefonos { get; set; }
    }
}