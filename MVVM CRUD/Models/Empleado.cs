using SQLite;

namespace MVVM_CRUD.Models
{
    public class Empleado
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set;}
        public string Direccion { get; set;}
    }
}
