using DiplomProject.ViewModels;
using DiplomProject.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomProject.Infrastructure.Commands.CommandsCollection
{
    class OpenAddAutoWindowCommand
    {
        public static bool OpenNewAddAutoWindowCanExecute(object o) 
        {
            if (NewOfferWindowViewModel.choosedClientPhoneNumberForTransfer != null)
                return true;
            else
                return false;
        }

        public static void OpenNewAddAutoWindowExecuted(object o) 
        {
            var newAddCarWindow = new AddAutoWindow();
            newAddCarWindow.Show();
            newAddCarWindow.Activate();
        }
    }
}
