using AIPFoodLookup.ViewModel;

namespace AIPFoodLookup;

public partial class CatagoriesPage : ContentPage
{
	public CatagoriesPage(CategoriesViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}