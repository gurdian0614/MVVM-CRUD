using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MVVM_CRUD.Models;
using MVVM_CRUD.Services;
using MVVM_CRUD.Views;
using System.Collections.ObjectModel;

namespace MVVM_CRUD.ViewModels
{
    public partial class EmpleadoMainPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Empleado> empleadoCollection = new ObservableCollection<Empleado>();

        private readonly EmpleadoService _empleadoService;

        public EmpleadoMainPageViewModel()
        {
            _empleadoService = new EmpleadoService();
        }

        /// <summary>
        /// Obtiene el listado de empleados
        /// </summary>
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

        /// <summary>
        /// Redirecciona al formulario de MEpleado
        /// </summary>
        /// <returns></returns>
        [RelayCommand]
        private async Task GoToAddEmpleadoPage()
        {
            await App.Current!.MainPage!.Navigation.PushAsync(new AddEmpleadoPage());
        }

        /// <summary>
        /// Selecciona el registro para editar o eliminar
        /// </summary>
        /// <param name="empleado">Objeto a editar o eliminar</param>
        /// <returns></returns>
        [RelayCommand]
        private async Task SelectEmpleado(Empleado empleado)
        {
            string res = await App.Current!.MainPage!.DisplayActionSheet("Operación", "Cancelar", null, "Actualizar", "Eliminar");

            switch (res)
            {
                case "Actualizar":
                    await App.Current.MainPage.Navigation.PushAsync(new AddEmpleadoPage(empleado));
                    break;
                case "Eliminar":
                    int del = _empleadoService.Delete(empleado);
                    if (del > 0)
                    {
                        EmpleadoCollection.Remove(empleado);
                    }
                    break;
            }
        }
    }
}
