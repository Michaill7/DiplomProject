using DiplomProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DiplomProject.Infrastructure.Commands.CommandsCollection
{
    class SavePositionsListInNewOrderCommand
    {
        public static bool SavePositionsListInNewOrderCanExecute(object o) 
        {
            if (NewPositionWindowViewModel.actualPositionListCount == 0) return false;
            else return true;
        }
        public static void SavePositionsListInNewOrderExecuted(object o) 
        {
            NewOfferWindowViewModel.actualElementsOfPositions = NewPositionWindowViewModel.actualListOfElements;
        }
    }
}
