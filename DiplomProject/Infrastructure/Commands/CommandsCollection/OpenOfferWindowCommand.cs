using DiplomProject.Models;
using DiplomProject.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DiplomProject.Infrastructure.Commands.CommandsCollection
{
    public class OpenOfferWindowCommand
    {
        public static bool OpenOfferWindowCanExecute(object o) => true;

        public static void OpenOfferWindowExecuted(object o)
        {
            var offerWindow = new NewOfferWindow();
            offerWindow.Show();
            //DataBaseClassWorker.ShowAccountingSales();
        }
    }
}
