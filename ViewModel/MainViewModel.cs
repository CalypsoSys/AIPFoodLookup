using AIPFoodLookup.Common;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPFoodLookup.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        private IConnectivity connectivity;
        private HashimoJoeApi apiClient = new HashimoJoeApi();

        [ObservableProperty]
        ObservableCollection<string> allowed;
        [ObservableProperty]
        ObservableCollection<string> notAllowed;

        [ObservableProperty]
        string text;
        [ObservableProperty]
        string searchType = "Search by Text and Sound";

        public MainViewModel(IConnectivity connectivity)
        {
            allowed = new ObservableCollection<string>();
            notAllowed = new ObservableCollection<string>();
            this.connectivity = connectivity;
        }

        async partial void OnTextChanged(string value)
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
                    Allowed = new ObservableCollection<string>();
                    NotAllowed = new ObservableCollection<string>();
                    if (string.IsNullOrWhiteSpace(value) == false && value.Length > 2)
                    {
                        var stringArray = await apiClient.Search(value, SearchType);
                        if (stringArray.Allowed != null)
                        {
                            Allowed = new ObservableCollection<string>(stringArray.Allowed);
                        }
                        else
                        {
                            Allowed = new ObservableCollection<string>(new string[]{"Swipe right to Suggest as allowed" });
                        }
                        if (stringArray.NotAllowed != null)
                        {
                            NotAllowed = new ObservableCollection<string>(stringArray.NotAllowed);
                        }
                        else
                        {
                            NotAllowed = new ObservableCollection<string>(new string[] { "Swipe left to Suggest as NOT allowed" });
                        }
                    }
                }
            }
            catch (Exception ex) 
            {
                await Shell.Current.DisplayAlert("Attention", "A unexpected error occured!", "OK");
            }
        }

        [RelayCommand]
        async Task SuggestAllowed()
        {
            await Suggest(Text, true);
        }

        [RelayCommand]
        async Task SuggestNotAllowed()
        {
            await Suggest(Text, false);
        }

        async Task Suggest(string text, bool allowed)
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
                    if (string.IsNullOrWhiteSpace(text) == false && text.Length > 2)
                    {
                        var resp = await apiClient.Suggest(text, allowed);
                        if (resp.IsSuccessStatusCode)
                        {
                            await Shell.Current.DisplayAlert("Attention", "Will will look at your suggestion promptly and add to our cataglog", "Thanks");
                        }
                        else
                        {
                            await Shell.Current.DisplayAlert("Attention", "Suggestion could not be made", "OK");
                        }
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
