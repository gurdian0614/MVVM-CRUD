using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MVVM_CRUD.Models;
using MVVM_CRUD.Services;

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

        /// <summary>
        /// Agrega o actualiza un registro
        /// </summary>
        /// <returns></returns>
        [RelayCommand]
        private async Task AddUpdate()
        {
            try
            {
                Empleado empleado = new Empleado
                {
                    Nombre = Nombre,
                    Email = Email,
                    Direccion = Direccion,
                    Id = Id
                };

                if (Validar(empleado))
                {
                    if (Id == 0)
                    {
                        _empleadoService.Insert(empleado);
                    }
                    else
                    {
                        _empleadoService.Update(empleado);
                    }
                    await App.Current!.MainPage!.Navigation.PopAsync();
                }
            } catch (Exception ex)
            {
                Alerta("ERROR", ex.Message);
            }
        }

        /// <summary>
        /// Valida que los campos no esten vacíos
        /// </summary>
        /// <param name="Empleado">Objeto a validar</param>
        /// <returns></returns>
        private bool Validar(Empleado Empleado)
        {
            try
            {
                if (Empleado.Nombre == null || Empleado.Nombre == "")
                {
                    Alerta("ADVERTENCIA", "Escriba el nombre completo");
                    return false;
                }
                else if (Empleado.Email == null || Empleado.Email == "")
                {
                    Alerta("ADVERTENCIA", "Escriba el correo electrónico");
                    return false;
                }
                else if (Empleado.Direccion == null || Empleado.Direccion == "")
                {
                    Alerta("ADVERTENCIA", "Escriba la dirección");
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Alerta("ERROR", ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Método personalizado para construir alertas
        /// </summary>
        /// <param name="Tipo">Tipo de Alerta</param>
        /// <param name="Mensaje">Mensaje de Alerta</param>
        private void Alerta(String Tipo, String Mensaje)
        {
            MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(Tipo, Mensaje, "Aceptar"));
        }
    }
}
