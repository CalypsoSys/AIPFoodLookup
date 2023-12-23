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

        public MainViewModel(IConnectivity connectivity)
        {
            allowed = new ObservableCollection<string>();
            notAllowed = new ObservableCollection<string>();
            this.connectivity = connectivity;
        }

        async partial void OnTextChanged(string value)
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
                if (value.Length > 2)
                {
                    var stringArray = await apiClient.Search(value);
                    if (stringArray.PossibleAllowed != null)
                    {
                        Allowed = new ObservableCollection<string>(stringArray.PossibleAllowed);
                    }
                    if (stringArray.PossibleDisallowed != null)
                    {
                        NotAllowed = new ObservableCollection<string>(stringArray.PossibleDisallowed);
                    }
                }
            }
        }
    }
}
