using AIPFoodLookup.ViewModel;

namespace AIPFoodLookup;

public partial class CategoryDetailsPage : ContentPage
{
    public CategoryDetailsPage(CategoryDetailsModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is CategoryDetailsModel viewModel)
        {
            viewModel.LoadDataCommand.Execute(null);
        }
    }
}