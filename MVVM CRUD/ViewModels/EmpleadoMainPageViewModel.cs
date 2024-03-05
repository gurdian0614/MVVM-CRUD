using CommunityToolkit.Mvvm.ComponentModel;
using MVVM_CRUD.Models;
using MVVM_CRUD.Services;
using System.Collections.ObjectModel;

namespace MVVM_CRUD.ViewModels
{
    internal partial class EmpleadoMainPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Empleado> empleadoCollection = new ObservableCollection<Empleado>();

        private readonly EmpleadoService _empleadoService;

        public EmpleadoMainPageViewModel()
        {
            _empleadoService = new EmpleadoService();
        }

        public void GetAll()
        {
            var getAll = _empleadoService.GetAll();

            if (getAll?.Count > 0)
            {
                EmpleadoCollection.Clear();
                foreach (var empleado in getAll)
                {
                    EmpleadoCollection.Add(empleado);
                }
            }
        }
    }
}
