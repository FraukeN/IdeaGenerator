using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IdeaGenerator.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaGenerator.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _introduction;

        [ObservableProperty]
        private string _goal;

        [ObservableProperty]
        private string _villain;

        [ObservableProperty]
        private string _ally;

        [ObservableProperty]
        private string _patron;

        [ObservableProperty]
        private string _climax;
        
        AdventureModel adventureModel = new AdventureModel();

        public MainViewModel()
        {
            _introduction = adventureModel.Introduction;
            _goal = adventureModel.Goal;
            _villain = adventureModel.Villain;
            _ally = adventureModel.Ally;
            _patron = adventureModel.Patron;
            _climax = adventureModel.Climax;
        }

        [RelayCommand]
        private void GenerateIdea()
        {
            Debug.WriteLine("Idea generated!");
        }
    }
}
