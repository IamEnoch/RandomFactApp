using CommunityToolkit.Mvvm.Input;
using RandomFactApp.Models;
using RandomFactApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomFactApp.ViewModels
{
    public partial class RandomFactViewModel : BaseViewModel
    {
        public ObservableCollection<RandomFact> RandomFact { get; } = new();
        RandomFactService _randomFactService;
        public RandomFactViewModel(RandomFactService randomFactService)
        {
            _randomFactService = randomFactService;
        }

        [ICommand]
        public async Task GetRandomFactAsync()
        {
            if (IsBusy == true)
                return;

            try
            {
                IsBusy = true;
                if (RandomFact.Count != 0)
                    RandomFact.Clear();

                var fact = await _randomFactService.GetRandomFactAsync();

                RandomFact.Add(fact);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error", $"An error has occured: {ex.Message}", "Ok");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
