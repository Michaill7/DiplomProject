using DiplomProject.Models;
using DiplomProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomProject.Infrastructure.Commands.CommandsCollection
{
    class AddNewOrderToDB
    {
        public static bool AddNewOrderToDBCanExecute(object o) 
        {
            if (NewOfferWindowViewModel.orderSumForTransfer == 0 || NewOfferWindowViewModel.orderDaysCountForTransfer==0 || NewOfferWindowViewModel.choosedVINForTransfer == ""|| NewOfferWindowViewModel.actualElementsOfPositions.Count==0)
                return false;
            else 
                return true;
        }

        public static void AddNewOrderToDBExecuted(object o) 
        {
            DataBaseClassWorker.AddDataAboutNewOrder();
        }
    }
}
