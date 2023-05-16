using DiplomProject.Infrastructure.Commands;
using DiplomProject.Infrastructure.Commands.CommandsCollection;
using DiplomProject.Models;
using DiplomProject.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DiplomProject.ViewModels
{
    class ActualListOfCarsWindowViewModel : ViewModel
    {
        private List<string> actualCarList;
        public List<string> ActualCarList
        {
            get => actualCarList;
            set
            {
                actualCarList = value;
                OnPropertyChange();
            }
        }

        private int selecteditemIndexInList;
        public int SelecteditemIndexInList 
        {
            get => selecteditemIndexInList;
            set 
            {
                selecteditemIndexInList = value;
                selectedItemForTransfer = value;
                OnPropertyChange();
            }
        }

        public static List<Cars> ActualListObjects;
        public static int selectedItemForTransfer;
        private List<string> ShowActualListToForm() 
        {
            var actualObjectsList = DataBaseClassWorker.ShowActualListOfCars();
            var actualStringsList = new List<string>() { };
            foreach (var item in actualObjectsList)
            {
                actualStringsList.Add
                    (
                        item.Marka.ToString() + " " + item.Model.ToString() + ", " + item.Year.ToString() + " (" + item.VIN.ToString() + ")"
                    );
            }
            ActualListObjects = actualObjectsList;
            return actualStringsList;
        }
        public ICommand ChooseAuto { get; }
        public ActualListOfCarsWindowViewModel()
        {
            ActualCarList = ShowActualListToForm();
            ChooseAuto = new LyambdaCommand(ChooseCarFromListCommand.ChooseCarFromListExecuted, ChooseCarFromListCommand.ChooseCarFromListCanExecute);
        }
    }
}
