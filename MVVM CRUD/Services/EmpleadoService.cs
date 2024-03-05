using MVVM_CRUD.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_CRUD.Services
{
    internal class EmpleadoService
    {
        private readonly SQLiteConnection _dbConnection;

        public EmpleadoService() {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Empleado.db");
            _dbConnection = new SQLiteConnection(dbPath);
            _dbConnection.CreateTable<Empleado>();
        }

        public List<Empleado> GetAll() {
            var res = _dbConnection.Table<Empleado>().ToList();
            return res;
        }

        public int Insert(Empleado empleado)
        {
            return _dbConnection.Insert(empleado);
        }

        public int Update(Empleado empleado)
        {
            return _dbConnection.Update(empleado);
        }

        public int Delete(Empleado empleado)
        {
            return _dbConnection.Delete(empleado);
        }
    }
}
