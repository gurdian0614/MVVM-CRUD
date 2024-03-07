using MVVM_CRUD.ViewModels;

namespace MVVM_CRUD.Views;

public partial class EmpleadoMainPage : ContentPage
{
	private EmpleadoMainPageViewModel _viewModel;
	public EmpleadoMainPage()
	{
		InitializeComponent();
		_viewModel = new EmpleadoMainPageViewModel();
		this.BindingContext = _viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		_viewModel.GetAll();
    }
}