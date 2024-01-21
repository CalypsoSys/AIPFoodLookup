using AIPFoodLookup.ViewModel;

namespace AIPFoodLookup;

public partial class CategoriesListPage : ContentPage
{
    public CategoriesListPage(CategoriesListModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is CategoriesListModel viewModel)
        {
            viewModel.LoadDataCommand.Execute(null);
        }
    }
}