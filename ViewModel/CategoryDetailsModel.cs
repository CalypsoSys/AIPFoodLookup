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
    [QueryProperty("Text", "Text")]
    public partial class CategoryDetailsModel : ObservableObject
    {
        private IConnectivity connectivity;
        private HashimoJoeApi apiClient = new HashimoJoeApi();

        [ObservableProperty]
        string text;
        [ObservableProperty]
        ObservableCollection<string> categories;
        public ICommand LoadDataCommand { get; }

        public CategoryDetailsModel(IConnectivity connectivity) 
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
                    var stringArray = await apiClient.Categories();
                    if (Text == "Allowed" && stringArray.Allowed != null)
                    {
                        stringArray.Allowed.Sort();
                        Categories = new ObservableCollection<string>(stringArray.Allowed);
                    }
                    else if (Text == "Not Allowed" && stringArray.NotAllowed != null)
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
