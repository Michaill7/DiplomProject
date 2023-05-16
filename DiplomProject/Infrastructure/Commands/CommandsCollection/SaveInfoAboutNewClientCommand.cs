using DiplomProject.Models;
using DiplomProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DiplomProject.Infrastructure.Commands.CommandsCollection
{
    class SaveInfoAboutNewClientCommand
    {
        public static bool SaveInfoAboutNewClientCanExecute(object o) => true;
        public static void SaveInfoAboutNewClientExecuted(object o) 
        {
            DataBaseClassWorker.AddDataAboutNewClientToDataBase(AddClientWindowViewModel.newSurnameForTransfer, AddClientWindowViewModel.newFirstNameForTransfer, AddClientWindowViewModel.newLastNameForTransfer, AddClientWindowViewModel.newPhoneNumberForTransfer);
            NewOfferWindowViewModel.choosedClientPhoneNumberForTransfer = AddClientWindowViewModel.newPhoneNumberForTransfer;
            NewOfferWindowViewModel.WriteClientProperty();
        }
    }
}
