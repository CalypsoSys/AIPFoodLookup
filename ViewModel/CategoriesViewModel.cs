using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPFoodLookup.ViewModel
{
    public partial class CategoriesViewModel: ObservableObject
    {
        [RelayCommand]
        async Task Tap(string s)
        {
            await Shell.Current.GoToAsync($"{nameof(CategoryDetailsPage)}?Text={s}");
        }
    }
}
