using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MVVM_CRUD.Models;
using MVVM_CRUD.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_CRUD.ViewModels
{
    public partial class AddEmpleadoPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private int id;

        [ObservableProperty]
        private string nombre;

        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string direccion;

        private readonly EmpleadoService _empleadoService;

        public AddEmpleadoPageViewModel()
        {
            _empleadoService = new EmpleadoService();
        }

        public AddEmpleadoPageViewModel(Empleado empleado)
        {
            Nombre = empleado.Nombre;
            Email = empleado.Email;
            Direccion = empleado.Direccion;
            Id = empleado.Id;
            _empleadoService = new EmpleadoService();
        }

        [RelayCommand]
        private async Task AddUpdate()
        {
            Empleado empleado = new Empleado {
                Nombre = Nombre,
                Email = Email,
                Direccion = Direccion,
                Id = Id
            };

            if (Id == 0)
            {
                _empleadoService.Insert(empleado);
            } else
            {
                _empleadoService.Update(empleado);
            }
            await App.Current.MainPage.Navigation.PopAsync();
        }
    }
}
