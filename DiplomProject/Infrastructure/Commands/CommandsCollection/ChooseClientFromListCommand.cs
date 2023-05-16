using DiplomProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DiplomProject.Infrastructure.Commands.CommandsCollection
{
    class ChooseClientFromListCommand
    {
        private static string PhoneNumber;
        public static bool ChooseClientFromListCanExecute(object o) => true;
        public static void ChooseClientromListExecuted(object o) 
        {
            foreach (var item in ActualListOfClientsWindowViewModel.ActualListObjects)
            {
                if (ActualListOfClientsWindowViewModel.selectedItemForTransfer == Convert.ToInt64(item.ID))
                    PhoneNumber = item.PhoneNumber;
            }
            NewOfferWindowViewModel.choosedClientPhoneNumberForTransfer = PhoneNumber;
            NewOfferWindowViewModel.WriteClientProperty();
        }
    }
}
