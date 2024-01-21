using AIPFoodLookup.Common;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Networking;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AIPFoodLookup.ViewModel
{
    [QueryProperty("Category", "Category")]
    [QueryProperty("SubCategory", "SubCategory")]
    public partial class CategoriesListModel : ObservableObject
    {
        private IConnectivity connectivity;
        private HashimoJoeApi apiClient = new HashimoJoeApi();

        [ObservableProperty]
        string category;
        [ObservableProperty]
        string subCategory;
        [ObservableProperty]
        ObservableCollection<string> categories;
        public ICommand LoadDataCommand { get; }

        public string CombinedTitle => $"Category -> {Category}: {SubCategory}";

        partial void OnCategoryChanged(string value)
        {
            OnPropertyChanged(nameof(CombinedTitle));
        }

        partial void OnSubCategoryChanged(string value)
        {
            OnPropertyChanged(nameof(CombinedTitle));
        }

        public CategoriesListModel(IConnectivity connectivity) 
        {
            this.connectivity = connectivity;
            categories = new ObservableCollection<string>();
            LoadDataCommand = new Command(async () => await LoadDataAsync());
        }

        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }

        private async Task LoadDataAsync()
        {
            try
            {
                if (connectivity.NetworkAccess != NetworkAccess.Internet)
                {
                    await Shell.Current.DisplayAlert("Attention", "No internet!", "OK");
                    return;
                }
                else
                {
                    var stringArray = await apiClient.SubCategories(Category, SubCategory);
                    if (Category == "Allowed" && stringArray.Allowed != null)
                    {
                        stringArray.Allowed.Sort();
                        Categories = new ObservableCollection<string>(stringArray.Allowed);
                    }
                    else if (Category == "Not Allowed" && stringArray.NotAllowed != null)
                    {
                        stringArray.NotAllowed.Sort();
                        Categories = new ObservableCollection<string>(stringArray.NotAllowed);
                    }
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Attention", "A unexpected error occured!", "OK");
            }
        }
    }
}
