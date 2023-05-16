using DiplomProject.Infrastructure.Commands;
using DiplomProject.Infrastructure.Commands.CommandsCollection;
using DiplomProject.Models;
using DiplomProject.ViewModels.Base;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace DiplomProject.ViewModels
{
    class ActualListOfClientsWindowViewModel : ViewModel
    {
        private List<string> actualClientsList;
        public List<string> ActualClientsList
        {
            get => actualClientsList;
            set
            {
                actualClientsList = value;
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

        public static List<Clients> ActualListObjects;
        public static int selectedItemForTransfer;
        private List<string> ShowActualListToForm()
        {
            var actualObjectsList = DataBaseClassWorker.ShowActualListOfClients();
            var actualStringsList = new List<string>() { };
            foreach (var item in actualObjectsList)
            {
                actualStringsList.Add
                    (
                        item.Surname.ToString() + " " + item.FirstName.ToString() + ", " + item.LastName.ToString() + " (" + item.PhoneNumber.ToString() + ")"
                    );
            }
            ActualListObjects = actualObjectsList;
            return actualStringsList;
        }
        public ICommand ChoosClient { get; }
        public ActualListOfClientsWindowViewModel()
        {
            ActualClientsList = ShowActualListToForm();
            ChoosClient = new LyambdaCommand(ChooseClientFromListCommand.ChooseClientromListExecuted, ChooseClientFromListCommand.ChooseClientFromListCanExecute);
        } 
    }
}
