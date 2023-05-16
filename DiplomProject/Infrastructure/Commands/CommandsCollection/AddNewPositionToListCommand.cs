using DiplomProject.Models;
using DiplomProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomProject.Infrastructure.Commands.CommandsCollection
{
    class AddNewPositionToListCommand
    {
        public static bool AddNewPositionToListCanExecute(object o) 
        {
            if (NewPositionWindowViewModel.actualArticulForTransfer is null || NewPositionWindowViewModel.actualNameForTransfer is null || NewPositionWindowViewModel.actualPriceForTransfer is null || NewPositionWindowViewModel.actualSalePriceForTransfer is null)
                return false;
            else
                return true;
        }

        public static void AddNewPositionToListExecuted(object o) 
        {
            NewPositionWindowViewModel.actualListOfElements.Add
                (
                    new Elements
                    {
                        Articul = NewPositionWindowViewModel.actualArticulForTransfer,
                        Name = NewPositionWindowViewModel.actualNameForTransfer,
                        PurchasePrice = NewPositionWindowViewModel.actualPriceForTransfer,
                        SalePrice = NewPositionWindowViewModel.actualSalePriceForTransfer
                    }
                ) ;
            NewPositionWindowViewModel.WritePositionsInList();
        }
    }
}
