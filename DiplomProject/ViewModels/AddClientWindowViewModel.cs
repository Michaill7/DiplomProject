using DiplomProject.Infrastructure.Commands;
using DiplomProject.Infrastructure.Commands.CommandsCollection;
using DiplomProject.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DiplomProject.ViewModels
{
    class AddClientWindowViewModel : ViewModel
    {
        private string newSurname;
        public string NewSurname 
        {
            get => newSurname;
            set 
            {
                newSurname = value;
                newSurnameForTransfer = value;
                OnPropertyChange();
            }
        }

        private string newFirstName;
        public string NewFirstName 
        {
            get => newFirstName;
            set 
            {
                newFirstName = value;
                newFirstNameForTransfer = value;
                OnPropertyChange();
            }
        }

        private string newLastName;
        public string NewLastName 
        {
            get => newLastName;
            set 
            {
                newLastName = value;
                newLastNameForTransfer = value;
                OnPropertyChange();
            }
        }

        private string newPhoneNumber;
        public string NewPhoneNumber 
        {
            get => newPhoneNumber;
            set 
            {
                newPhoneNumber = value;
                newPhoneNumberForTransfer = value;
                OnPropertyChange();
            }
        }



        public static string newSurnameForTransfer;
        public static string newFirstNameForTransfer;
        public static string newLastNameForTransfer;
        public static string newPhoneNumberForTransfer;

        public ICommand SaveDataToDataBaseCommand { get; }
        public AddClientWindowViewModel()
        {
            SaveDataToDataBaseCommand = new LyambdaCommand(SaveInfoAboutNewClientCommand.SaveInfoAboutNewClientExecuted, SaveInfoAboutNewClientCommand.SaveInfoAboutNewClientCanExecute);
        }
    }
}
