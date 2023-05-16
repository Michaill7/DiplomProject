using DiplomProject.Models;
using DiplomProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomProject.Infrastructure.Commands.CommandsCollection
{
    class SaveInfoAboutNewAutoCommand
    {
        public static bool SaveInfoAboutNewAutoCanExecute(object o) => true;
        public static void SaveInfoAboutNewAutoExecuted(object o) 
        {
            DataBaseClassWorker.AddDataAboutNewCarToDB(AddAutoWindowViewModel.newVINForTransfer, AddAutoWindowViewModel.newMarkaForTransfer, AddAutoWindowViewModel.newModelForTransfer, AddAutoWindowViewModel.newYearForTransfer);
            NewOfferWindowViewModel.choosedVINForTransfer = AddAutoWindowViewModel.newVINForTransfer;
            NewOfferWindowViewModel.AddNoteDel();
        }
    }
}
