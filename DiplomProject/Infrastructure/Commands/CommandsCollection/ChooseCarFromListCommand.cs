using DiplomProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DiplomProject.Infrastructure.Commands.CommandsCollection
{
    public class ChooseCarFromListCommand
    {
        private static long actualVin;
        public static bool ChooseCarFromListCanExecute(object o) => true;
        public static void ChooseCarFromListExecuted(object o) 
        {
            foreach (var item in ActualListOfCarsWindowViewModel.ActualListObjects)
            {
                if (ActualListOfCarsWindowViewModel.selectedItemForTransfer == Convert.ToInt64(item.ID))         
                    actualVin = Convert.ToInt64(item.VIN); 
            }  
            NewOfferWindowViewModel.choosedVINForTransfer = actualVin.ToString();
            NewOfferWindowViewModel.AddNoteDel();
        }
    }
}
