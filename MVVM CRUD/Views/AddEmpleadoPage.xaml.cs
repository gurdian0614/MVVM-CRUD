using MVVM_CRUD.Models;
using MVVM_CRUD.ViewModels;

namespace MVVM_CRUD.Views;

public partial class AddEmpleadoPage : ContentPage
{
	private AddEmpleadoPageViewModel _viewModel;
	public AddEmpleadoPage()
	{
		InitializeComponent();
		_viewModel = new AddEmpleadoPageViewModel();
		this.BindingContext = _viewModel;
	}

	public AddEmpleadoPage(Empleado empleado)
	{
		InitializeComponent();
		_viewModel = new AddEmpleadoPageViewModel(empleado);
		this.BindingContext = _viewModel;
	}
}